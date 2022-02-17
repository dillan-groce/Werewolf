using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Werewolf.Models.Card;
using Werewolf.Service;
using Werewolf.Data;

namespace Werewolf.MVC.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CardService(userId);
            var model = service.GetCards();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateCardService();
            if (service.CreateCard(model))
            {
                TempData["SaveResult"] = "Your wild card was created.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCardService();
            var model = svc.GetCardById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCardService();
            var detail = service.GetCardById(id);
            var model =
                new CardEdit
                {
                    CardId = detail.CardId,
                    RoleName = detail.RoleName,
                    Power = detail.Power
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CardEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.CardId != id)
            {
                ModelState.AddModelError("", "It appears that wild card doesn't exist!");
                return View(model);
            }
            var svc = CreateCardService();
            if (svc.UpdateCard(model))
            {
                TempData["Save Result"] = "Your wild card was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your wild card could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateCardService();
            var model = svc.GetCardById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCard(int id)
        {
            var svc = CreateCardService();
            svc.DeleteCard(id);
            TempData["SaveResult"] = "Your wild card was deleted";
            return RedirectToAction("Index");
        }

        private CardService CreateCardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CardService(userId);
            return service;
        }
    }
}