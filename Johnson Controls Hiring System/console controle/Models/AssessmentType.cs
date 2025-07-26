using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace console_controle.Models
{
    public class AssessmentType
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AssessmentValueId { get; set; }

        public virtual ICollection<AssessmentValue> AssessmentValues { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
    }
    }
