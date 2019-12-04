namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderImport")]
    public partial class OrderImport
    {
        public int ID { get; set; }

        public int? IdSupplier { get; set; }

        public long? IdLaptop { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public DateTime? DateImport { get; set; }

        [Column("IdIdEmployees")]
        public long? Id__IdEmployees { get; set; }
    }
}
