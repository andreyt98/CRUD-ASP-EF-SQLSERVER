using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        

        [Required(ErrorMessage = "this field cannot be empty")]
        public string Name { get; set; }


        [Required(ErrorMessage = "this field cannot be empty")]
        public string Email { get; set; }
        

        [Required(ErrorMessage = "this field cannot be empty")]
        public string Password { get; set; }


        public DateTime CreatedDate { get; set; }
    }
}