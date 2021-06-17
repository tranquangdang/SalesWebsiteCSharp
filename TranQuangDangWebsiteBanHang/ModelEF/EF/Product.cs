namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int CategoryNo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        [Required]
        public int UnitCost { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Status { get; set; }

        public virtual Category Category { get; set; }
    }
}
