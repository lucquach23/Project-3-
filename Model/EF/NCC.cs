namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NCC")]
    public partial class NCC
    {
        public int ID { get; set; }

        [StringLength(350)]
        public string Name { get; set; }

        [StringLength(350)]
        public string Address { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public int? TransactionCount { get; set; }
    }
}
