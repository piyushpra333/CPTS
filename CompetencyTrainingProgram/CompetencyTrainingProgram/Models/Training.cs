using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetencyTrainingProgram.Models
{
    public class Training
    {
        [Key]
        [RegularExpression(@"^[0-9]{1,6}$", ErrorMessage = "Only Numbers are allowed from 1 to 6 digit.")]
        public int TrainingID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{1,30}$", ErrorMessage = "Only Alphabets are allowed upto 30 Characters.")]
        public string TrainingName { get; set; }

        public string Discription { get; set; }

        public DateTime DateOfTraining { get; set; }

        [Required]
        public string Status { get; set; }

        

        public virtual ICollection<Question> Question { get; set; }
    }
}