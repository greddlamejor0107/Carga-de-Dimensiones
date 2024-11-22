using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("DimCstegories")]
    public class DimCategories
    {
        [Key]

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }

    }
}
