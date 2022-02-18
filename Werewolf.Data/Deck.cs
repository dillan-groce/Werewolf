using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Data
{
    public class Deck
    {
        [Key]
        public int DeckId { get; set; }
        public string DeckName { get; set; }
        public virtual List<Card> Cards { get; set; }
    }
}
