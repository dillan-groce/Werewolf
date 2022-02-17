using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Models.Card
{
    public class CardDetail
    {
        [Key]
        public int CardId { get; set; }
        public string RoleName { get; set; }
        public string Power { get; set; }
    }
}
