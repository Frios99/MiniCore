using System.ComponentModel.DataAnnotations;

namespace MiniCore_Francis.Models
{
    public class User
    {
        [Display(Name = "Usuario ID")]
        public int UserID { get; set; }
        [Display(Name = "Nombre Apellido")]
        public string Fullname { get; set; }
    }
}
