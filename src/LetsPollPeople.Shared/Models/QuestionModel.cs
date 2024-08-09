using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.Shared.Models
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Required *")]
        [MaxLength(250)]
        public string QuestionText { get; set; }

        public int UserId { get; set; }

        public List<OptionModel> Option { get; set; }

        public QuestionModel() 
        {
            Option = new List<OptionModel>();
        }
    }
}
