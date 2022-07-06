using System.ComponentModel.DataAnnotations;

namespace MiniCore_Francis.Models
{
    public class Pass
    {
        [Display(Name = "Pase ID")]
        public int PassID { get; set; }
        [Display(Name = "Tipo")]
        public string Type { get; set; }
        [Display(Name = "Cupo")]
        public int Quota { get; set; }
        [Display(Name = "Pases")]
        public int Passes { get; set; }
        [Display(Name = "Costo")]
        public decimal Cost { get; set; }
        [Display(Name = "Fecha Compra")]
        public DateTime PurchaseDate { get; set; }
    }
}
