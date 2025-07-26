namespace console_controle.Models
{
    public class CandidateEvaluationViewModel
    {



        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public DateTime InterviewDate { get; set; }
        public int AssessmentTypeId { get; set; }
        public string HiringManager { get; set; }
        public int ResultId { get; set; }
        public int CandidateId { get; set; }
        public int AssessmentResultId { get; set; }
        public int CandidateAssessmentResultId { get; set; }

        public Candidate Candidate { get; set; }
        public CandidateAssessmentResult Result { get; set; }
        public CandidateAssessmentResult AssessmentResult { get; set; }
        public CandidateAssessmentResult CandidateAssessmentResult { get; set; }
    }
}
