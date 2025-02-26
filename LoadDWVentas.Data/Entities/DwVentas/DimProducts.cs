﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("DimProducts")]
    public class DimProducts
    {
        [Key]
        public int ProductID { get; set; } 
        public string ProductName { get; set; } 
        public int? SupplierID { get; set; } 
        public int? CategoryID { get; set; } 
        public string? QuantityPerUnit { get; set; } 
        public decimal? UnitPrice { get; set; } 
        public short? UnitsInStock { get; set; } 
        public short? UnitsOnOrder { get; set; } 
        public short? ReorderLevel { get; set; } 
        public bool? Discontinued { get; set; } 
    }

}
