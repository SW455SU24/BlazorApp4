using System.ComponentModel.DataAnnotations;

namespace BlazorApp4.Data
{
    public class Meeting
    {
        public int Id { get; set; }

        [Required]
        [Key]
        public Room Room { get; set; }
        public string? Name { get; set; }
        public DateTime timeDate { get; set; }
        public List<ApplicationUser> Attendees { get; set; }

    }
}
