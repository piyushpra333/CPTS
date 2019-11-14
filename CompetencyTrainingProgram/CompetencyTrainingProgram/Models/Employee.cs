using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetencyTrainingProgram.Models
{
    public class Employee
    {
        [Key]
        [RegularExpression(@"^[0-9]{1,6}$", ErrorMessage = "Only Numbers are allowed from 1 to 6 digit.")]
        public int EmpID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{1,30}$", ErrorMessage = "Only Alphabets are allowed upto 30 Characters.")]
        public string Name { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_]{6,15}$", ErrorMessage = "Only Alphabets,Numbers and underscore are allowed and must have length from 6 to 15")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_]{6,15}$", ErrorMessage = "Only Alphabets,Numbers and underscore are allowed and must have length from 6 to 15")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public DateTime DateOfCreation { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<Training> Training { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }

    }
}