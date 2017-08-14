using OctagonPlatform.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace OctagonPlatform.Models
{
    public class AuditEntity:IAuditEntity
    {
        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        [StringLength(450)]
        public string CreatedBy { get; set; }


        public DateTime? DeletedAt { get; set; }

        [StringLength(450)]
        public string DeletedBy { get; set; }


        public DateTime? UpdatedAt { get; set; }

        [StringLength(450)]
        public string UpdatedBy { get; set; }
    }
}