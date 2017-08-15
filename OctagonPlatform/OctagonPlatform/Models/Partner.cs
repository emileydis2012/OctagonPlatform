namespace OctagonPlatform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partner")]
    public partial class Partner
    {
        
        public Partner()
        {
            AspNetUsers = new HashSet<AspNetUser>();
            logoes = new HashSet<Logo>();
            partnersContacts = new HashSet<PartnersContact>();           
            terminals = new HashSet<Terminal>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string businessName { get; set; }

        public string address1 { get; set; }

        public string address2 { get; set; }

        public int? regionId { get; set; }

        [Required]
        [StringLength(50)]
        public string status { get; set; }

        public int parentId { get; set; }

        public string settles { get; set; }

        public string splitBy { get; set; }

        public string email { get; set; }

        public string workPhone { get; set; }

        public string mobile { get; set; }

        public string fax { get; set; }

        public string webSite { get; set; }   
		
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

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }

        public virtual ICollection<logo> logoes { get; set; }

       public virtual ICollection<partnersContact> partnersContacts { get; set; }     

        public virtual Partner parent { get; set; }

        public virtual Region region { get; set; }

        public virtual ICollection<terminal> terminals { get; set; }
    }
}
