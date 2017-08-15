using System;
using System.ComponentModel.DataAnnotations;

namespace OctagonPlatform.Helpers
{
    internal interface IAuditEntity
    {
        DateTime? CreatedAt { get; set; }

        [StringLength(450)]
        string CreatedBy { get; set; }


        DateTime? DeletedAt { get; set; }

        [StringLength(450)]
        string DeletedBy { get; set; }


        DateTime? UpdatedAt { get; set; }

        [StringLength(450)]
        string UpdatedBy { get; set; }
    }
}
