using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompetencyTrainingProgram.Models
{
    public class Answer
    {
        [Key]
        [RegularExpression(@"^[0-9]{1,6}$", ErrorMessage = "Only Numbers are allowed from 1 to 6 digit.")]
        public int AnswerID { get; set; }

        public string AnsDescription { get; set; }

        public int Score { get; set; }

    }
}