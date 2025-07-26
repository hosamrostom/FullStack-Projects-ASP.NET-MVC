using console_controle.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using static System.Collections.Specialized.BitVector32;
namespace console_controle.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {

            if (!await roleManager.RoleExistsAsync("Hiring Manager"))
            {
                await roleManager.CreateAsync(new IdentityRole("Hiring Manager"));
            }

            if (!await roleManager.RoleExistsAsync("Recruiter"))
            {
                await roleManager.CreateAsync(new IdentityRole("Recruiter"));
            }
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<HiringManager> HiringManagers { get; set; }
        public DbSet<AssessmentValue> AssessmentValues { get; set; }
        public DbSet<AssessmentType> AssessmentTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CandidateAssessmentResult> CandidateAssessmentResults { get; set; }
        public DbSet<CandidateEvaluationViewModel> CandidateEvaluationViewModels { get; set; }







        public void SaveCommentToDatabase(string comment)
        {
            using (var context = new AppDbContext())
            {
                var newResult = new CandidateAssessmentResult
                {
                    Comment = comment,
                };

                context.CandidateAssessmentResults.Add(newResult);
                context.SaveChanges();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                 .HasOne(c => c.HiringManager)
                 .WithMany(hm => hm.Candidates)
                 .HasForeignKey(c => c.HiringManagerId)
                 .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Candidate>()
       .HasOne(c => c.AssessmentType) // Assuming navigation property
       .WithMany(at => at.Candidates) // Assuming navigation property
       .HasForeignKey(c => c.AssessmentTypeId)
       .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Candidate>()
        .HasOne(c => c.AssessmentType) // Assuming navigation property exists
        .WithMany(at => at.Candidates) // Assuming navigation property exists
        .HasForeignKey(c => c.AssessmentTypeId)
        .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<AssessmentValue>()
            //  .HasOne(av => av.Grading)
            //  .WithMany(g => g.AssessmentValues)
            //  .HasForeignKey(av => av.GradingId)
            //  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssessmentValue>()
              .HasOne(av => av.Question)
              .WithMany(q => q.AssessmentValues)
              .HasForeignKey(av => av.QuestionId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssessmentValue>()
              .HasOne(av => av.AssessmentType)
              .WithMany(at => at.AssessmentValues)
              .HasForeignKey(av => av.AssessmentTypeId)
              .OnDelete(DeleteBehavior.Restrict);



            // خلي علاقة واحدة فقط فيها Cascade
            modelBuilder.Entity<CandidateEvaluationViewModel>()
                .HasOne(x => x.Result)
                .WithMany()
                .HasForeignKey(x => x.ResultId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CandidateEvaluationViewModel>()
                .HasOne(x => x.AssessmentResult)
                .WithMany()
                .HasForeignKey(x => x.AssessmentResultId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CandidateEvaluationViewModel>()
                .HasOne(x => x.CandidateAssessmentResult)
                .WithMany()
                .HasForeignKey(x => x.CandidateAssessmentResultId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CandidateEvaluationViewModel>()
                .HasOne(x => x.Candidate)
                .WithMany()
                .HasForeignKey(x => x.CandidateId)
                .OnDelete(DeleteBehavior.Restrict); // أو خليه Cascade لو حابب تحذف كل تقييمات المرشح معاه


            base.OnModelCreating(modelBuilder);



            base.OnModelCreating(modelBuilder);



        
    
            








            modelBuilder.Entity<AssessmentType>().HasData(
           new AssessmentType { Id = 1, Name = "Individual Contributor - Support" },
           new AssessmentType { Id = 2, Name = "Individual Contributor - Professional" },
           new AssessmentType { Id = 3, Name = "Middle Management" },
           new AssessmentType { Id = 4, Name = "Top Management" }
       );


            modelBuilder.Entity<AssessmentValue>().HasData(
    // Individual Contributor - Support
    new AssessmentValue { Id = 1, Value = "Technical Skills", AssessmentTypeId = 1, QuestionId = 1 },
    new AssessmentValue { Id = 2, Value = "Customer Orientation", AssessmentTypeId = 1, QuestionId = 2 },
    new AssessmentValue { Id = 3, Value = "Quality of Work", AssessmentTypeId = 1, QuestionId = 3 },
    new AssessmentValue { Id = 4, Value = "Execution Discipline", AssessmentTypeId = 1, QuestionId = 4 },
    new AssessmentValue { Id = 5, Value = "Communication Skills", AssessmentTypeId = 1, QuestionId = 5 },
    new AssessmentValue { Id = 6, Value = "Adaptability", AssessmentTypeId = 1, QuestionId = 6 },
    new AssessmentValue { Id = 7, Value = "Attention to Detail", AssessmentTypeId = 1, QuestionId = 7 },
    new AssessmentValue { Id = 8, Value = "Physical Stamina", AssessmentTypeId = 1, QuestionId = 8 },

    // Individual Contributor - Professional
    new AssessmentValue { Id = 9, Value = "Execution Discipline", AssessmentTypeId = 2, QuestionId = 9 },
    new AssessmentValue { Id = 10, Value = "Managing Work", AssessmentTypeId = 2, QuestionId = 10 },
    new AssessmentValue { Id = 11, Value = "Decision Making", AssessmentTypeId = 2, QuestionId = 11 },
    new AssessmentValue { Id = 12, Value = "Agility", AssessmentTypeId = 2, QuestionId = 12 },
    new AssessmentValue { Id = 13, Value = "Innovation", AssessmentTypeId = 2, QuestionId = 13 },
    new AssessmentValue { Id = 14, Value = "Influencing with Impact", AssessmentTypeId = 2, QuestionId = 14 },
    new AssessmentValue { Id = 15, Value = "Collaboration", AssessmentTypeId = 2, QuestionId = 15 },
    new AssessmentValue { Id = 16, Value = "Customer Orientation", AssessmentTypeId = 2, QuestionId = 16 },
    new AssessmentValue { Id = 17, Value = "English Proficiency", AssessmentTypeId = 2, QuestionId = 17 },
    new AssessmentValue { Id = 18, Value = "Strategic Thinking", AssessmentTypeId = 2, QuestionId = 18 },

    // Middle Management
    new AssessmentValue { Id = 19, Value = "Building an Effective Team", AssessmentTypeId = 3, QuestionId = 19 },
    new AssessmentValue { Id = 20, Value = "Coaching Others", AssessmentTypeId = 3, QuestionId = 20 },
    new AssessmentValue { Id = 21, Value = "Execution Discipline", AssessmentTypeId = 3, QuestionId = 21 },
    new AssessmentValue { Id = 22, Value = "Planning and Organizing", AssessmentTypeId = 3, QuestionId = 22 },
    new AssessmentValue { Id = 23, Value = "Business Acumen", AssessmentTypeId = 3, QuestionId = 23 },
    new AssessmentValue { Id = 24, Value = "English Proficiency", AssessmentTypeId = 3, QuestionId = 24 },

    // Top Management
    new AssessmentValue { Id = 25, Value = "Strategic Vision", AssessmentTypeId = 4, QuestionId = 25 },
    new AssessmentValue { Id = 26, Value = "Business Acumen", AssessmentTypeId = 4, QuestionId = 26 },
    new AssessmentValue { Id = 27, Value = "Leadership", AssessmentTypeId = 4, QuestionId = 27 },
    new AssessmentValue { Id = 28, Value = "Change Management", AssessmentTypeId = 4, QuestionId = 28 },
    new AssessmentValue { Id = 29, Value = "Decision Making", AssessmentTypeId = 4, QuestionId = 29 },
    new AssessmentValue { Id = 30, Value = "Innovation", AssessmentTypeId = 4, QuestionId = 30 },
    new AssessmentValue { Id = 31, Value = "Global Perspective", AssessmentTypeId = 4, QuestionId = 31 },
    new AssessmentValue { Id = 32, Value = "Stakeholder Management", AssessmentTypeId = 4, QuestionId = 32 }

    
);



                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Question>().HasData(
                    new Question
                    {
                        Id = 1,
                        //Value = "Technical Skills",
                        TextQ = "How do you ensure that your technical skills are continuously improving?",
                        SubQuestion = "Can you provide an example where your technical skills directly contributed to the success of a project?",
                        Level1_2 = "Lacks required technical skills; basic proficiency.",
                        Level3 = "Good technical skills with some proficiency.",
                        Level4 = "Strong technical skills and expertise."
                    },
                    new Question
                    {
                        Id = 2,
                        //Value = "Customer Orientation",
                        TextQ = "How do you ensure that customer needs are at the forefront of your work?",
                        SubQuestion = "Share an example where you went above and beyond to address a customer concern.",
                        Level1_2 = "No focus on customer satisfaction; basic understanding.",
                        Level3 = "Good understanding of customer needs and some focus on satisfaction.",
                        Level4 = "Strong focus on customer satisfaction."
                    },
                    new Question
                    {
                        Id = 3,
                        //Value = "Quality of Work",
                        TextQ = "How do you ensure that your work consistently meets quality standards?",
                        SubQuestion = "Can you describe a time when you identified an opportunity to improve the quality of a project or task?",
                        Level1_2 = "Poor quality of work; lack of attention to detail.",
                        Level3 = "Good quality of work with attention to detail.",
                        Level4 = "Strong quality of work and meticulous attention to detail."
                    },
                    new Question
                    {
                        Id = 4,
                        //Value = "Execution Discipline",
                        TextQ = "How do you ensure that you consistently meet deadlines for your tasks?",
                        SubQuestion = "Describe a time when you had to handle competing priorities. How did you manage it?",
                        Level1_2 = "Poor execution; missed deadlines.",
                        Level3 = "Good execution with most deadlines met.",
                        Level4 = "Strong execution and consistent on-time delivery."
                    },
                    new Question
                    {
                        Id = 5,
                        //Value = "Communication Skills",
                        TextQ = "How do you ensure clarity and professionalism in your communication?",
                        SubQuestion = "Can you provide an example of a time when effective communication helped resolve a misunderstanding?",
                        Level1_2 = "Poor communication skills; limited effectiveness.",
                        Level3 = "Good communication skills with some effectiveness.",
                        Level4 = "Strong communication skills that ensure clarity and understanding."
                    },
                    new Question
                    {
                        Id = 6,
                        //Value = "Adaptability",
                        TextQ = "How do you manage stress or uncertainty in dynamic environments?",
                        SubQuestion = "Can you describe a time when you successfully adapted to a new work culture or process?",
                        Level1_2 = "Resistant to change; basic adaptability.",
                        Level3 = "Good adaptability to changes.",
                        Level4 = "Strong adaptability and ability to thrive in changing environments."
                    },
                    new Question
                    {
                        Id = 7,
                        //Value = "Attention to Detail",
                        TextQ = "How do you ensure that you thoroughly review all aspects of your work before completion?",
                        SubQuestion = "Can you share an example where your attention to detail prevented a mistake?",
                        Level1_2 = "Poor attention to detail; many errors.",
                        Level3 = "Good attention to detail with few errors.",
                        Level4 = "Strong attention to detail and accuracy."
                    },
                    new Question
                    {
                        Id = 8,
                        //Value = "Physical Stamina",
                        TextQ = "How do you maintain your energy levels during long working hours or physically demanding tasks?",
                        SubQuestion = "Can you share a time when your physical stamina helped you meet a challenging work deadline?",
                        Level1_2 = "Lacks physical stamina; basic limitations.",
                        Level3 = "Good physical stamina to meet most demands.",
                        Level4 = "Strong physical stamina and ability to handle demanding tasks."
                    },
                    new Question
                    {
                        Id = 9,
                        //Value = "Execution Discipline (repeated)",
                        TextQ = "How do you ensure that you consistently meet deadlines for your tasks?",
                        SubQuestion = "Describe a time when you had to handle competing priorities. How did you manage it?",
                        Level1_2 = "Poor execution; missed deadlines.",
                        Level3 = "Good execution with most deadlines met.",
                        Level4 = "Strong execution and consistent on-time delivery."
                    },
                    new Question
                    {
                        Id = 10,
                        //Value = "Managing Work",
                        TextQ = "How do you organize your daily workload to ensure efficiency?",
                        SubQuestion = "What tools or techniques do you use to track progress and avoid delays?",
                        Level1_2 = "Struggles to manage workload; misses deadlines.",
                        Level3 = "Manages workload with some assistance; meets deadlines.",
                        Level4 = "Manages workload effectively, consistently meeting or exceeding expectations."
                    },
                    new Question
                    {
                        Id = 11,
                        //Value = "Decision Making",
                        TextQ = "Share an example where you had to make a decision with limited information. What steps did you take?",
                        SubQuestion = "How do you evaluate the potential risks and benefits of your decisions?",
                        Level1_2 = "Struggles to make decisions; limited risk assessment.",
                        Level3 = "Makes sound decisions with moderate risk assessment.",
                        Level4 = "Makes informed, well-analyzed decisions with excellent risk/benefit evaluation."
                    },
                    new Question
                    {
                        Id = 12,
                        //Value = "Agility",
                        TextQ = "Describe a situation where you had to quickly adapt to a major change at work. What was the outcome?",
                        SubQuestion = "How do you remain productive when faced with changing priorities?",
                        Level1_2 = "Struggles with change; slow to adapt.",
                        Level3 = "Adapts to changes with some effort.",
                        Level4 = "Demonstrates exceptional agility in adapting to new situations."
                    },
                    new Question
                    {
                        Id = 13,
                        //Value = "Innovation",
                        TextQ = "Have you suggested a new process or idea that improved team performance? What was it?",
                        SubQuestion = "How do you approach brainstorming or problem-solving?",
                        Level1_2 = "No culture of innovation; limited efforts.",
                        Level3 = "Some efforts to foster innovation.",
                        Level4 = "Strong culture of innovation that drives continuous improvement."
                    },
                    new Question
                    {
                        Id = 14,
                        //Value = "Influencing with Impact",
                        TextQ = "Can you provide an example of how you persuaded a colleague or stakeholder to adopt your approach?",
                        SubQuestion = "How do you adjust your communication style to influence others effectively?",
                        Level1_2 = "Limited influence over others.",
                        Level3 = "Good influence with moderate success.",
                        Level4 = "Highly effective at influencing others to adopt desired actions."
                    },
                    new Question
                    {
                        Id = 15,
                        //Value = "Collaboration",
                        TextQ = "How do you contribute to fostering a positive and collaborative team environment?",
                        SubQuestion = "Describe a time when you resolved a conflict within your team.",
                        Level1_2 = "Struggles to collaborate effectively.",
                        Level3 = "Works well with team members and contributes to goals.",
                        Level4 = "Exceptionally collaborative and a strong team player."
                    },
                    new Question
                    {
                        Id = 16,
                        //Value = "Customer Orientation (repeated)",
                        TextQ = "How do you ensure that customer needs are at the forefront of your work?",
                        SubQuestion = "Share an example where you went above and beyond to address a customer concern.",
                        Level1_2 = "Limited ability to meet customer needs.",
                        Level3 = "Consistently meets customer needs with some effort.",
                        Level4 = "Exceeds customer expectations consistently."
                    },
                    new Question
                    {
                        Id = 17,
                        //Value = "English Proficiency",
                        TextQ = "How do you ensure clarity and professionalism in your written communication?",
                        SubQuestion = "Describe a time when your verbal communication was critical to achieving a work objective.",
                        Level1_2 = "Limited proficiency in English communication.",
                        Level3 = "Good proficiency with occasional mistakes.",
                        Level4 = "Highly proficient and clear in both written and verbal communication."
                    },
                    new Question
                    {
                        Id = 18,
                        //Value = "Strategic Thinking",
                        TextQ = "How do you align your daily tasks with broader organizational goals?",
                        SubQuestion = "Share an example where strategic thinking helped you solve a complex problem.",
                        Level1_2 = "Limited understanding of strategic thinking.",
                        Level3 = "Understands strategic goals and aligns decisions accordingly.",
                        Level4 = "Strong strategic thinker with the ability to shape long-term plans."
                    },
                    new Question
                    {
                        Id = 19,
                        //Value = "Building an Effective Team",
                        TextQ = "How have you fostered a strong sense of trust and collaboration within your team?",
                        SubQuestion = "Describe an initiative where you developed your team's skills or capabilities.",
                        Level1_2 = "Limited ability to build effective teams.",
                        Level3 = "Builds effective teams with some challenges.",
                        Level4 = "Creates strong, cohesive teams that work effectively together."
                    },
                    new Question
                    {
                        Id = 20,
                        //Value = "Coaching Others",
                        TextQ = "Share an example where your coaching helped improve an employee's performance.",
                        SubQuestion = "How do you provide constructive feedback to your team?",
                        Level1_2 = "Rarely coaches or provides feedback.",
                        Level3 = "Provides coaching and feedback in some situations.",
                        Level4 = "Consistently coaches and provides actionable feedback to drive growth."

                    },
                     new Question
                     {
                         Id = 21,
                        //Value = "Execution Discipline (repeated)",
                        TextQ = "How do you ensure that projects are delivered on time and within scope?",
                         SubQuestion = "Describe a time when you identified and resolved an issue that threatened project delivery.",
                         Level1_2 = "Inconsistent in delivering projects on time and within scope.",
                         Level3 = "Delivers projects on time with minor scope changes.",
                         Level4 = "Consistently delivers projects on time and within scope, resolving issues effectively."
                     },
                        new Question
                        {
                            Id = 22,
                            //Value = "Planning and Organizing",
                            TextQ = "How do you prioritize tasks and allocate resources to meet team objectives?",
                            SubQuestion = "Describe a time when proactive planning led to a successful outcome.",
                            Level1_2 = "Struggles with prioritizing and organizing tasks.",
                            Level3 = "Plans and organizes tasks with some success.",
                            Level4 = "Proactively plans and organizes tasks to achieve team objectives efficiently."
                        },
                        new Question
                        {
                            Id = 23,
                            //Value = "Business Acumen",
                            TextQ = "How do you incorporate market trends or organizational priorities into your team’s objectives?",
                            SubQuestion = "Describe a time when you identified a business opportunity or risk and acted on it.",
                            Level1_2 = "Limited understanding of business strategy and market trends.",
                            Level3 = "Applies market trends to team objectives with moderate success.",
                            Level4 = "Demonstrates strong business acumen, incorporating market trends and strategic insights into team decisions."
                        },
                        new Question
                        {
                            Id = 24,
                            //Value = "English Proficiency (repeated)",
                            TextQ = "How do you ensure your presentations or reports are clear, concise, and impactful?",
                            SubQuestion = "Describe a situation where your communication skills influenced a high-level stakeholder.",
                            Level1_2 = "Limited proficiency in English communication.",
                            Level3 = "Good proficiency with occasional mistakes.",
                            Level4 = "Highly proficient and clear in both written and verbal communication."
                        },
                        new Question
                        {
                            Id = 25,
                            //Value = "Strategic Vision",
                            TextQ = "How do you align your long-term goals with the broader strategic direction of the organization?",
                            SubQuestion = "Can you share an example where your strategic vision helped your team achieve a significant milestone?",
                            Level1_2 = "Limited understanding of long-term strategic goals.",
                            Level3 = "Aligns daily tasks with broader organizational goals with some effort.",
                            Level4 = "Strong strategic vision that guides long-term success."
                        },
                        new Question
                        {
                            Id = 26,
                            //Value = "Business Acumen (repeated)",
                            TextQ = "How do you incorporate market trends or organizational priorities into your team’s objectives?",
                            SubQuestion = "Describe a time when you identified a business opportunity or risk and acted on it.",
                            Level1_2 = "Limited understanding of business strategy and market trends.",
                            Level3 = "Applies market trends to team objectives with moderate success.",
                            Level4 = "Demonstrates strong business acumen, incorporating market trends and strategic insights into team decisions."
                        },
                        new Question
                        {
                            Id = 27,
                            //Value = "Leadership",
                            TextQ = "How do you inspire and motivate your team to achieve high performance?",
                            SubQuestion = "Can you describe a situation where your leadership skills helped your team overcome a challenge?",
                            Level1_2 = "Struggles to inspire and motivate team members.",
                            Level3 = "Motivates the team and contributes to positive outcomes.",
                            Level4 = "Inspires and motivates the team to achieve exceptional performance."
                        },
                        new Question
                        {
                            Id = 28,
                            //Value = "Change Management",
                            TextQ = "How do you manage change within your team or organization?",
                            SubQuestion = "Describe a time when you successfully led a change initiative. What challenges did you face?",
                            Level1_2 = "Struggles with managing change; resistance to new processes.",
                            Level3 = "Manages change effectively with some challenges.",
                            Level4 = "Leads successful change initiatives that drive improvement."
                        },
                        new Question
                        {
                            Id = 29,
                            //Value = "Decision Making (repeated)",
                            TextQ = "Share an example where you had to make a decision with limited information. What steps did you take?",
                            SubQuestion = "How do you evaluate the potential risks and benefits of your decisions?",
                            Level1_2 = "Struggles to make decisions with limited information.",
                            Level3 = "Makes decisions with some confidence based on available information.",
                            Level4 = "Makes well-informed decisions with strong risk/benefit analysis."
                        },
                        new Question
                        {
                            Id = 30,
                            //Value = "Innovation (repeated)",
                            TextQ = "Have you suggested a new process or idea that improved team performance? What was it?",
                            SubQuestion = "How do you approach brainstorming or problem-solving?",
                            Level1_2 = "Limited involvement in innovative efforts.",
                            Level3 = "Contributes to innovation with moderate success.",
                            Level4 = "Consistently generates innovative ideas that improve performance."
                        },
                        new Question
                        {
                            Id = 31,
                            //Value = "Global Perspective",
                            TextQ = "How do you ensure that your work takes into account global perspectives or international considerations?",
                            SubQuestion = "Can you share a time when your global perspective helped your team solve a complex problem?",
                            Level1_2 = "Limited understanding of global perspectives.",
                            Level3 = "Considers global perspectives in decision-making.",
                            Level4 = "Strong global perspective that drives international success."
                        },
                        new Question
                        {
                            Id = 32,
                            //Value = "Stakeholder Management",
                            TextQ = "How do you engage and manage relationships with key stakeholders?",
                            SubQuestion = "Describe a time when you effectively managed a difficult stakeholder situation.",
                            Level1_2 = "Limited ability to manage stakeholders.",
                            Level3 = "Manages stakeholder relationships with moderate success.",
                            Level4 = "Effectively engages and manages key stakeholders to drive success."
                        }
        );

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "HarringManger",
                   NormalizedName = "HarringManger",
                   ConcurrencyStamp = Guid.NewGuid().ToString(),
               },
               new IdentityRole()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Recruiter",
                   NormalizedName = "Recruiter",
                   ConcurrencyStamp = Guid.NewGuid().ToString(),
               });

            // Seed data for HiringManagers
            modelBuilder.Entity<HiringManager>().HasData(
                new HiringManager { Id = 1, Name = "Alice Brown", Email = "alice.brown@example.com" },
                new HiringManager { Id = 2, Name = "Bob Green", Email = "bob.green@example.com" }
            );

            // Seed data for Candidates
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = 1,
                    Name = "John Doe",
                    Department = "Engineering",
                    Position = "Software Engineer",
                    InterviewDate = DateTime.Now.AddDays(1),
                    AssessmentTypeId = 1,
                    HiringManagerId = 1 // Use a valid HiringManagerId
                },
                new Candidate
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Department = "Management",
                    Position = "Project Manager",
                    InterviewDate = DateTime.Now.AddDays(2),
                    AssessmentTypeId = 2,
                    HiringManagerId = 2 // Use a valid HiringManagerId
                }
            );


            // Seed data for HiringManagers
            modelBuilder.Entity<HiringManager>().HasData(
                new HiringManager { Id = 3, Name = " Brown", Email = "alice.bgfdgrown@example.com" },
                new HiringManager { Id = 4, Name = "Bobge Gpoeen", Email = "bob.grpohn@example.com" }
            );

            // Seed data for Candidates
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = 3,
                    Name = "John Doe",
                    Department = "Engineering",
                    Position = "Software Engineer",
                    InterviewDate = DateTime.Now.AddDays(1),
                    AssessmentTypeId = 3,
                    HiringManagerId = 3// Use a valid HiringManagerId
                },
                new Candidate
                {
                    Id = 4,
                    Name = "Jane Smith",
                    Department = "Management",
                    Position = "Project Manager",
                    InterviewDate = DateTime.Now.AddDays(2),
                    AssessmentTypeId = 4,
                    HiringManagerId = 4// Use a valid HiringManagerId
                }
            );


        }

    }
}
