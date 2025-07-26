using Microsoft.AspNetCore.Mvc.Rendering;

namespace console_controle.Models
{
    public class EditCandidateHiringManagerViewModel
    {
        public Candidate Candidate { get; set; }
        public HiringManager HiringManager { get; set; }
        public SelectList AssessmentTypes { get; set; }
        public SelectList HiringManagers { get; set; }
    }

}
