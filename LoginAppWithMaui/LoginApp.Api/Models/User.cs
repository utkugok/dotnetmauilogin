using System.ComponentModel.DataAnnotations;

namespace LoginApp.Api.Models
{
    public class User
    {
        [Key]
        public long UserID { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
