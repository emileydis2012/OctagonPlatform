namespace OctagonPlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	[Table("PartnersContact")]
    public partial class PartnersContact
    {
       public PartnersContact()
        {
            contactTypes = new HashSet<ContactType>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string description { get; set; }

        public string address1 { get; set; }

        public string address2 { get; set; }

        [StringLength(50)]
        public string zip { get; set; }

        public int? partnerId { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactType> contactTypes { get; set; }

        public virtual Partner partner { get; set; }

        public virtual Region region { get; set; }
    }
}
