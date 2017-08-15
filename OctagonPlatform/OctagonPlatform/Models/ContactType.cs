namespace OctagonPlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactType")]
    public partial class ContactType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int? contactId { get; set; }

        public int? regionId { get; set; }

        public DateTime? created_at { get; set; }

        [StringLength(450)]
        public string created_by { get; set; }

        public bool? deleted { get; set; }

        public DateTime? deleted_at { get; set; }

        [StringLength(450)]
        public string deleted_By { get; set; }

        public DateTime? updated_at { get; set; }

        [StringLength(450)]
        public string updated_by { get; set; }

        public virtual PartnersContact partnersContact { get; set; }
    }
}
