namespace console_controle.Models
{
    public class SubmitAssessmentViewModel
    {

        //public int AssessmentValueId { get; set; }
        //public string AssessmentValue { get; set; }
        //public int QuestionId { get; set; }
        //public string QuestionText { get; set; }
        public Candidate Candidate { get; set; }
        public IEnumerable<AssessmentValue> AssessmentValues { get; set; }
        public IEnumerable<Question> questions { get; set; }
        public CandidateAssessmentResult Result { get; set; }

        
    }
}
