using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback_system.Model
{
    public class Feedback
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; } // Optional

        [Required]
        public string? Email { get; set; } // Optional

        [Required]
        public string? Message { get; set; }

        [Required]
        public int Rating { get; set; } // Optional
    }

}
