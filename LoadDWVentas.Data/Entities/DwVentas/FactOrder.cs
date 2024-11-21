

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("FactOrders",Schema ="dbo")]
    public class FactOrder
    {
        [Key]
        public int OrderNumber { get; set; }

        public int DateKey { get; set; }

        public int ProductKey { get; set; }

        public int EmployeeKey { get; set; }

        public int Shipper { get; set; }

        public int CustomerKey { get; set; }

        public string Country { get; set; }

        public decimal TotalVentas { get; set; }

        public int CantidadVentas { get; set; }
    }
}
