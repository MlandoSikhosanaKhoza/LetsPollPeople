using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.Shared.Models
{
    public class OptionModel
    {
        public int OptionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string OptionText { get; set; }

        public int QuestionId { get; set; }

        public int NumberOfVotes {  get; set; }

        public OptionModel() { 
            NumberOfVotes = 0;
        }
    }
}
