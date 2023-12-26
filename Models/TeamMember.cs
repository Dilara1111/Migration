using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }

        public IFormFile Photo { get; set; }
        public string PhotoName { get; set; }
        

    }
}
