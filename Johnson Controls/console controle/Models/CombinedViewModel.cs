namespace console_controle.Models
{
    public class CombinedViewModel
    {
        public IEnumerable<AssessmentType> AssessmentTypes { get; set; }
        public IEnumerable<AssessmentValue> AssessmentValues { get; set; }
        public IEnumerable<Candidate> Candidates { get; set; }
        public IEnumerable<CandidateAssessmentResult> CandidateAssessmentResults { get; set; }
        public IEnumerable<HiringManager> HiringManagers { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public SubmitAssessmentViewModel SubmitAssessment { get; set; } // إذا كنت تريد تضمين الـ SubmitAssessment أيضًا
    }
}