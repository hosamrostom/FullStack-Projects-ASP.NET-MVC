using System;
 using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using console_controle.Models;
    using Microsoft.AspNetCore.Mvc;
    using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
    using Microsoft.EntityFrameworkCore;
    using console_controle.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.CodeDom;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace console_controle.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _host;
        private readonly Data.AppDbContext _db;

        public HomeController(AppDbContext db, IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }


        [Authorize(Policy = "RequireHiringManagerRole")]
        public IActionResult Candidate()
        {
            var candidates = _db.Candidates.Include(c => c.HiringManager).ToList();
            return View(candidates);
        }
        [Authorize(Policy = "RequireHiringManagerRole")]
        public IActionResult Recruitment_empty()
        {
            return View();
        }
        [Authorize(Policy = "RequireHiringManagerRole")]
        public IActionResult home()
        {
            return View();
        }

        [Authorize(Policy = "RequireHiringManagerRole")]
        public ActionResult LoadPartial()
        {
            return PartialView("_MyPartialView");
        }
 






        public async Task<IActionResult> _MyPartialView(int? candidateId)
        {
            // جلب قائمة المرشحين
            ViewBag.Candidates = new SelectList(await _db.Candidates.ToListAsync(), "Id", "Name");

            // إذا لم يتم اختيار أي مرشح، لا تعرض بيانات
            if (candidateId == null)
            {
                return View(new List<CandidateAssessmentResult>());
            }

            // جلب التقييمات الخاصة بالمرشح المحدد
            var results = await _db.CandidateAssessmentResults
                .Where(r => r.CandidateId == candidateId)
                .ToListAsync();

            return View(results);
        }


        [Authorize(Policy = "RequireHiringManagerRole")]
        public IActionResult CandidatesList()
        {
            var candidates = _db.Candidates
                .Include(c => c.HiringManager)
                .Include(c => c.AssessmentType) // هنا الإصلاح
                .ToList();

            return View(candidates);
        }

         
        public async Task<IActionResult> AssessmentResults(int? candidateId)
        {
            // جلب قائمة المرشحين
            ViewBag.Candidates = new SelectList(await _db.Candidates.ToListAsync(), "Id", "Name");

            // إذا لم يتم اختيار أي مرشح، لا تعرض بيانات
            if (candidateId == null)
            {
                return View(new List<CandidateAssessmentResult>());
            }

            // جلب التقييمات الخاصة بالمرشح المحدد
            var results = await _db.CandidateAssessmentResults
                .Where(r => r.CandidateId == candidateId)
                .ToListAsync();

            return View(results);
        }
        [Authorize(Policy = "RequireHiringManagerRole")]
        public IActionResult CompetencyBarChart()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetCompetencyData(int candidateId)
        {
            var candidate = _db.Candidates
                .Include(c => c.AssessmentType)
                .ThenInclude(at => at.AssessmentValues)
                .FirstOrDefault(c => c.Id == candidateId);

            if (candidate == null || candidate.AssessmentType == null)
            {
                return Json(new { success = false, message = "Candidate not found" });
            }

            var assessmentValues = candidate.AssessmentType.AssessmentValues
                .Select(av => new { name = av.Value, value = av.Id }) // تعديل حسب القيم الحقيقية
                .ToList();

            return Json(assessmentValues);
        }
        [Authorize(Policy = "RequireHiringManagerRole")]

        [HttpGet]
        [HttpPost]
        public IActionResult SubmitAssessment(int candidateId, string? comment)
        {
            // جلب الكيان المرشح (Candidate) من قاعدة البيانات
            var candidate = _db.Candidates.FirstOrDefault(c => c.Id == candidateId);
            if (candidate == null)
            {
                return NotFound("Candidate not found.");
            }



            


            // جلب القيم المرتبطة بالتقييم
            var assessmentValues = _db.AssessmentValues
                .Include(av => av.Question)
                .Where(av => av.AssessmentTypeId == candidate.AssessmentTypeId)
                .ToList();

            if (Request.Method == "GET")
            {
                // عرض البيانات في View للمرة الأولى
                var model = new SubmitAssessmentViewModel
                {
                    Candidate = candidate,
                    AssessmentValues = assessmentValues
                };
                return View(model);
            }

            // POST: معالجة البيانات
            int totalScore = 0;
            List<string> strengths = new List<string>();
            List<string> weaknesses = new List<string>();
            List<string> opportunities = new List<string>();
            List<string> threats = new List<string>();
            

            foreach (var assessmentValue in assessmentValues)
            {
                string inputName = $"assessment_{assessmentValue.Id}";
                string selectedValue = Request.Form[inputName];

                if (int.TryParse(selectedValue, out int score))
                {
                    totalScore += score;

                    // تصنيف النقاط حسب الدرجة
                    if (score == 1)
                    {
                        threats.Add(assessmentValue.Value ?? "Unknown Question");
                    }
                    else if (score == 2)
                    {
                        weaknesses.Add(assessmentValue.Value ?? "Unknown Question");
                    }
                    else if (score == 3)
                    {
                        opportunities.Add(assessmentValue.Value ?? "Unknown Question");
                    }
                    else if (score == 4)
                    {
                        strengths.Add(assessmentValue.Value ?? "Unknown Question");
                    }
                }
                else
                {
                    ModelState.AddModelError(inputName, "Invalid score value.");
                }
            }

            if (!ModelState.IsValid)
            {
                var model = new SubmitAssessmentViewModel
                {
                    Candidate = candidate,
                    AssessmentValues = assessmentValues
                };
                return View(model);
            }

            // إنشاء كائن CandidateAssessmentResult لتخزين النتيجة
            var result = new CandidateAssessmentResult
            {
                CandidateId = candidateId,
                TotalScore = totalScore,
                DateSubmitted = DateTime.Now,
                Strengths = strengths,
                Weaknesses =weaknesses,
                Opportunities =  opportunities , 
                Threats =  threats,
                Comment = comment,   

            };

            _db.CandidateAssessmentResults.Add(result);
            _db.SaveChanges();



            return RedirectToAction("Candidate", new { candidateId = candidateId });
        
        
        }


        [HttpPost]
        public IActionResult SaveAssessmentResult(CandidateAssessmentResult model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    model.DateSubmitted = DateTime.Now; // Set submission date
                    context.CandidateAssessmentResults.Add(model);
                    context.SaveChanges();
                }

                ViewBag.Message = "Assessment result saved successfully!";
                return RedirectToAction("Success"); // Redirect to a success page or return the same view
            }

            ViewBag.Message = "Failed to save assessment result. Please try again.";
            return View(model);
        }

        //------------------------------------------------------------------------------------------
        // عرض جميع المرشحين
        [Authorize(Policy = "RequireRecruiterRole")]
        public async Task<IActionResult> Index()
        {
            var candidates = await _db.Candidates
                .Include(c => c.HiringManager)
                .Include(c => c.AssessmentType)
                .ToListAsync();
            return View(candidates);
        }

        // عرض تفاصيل مرشح معين
        [Authorize(Policy = "RequireRecruiterRole")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _db.Candidates
                .Include(c => c.HiringManager)
                .Include(c => c.AssessmentType)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }


        // حذف مرشح
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _db.Candidates.FirstOrDefaultAsync(c => c.Id == id);

            if (candidate != null)
            {
                _db.Candidates.Remove(candidate);
                await _db.SaveChangesAsync();
            }
            else
            {
                return NotFound("Candidate not found.");
            }

            return RedirectToAction(nameof(Index));
        }

        // التحقق من وجود المرشح
        private bool CandidateExists(int id)
        {
            return _db.Candidates.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult CreateHiringManager()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHiringManager(HiringManager hiringManager)
        {
            if (ModelState.IsValid)
            {
                _db.HiringManagers.Add(hiringManager);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hiringManager);
        }


        //----------------------------------------------------------------------------------------------------------



        // GET: Create Candidate
        // Remove the instance-level field if it's not needed
        // private List<AssessmentType> assessmentTypes; 

        // Example action for the Create view
        // GET: Create Candidate
        public IActionResult Create()
        {
            // Fetch the list of assessment types
            List<AssessmentType> assessmentTypes = GetAssessmentTypes();

            // Convert to SelectListItem for the dropdown
            ViewData["AssessmentTypes"] = assessmentTypes.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            return View();
        }

        private List<AssessmentType> GetAssessmentTypes()
        {
            // This should be replaced with your actual data fetching logic
            return new List<AssessmentType>
        {
            new AssessmentType { Id = 1, Name = "Individual Contributor - Support" },
            new AssessmentType { Id = 2, Name = "Individual Contributor - Professional" },
            new AssessmentType { Id = 3, Name = "Middle Management" },
            new AssessmentType { Id = 4, Name = "Top Management" }
        };
        }

        // POST: Create Candidate (handles both Hiring Manager and Candidate)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidate model, string action, string hiringManagerName, string hiringManagerEmail)
        {
            if (action == "saveHiringManager")
            {
                //// Check that the email is not null or empty
                //if (string.IsNullOrEmpty(hiringManagerEmail))
                //{
                //    ModelState.AddModelError("HiringManager.Email", "Email is required for Hiring Manager.");
                //    return View(model); // Return to the same view with the validation error
                //}

                if (string.IsNullOrEmpty(hiringManagerEmail))
                {
                    hiringManagerEmail = "default@example.com"; // Set a default email if necessary
                }
                // Save the Hiring Manager's data
                HiringManager newHiringManager = new HiringManager
                {
                    Name = hiringManagerName,
                    Email = hiringManagerEmail
                };

                _db.HiringManagers.Add(newHiringManager);
                await _db.SaveChangesAsync();

                // Optionally, set the HiringManagerId to the model
                model.HiringManagerId = newHiringManager.Id;
            }
            else if (action == "saveCandidate")
            {
                // Save the Candidate's data with the associated HiringManagerId
                model.InterviewDate = DateTime.Now.AddDays(1);  // Set interview date
                _db.Candidates.Add(model);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");  // Redirect to the list page or wherever necessary
        }

        
        public class ApplicationUser : IdentityUser
        {
            public class SeedRoles
            {
                public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
                {
                    var roleNames = new[] { "Manager", "Recruiter" };
                    foreach (var roleName in roleNames)
                    {
                        var roleExist = await roleManager.RoleExistsAsync(roleName);
                        if (!roleExist)
                        {
                            var role = new IdentityRole(roleName);
                            await roleManager.CreateAsync(role);
                        }
                    }
                }
            }
        }
       




        // Controller action to get the competency details based on AssessmentValueId
        // Method to get competency details based on AssessmentValueId
        public JsonResult GetCompetencyDetails(int assessmentValueId)
        {
            // Fetch the AssessmentValue by its ID
            var assessmentValue = _db.AssessmentValues
                .Where(av => av.Id == assessmentValueId)
                .Include(av => av.Question)  // Including the associated Question
                .FirstOrDefault();

            if (assessmentValue == null)
            {
                return Json(new { success = false, message = "Assessment value not found." });
            }

            // Now fetch the Competency associated with the same QuestionId
            var competency = _db.Questions
                .Where(c => c.Id == assessmentValue.QuestionId)
                .Select(c => new
                {
                    Question = c.TextQ,  // Assuming 'Text' is the question text
                    SubQuestion = c.SubQuestion,
                    Level1_2 = c.Level1_2,
                    Level3 = c.Level3,
                    Level4 = c.Level4
                })
                .FirstOrDefault();

            if (competency == null)
            {
                return Json(new { success = false, message = "Competency details not found." });
            }

            return Json(new
            {
                success = true,
                question = competency.Question,
                subQuestion = competency.SubQuestion,
                level1_2 = competency.Level1_2,
                level3 = competency.Level3,
                level4 = competency.Level4
         
            });
       
        
        
        
        }







    }
}



