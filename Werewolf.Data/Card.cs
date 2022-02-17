using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Data
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string RoleName { get; set; }
        public string Power { get; set; }
        public Guid Creator { get; set; }
    }
}
