namespace console_controle.Models
{
    public class CandidateAssessmentResult
    {

        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int TotalScore { get; set; }
        public DateTime DateSubmitted { get; set; }

        public string? Comment { get; set; }

        public List<string>? Opportunities { get; set; }
        public List<string>? Strengths { get; set; }
        public List<string>? Weaknesses { get; set; }
        public List<string>? Threats { get; set; }

        // الربط مع المرشح
        public virtual Candidate Candidate { get; set; }


       
       
    }

}

