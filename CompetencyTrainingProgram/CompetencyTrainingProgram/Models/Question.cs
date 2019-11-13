using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetencyTrainingProgram.Models
{
    public class Question
    {
        [Key]
        [RegularExpression(@"^[0-9]{1,6}$", ErrorMessage = "Only Numbers are allowed from 1 to 6 digit.")]
        public int QuestionID { get; set; }
       
        public string QueDescription { get; set; }

        public int Duration { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }

    }
}