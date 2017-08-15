using OctagonPlatform.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace OctagonPlatform.Models
{
    public class User:ISoftDeleted, IAuditEntity, IUser
    {
        //Implementation Here
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "")]
        public string  UserName { get; set; }

        [Required]
        [StringLength(8)]
        [Display (Name = "")]
        public string Password { get; set; }    

        public bool? Deleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}