using System.ComponentModel.DataAnnotations;

namespace AuthenticationTestApp.Models
{
    public class InputLogInModel
    {
        [Required]
        [StringLength(19)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
