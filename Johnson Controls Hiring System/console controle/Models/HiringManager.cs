using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace console_controle.Models
{
    public class HiringManager
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }

    }
}
