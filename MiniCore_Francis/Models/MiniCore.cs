using System.ComponentModel.DataAnnotations;

namespace MiniCore_Francis.Models
{
    public class MiniCore
    {
        [Display(Name = "Id")]
        public int MiniCoreID { get; set; }
        [Display(Name = "Nombre Apellido")]
        public string Fullname { get; set; }
        [Display(Name = "Pase Tipo")]
        public string Type { get; set; }
        [Display(Name = "Pases Actuales")]
        public int CurrentPasses { get; set; }
        [Display(Name = "Pases Usados")]
        public int UsedPasses { get; set; }
        [Display(Name = "Fecha Compra")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Fecha Actual")]
        public DateTime CurrentDate { get; set; }
        [Display(Name = "Fecha Expiración Tentativa")]
        public DateTime ExpirationDate { get; set; }
    }
}