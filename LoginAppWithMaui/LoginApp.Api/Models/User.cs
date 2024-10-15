using Microsoft.AspNetCore.Identity;

namespace LoginApp.Api.Models
{
    public class User : IdentityUser
    {
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastUpdatedTimestamp { get; set; }
    }
}
