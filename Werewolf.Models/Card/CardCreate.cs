using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Models.Card
{
    public class CardCreate
    {
        [Required]
        [MaxLength(20, ErrorMessage ="Card name can only contain 20 characters.")]
        public string RoleName { get; set; }
        [Required]
        [MinLength(10, ErrorMessage ="Your card's power must be stronger than 10 characters.")]
        public string Power { get; set; }
    }
}
