using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werewolf.Data;
using Werewolf.Models.Card;

namespace Werewolf.Service
{
    public class CardService
    {
        private readonly Guid _userId;

        public CardService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCard(CardCreate model)
        {
            var entity = new Card()
            {
                Creator = _userId,
                RoleName = model.RoleName,
                Power = model.Power
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CardListItem> GetCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cards
                    .Select(
                        e =>
                        new CardListItem
                        {
                            CardId = e.CardId,
                            RoleName = e.RoleName
                        }
                        );
                return query.ToArray();
            }
        }

        public CardDetail GetCardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cards
                    .Single(e => e.CardId == id);
                return
                    new CardDetail
                    {
                        CardId = entity.CardId,
                        RoleName = entity.RoleName,
                        Power = entity.Power
                    };
            }
        }

        public bool UpdateCard(CardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cards
                        .Single(e => e.CardId == model.CardId && e.Creator == _userId);

                entity.RoleName = model.RoleName;
                entity.Power = model.Power;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCard(int cardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cards
                    .Single(e => e.CardId == cardId && e.Creator == _userId);

                ctx.Cards.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
