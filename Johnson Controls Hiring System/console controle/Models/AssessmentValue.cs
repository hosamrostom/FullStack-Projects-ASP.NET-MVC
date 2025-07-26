using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace console_controle.Models
{
    public class AssessmentValue
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public int? QuestionId { get; set; }
        [ForeignKey("AssessmentType")]
        public int AssessmentTypeId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public virtual AssessmentType AssessmentType { get; set; }

    }
}
