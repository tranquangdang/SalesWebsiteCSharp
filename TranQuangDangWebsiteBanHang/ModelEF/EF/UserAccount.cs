namespace ModelEF.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string Status { get; set; }
    }
}
