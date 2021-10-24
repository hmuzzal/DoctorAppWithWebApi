using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DhakaChoiceApiApp.DTOs
{
    public class ApplicationUserDto
    {
        public string UserName { get; set; }

        [NotMapped]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
