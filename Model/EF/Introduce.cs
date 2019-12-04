namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Introduce")]
    public partial class Introduce
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
