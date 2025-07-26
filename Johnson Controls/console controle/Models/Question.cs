using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace console_controle.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string TextQ { get; set; }
        public string SubQuestion { get; set; }

        public string? Level1_2 { get; set; } // Check if this is nullable or required

        public string? Level3 { get; set; }

        public string? Level4 { get; set; }


        public virtual ICollection<AssessmentValue> AssessmentValues { get; set; }
    }
}
