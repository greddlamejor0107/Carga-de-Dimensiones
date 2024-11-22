
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{

    [Table("DimShipeers")]
    public class DimShippers
    {
        [Key]
        public int ShipperID { get; set; }
        public string ShipperName { get; set; }
        public string? Phone {  get; set; }

    }
}
