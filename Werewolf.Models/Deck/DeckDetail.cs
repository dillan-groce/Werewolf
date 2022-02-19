using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Models.Deck
{
    public class DeckDetail
    {
        [Key]
        public int DeckId { get; set; }
        public string DeckName { get; set; }
    }
}
