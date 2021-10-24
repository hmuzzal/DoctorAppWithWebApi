using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace DhakaChoiceApiApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public override string PhoneNumber { get; set; }

    }
}
