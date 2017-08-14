using System;

namespace OctagonPlatform.Helpers
{
    internal interface  IAuditEntity
    {
        int Id { get; set; }

        DateTime? CreatedAt { get; set; }

        string CreatedBy { get; set; }

        DateTime? DeletedAt { get; set; }

        string DeletedBy { get; set; }


        DateTime? UpdatedAt { get; set; }

        string UpdatedBy { get; set; }
    }
}
