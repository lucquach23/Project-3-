namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        public int? Tuoi { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Sdt { get; set; }
    }
}
