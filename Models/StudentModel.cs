using System.ComponentModel.DataAnnotations;

namespace workshop.Models
    {
    public class StudentModel
        {
        [Key]
        public int student_id { get; set; }

        [Required(ErrorMessage ="enter the name ")]//validation with data annotation
        public required string studentname { get; set; }//validation withut data annotation , wont throw error if null but will throw error if not assigned value

        [Required(ErrorMessage ="enter the branch ")]//validation with data annotation
        public string? studentbranch { get; set; }

        [EmailAddress(ErrorMessage ="enter valid email")]//validation with data annotation
        public string?  student_email { get; set; }

        [Required(ErrorMessage ="enter the DateOFbirth ")]//validation with data annotation
        public DateOnly DOB { get; set; }

        [Required(ErrorMessage ="enter city")]
        public string? city { get; set; }
        }
    }
