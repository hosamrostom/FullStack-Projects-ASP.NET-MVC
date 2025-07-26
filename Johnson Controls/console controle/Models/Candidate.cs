using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace console_controle.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public DateTime InterviewDate { get; set; }

        public int? AssessmentTypeId { get; set; }
        [ForeignKey("HiringManager")]
        public int HiringManagerId { get; set; }
        public virtual List<CandidateAssessmentResult> CandidateAssessmentResults { get; set; } = new();

        public virtual HiringManager HiringManager { get; set; }
        public virtual AssessmentType AssessmentType { get; set; }
    }
}
