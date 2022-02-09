using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Data
{
    public class Deck
    {
        public int DeckId { get; set; }
        public string DeckName { get; set; }
        public virtual List<Card> Cards { get; set; }
    }
}
