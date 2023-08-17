using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class LoginVM
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        public string User { get; set; }

        [Required(ErrorMessage = "El password es requerido")]
        public string Password { get; set; }
    }
}
