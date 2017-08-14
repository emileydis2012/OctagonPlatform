using System.ComponentModel.DataAnnotations;

namespace OctagonPlatform.Helpers
{
    internal interface IUser
    {
        [Required]
        [StringLength(8)]
        string UserName { get; set; }
        
        [Required]
        [StringLength(8)]
        string Password { get; set; }
    }
}
