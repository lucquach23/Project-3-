namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public decimal? Price { get; set; }
            //public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public bool? IncludeVAT { get; set; }

        [StringLength(10)]
        public string Quantity { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }

        public int? SupplierID { get; set; }

        [StringLength(350)]
        public string Processor { get; set; }

        [StringLength(350)]
        public string OperatingSystem { get; set; }

        [StringLength(310)]
        public string Memory { get; set; }

        [StringLength(350)]
        public string Screen { get; set; }

        [StringLength(350)]
        public string Graphics { get; set; }

        [StringLength(350)]
        public string Storage { get; set; }

        [StringLength(350)]
        public string Keyboard { get; set; }

        [StringLength(350)]
        public string MemoryCardReader { get; set; }

        [StringLength(350)]
        public string WebCam { get; set; }

        [StringLength(350)]
        public string Display { get; set; }

        [StringLength(350)]
        public string Sound { get; set; }

        [StringLength(350)]
        public string Pin { get; set; }

        [StringLength(350)]
        public string Adapter { get; set; }

        [StringLength(350)]
        public string Size { get; set; }

        [StringLength(350)]
        public string Mass { get; set; }

        [StringLength(50)]
        public string Security { get; set; }
    }
}
