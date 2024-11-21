

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("FactClienteAtendido", Schema ="dbo")]
    public class FactClienteAtendido
    {
        [Key]
        public int ClienteAtendidoId { get; set; }
        public int EmployeeKey { get; set; }
        public int? TotalClientes { get; set; }
    }
}
