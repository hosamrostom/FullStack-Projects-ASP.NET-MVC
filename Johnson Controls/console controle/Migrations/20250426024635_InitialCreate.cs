using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace console_controle.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssessmentValueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiringManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextQ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level1_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssessmentTypeId = table.Column<int>(type: "int", nullable: true),
                    HiringManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_AssessmentTypes_AssessmentTypeId",
                        column: x => x.AssessmentTypeId,
                        principalTable: "AssessmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_HiringManagers_HiringManagerId",
                        column: x => x.HiringManagerId,
                        principalTable: "HiringManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    AssessmentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentValues_AssessmentTypes_AssessmentTypeId",
                        column: x => x.AssessmentTypeId,
                        principalTable: "AssessmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentValues_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidateAssessmentResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opportunities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strengths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weaknesses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Threats = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateAssessmentResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateAssessmentResults_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateEvaluationViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssessmentTypeId = table.Column<int>(type: "int", nullable: false),
                    HiringManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    AssessmentResultId = table.Column<int>(type: "int", nullable: false),
                    CandidateAssessmentResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateEvaluationViewModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateEvaluationViewModels_CandidateAssessmentResults_AssessmentResultId",
                        column: x => x.AssessmentResultId,
                        principalTable: "CandidateAssessmentResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateEvaluationViewModels_CandidateAssessmentResults_CandidateAssessmentResultId",
                        column: x => x.CandidateAssessmentResultId,
                        principalTable: "CandidateAssessmentResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateEvaluationViewModels_CandidateAssessmentResults_ResultId",
                        column: x => x.ResultId,
                        principalTable: "CandidateAssessmentResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateEvaluationViewModels_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ac346f6-36cd-475c-971e-5657e905a0a8", "04ed9c0c-c808-4cdf-ad82-495ba178fdfe", "Recruiter", "Recruiter" },
                    { "3bbb2fbf-ca4f-4f73-a968-0ce908daf5f4", "bede7246-a626-45ca-bc75-4f0c65a05704", "HarringManger", "HarringManger" }
                });

            migrationBuilder.InsertData(
                table: "AssessmentTypes",
                columns: new[] { "Id", "AssessmentValueId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Individual Contributor - Support" },
                    { 2, null, "Individual Contributor - Professional" },
                    { 3, null, "Middle Management" },
                    { 4, null, "Top Management" }
                });

            migrationBuilder.InsertData(
                table: "HiringManagers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "alice.brown@example.com", "Alice Brown" },
                    { 2, "bob.green@example.com", "Bob Green" },
                    { 3, "alice.bgfdgrown@example.com", " Brown" },
                    { 4, "bob.grpohn@example.com", "Bobge Gpoeen" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Level1_2", "Level3", "Level4", "SubQuestion", "TextQ" },
                values: new object[,]
                {
                    { 1, "Lacks required technical skills; basic proficiency.", "Good technical skills with some proficiency.", "Strong technical skills and expertise.", "Can you provide an example where your technical skills directly contributed to the success of a project?", "How do you ensure that your technical skills are continuously improving?" },
                    { 2, "No focus on customer satisfaction; basic understanding.", "Good understanding of customer needs and some focus on satisfaction.", "Strong focus on customer satisfaction.", "Share an example where you went above and beyond to address a customer concern.", "How do you ensure that customer needs are at the forefront of your work?" },
                    { 3, "Poor quality of work; lack of attention to detail.", "Good quality of work with attention to detail.", "Strong quality of work and meticulous attention to detail.", "Can you describe a time when you identified an opportunity to improve the quality of a project or task?", "How do you ensure that your work consistently meets quality standards?" },
                    { 4, "Poor execution; missed deadlines.", "Good execution with most deadlines met.", "Strong execution and consistent on-time delivery.", "Describe a time when you had to handle competing priorities. How did you manage it?", "How do you ensure that you consistently meet deadlines for your tasks?" },
                    { 5, "Poor communication skills; limited effectiveness.", "Good communication skills with some effectiveness.", "Strong communication skills that ensure clarity and understanding.", "Can you provide an example of a time when effective communication helped resolve a misunderstanding?", "How do you ensure clarity and professionalism in your communication?" },
                    { 6, "Resistant to change; basic adaptability.", "Good adaptability to changes.", "Strong adaptability and ability to thrive in changing environments.", "Can you describe a time when you successfully adapted to a new work culture or process?", "How do you manage stress or uncertainty in dynamic environments?" },
                    { 7, "Poor attention to detail; many errors.", "Good attention to detail with few errors.", "Strong attention to detail and accuracy.", "Can you share an example where your attention to detail prevented a mistake?", "How do you ensure that you thoroughly review all aspects of your work before completion?" },
                    { 8, "Lacks physical stamina; basic limitations.", "Good physical stamina to meet most demands.", "Strong physical stamina and ability to handle demanding tasks.", "Can you share a time when your physical stamina helped you meet a challenging work deadline?", "How do you maintain your energy levels during long working hours or physically demanding tasks?" },
                    { 9, "Poor execution; missed deadlines.", "Good execution with most deadlines met.", "Strong execution and consistent on-time delivery.", "Describe a time when you had to handle competing priorities. How did you manage it?", "How do you ensure that you consistently meet deadlines for your tasks?" },
                    { 10, "Struggles to manage workload; misses deadlines.", "Manages workload with some assistance; meets deadlines.", "Manages workload effectively, consistently meeting or exceeding expectations.", "What tools or techniques do you use to track progress and avoid delays?", "How do you organize your daily workload to ensure efficiency?" },
                    { 11, "Struggles to make decisions; limited risk assessment.", "Makes sound decisions with moderate risk assessment.", "Makes informed, well-analyzed decisions with excellent risk/benefit evaluation.", "How do you evaluate the potential risks and benefits of your decisions?", "Share an example where you had to make a decision with limited information. What steps did you take?" },
                    { 12, "Struggles with change; slow to adapt.", "Adapts to changes with some effort.", "Demonstrates exceptional agility in adapting to new situations.", "How do you remain productive when faced with changing priorities?", "Describe a situation where you had to quickly adapt to a major change at work. What was the outcome?" },
                    { 13, "No culture of innovation; limited efforts.", "Some efforts to foster innovation.", "Strong culture of innovation that drives continuous improvement.", "How do you approach brainstorming or problem-solving?", "Have you suggested a new process or idea that improved team performance? What was it?" },
                    { 14, "Limited influence over others.", "Good influence with moderate success.", "Highly effective at influencing others to adopt desired actions.", "How do you adjust your communication style to influence others effectively?", "Can you provide an example of how you persuaded a colleague or stakeholder to adopt your approach?" },
                    { 15, "Struggles to collaborate effectively.", "Works well with team members and contributes to goals.", "Exceptionally collaborative and a strong team player.", "Describe a time when you resolved a conflict within your team.", "How do you contribute to fostering a positive and collaborative team environment?" },
                    { 16, "Limited ability to meet customer needs.", "Consistently meets customer needs with some effort.", "Exceeds customer expectations consistently.", "Share an example where you went above and beyond to address a customer concern.", "How do you ensure that customer needs are at the forefront of your work?" },
                    { 17, "Limited proficiency in English communication.", "Good proficiency with occasional mistakes.", "Highly proficient and clear in both written and verbal communication.", "Describe a time when your verbal communication was critical to achieving a work objective.", "How do you ensure clarity and professionalism in your written communication?" },
                    { 18, "Limited understanding of strategic thinking.", "Understands strategic goals and aligns decisions accordingly.", "Strong strategic thinker with the ability to shape long-term plans.", "Share an example where strategic thinking helped you solve a complex problem.", "How do you align your daily tasks with broader organizational goals?" },
                    { 19, "Limited ability to build effective teams.", "Builds effective teams with some challenges.", "Creates strong, cohesive teams that work effectively together.", "Describe an initiative where you developed your team's skills or capabilities.", "How have you fostered a strong sense of trust and collaboration within your team?" },
                    { 20, "Rarely coaches or provides feedback.", "Provides coaching and feedback in some situations.", "Consistently coaches and provides actionable feedback to drive growth.", "How do you provide constructive feedback to your team?", "Share an example where your coaching helped improve an employee's performance." },
                    { 21, "Inconsistent in delivering projects on time and within scope.", "Delivers projects on time with minor scope changes.", "Consistently delivers projects on time and within scope, resolving issues effectively.", "Describe a time when you identified and resolved an issue that threatened project delivery.", "How do you ensure that projects are delivered on time and within scope?" },
                    { 22, "Struggles with prioritizing and organizing tasks.", "Plans and organizes tasks with some success.", "Proactively plans and organizes tasks to achieve team objectives efficiently.", "Describe a time when proactive planning led to a successful outcome.", "How do you prioritize tasks and allocate resources to meet team objectives?" },
                    { 23, "Limited understanding of business strategy and market trends.", "Applies market trends to team objectives with moderate success.", "Demonstrates strong business acumen, incorporating market trends and strategic insights into team decisions.", "Describe a time when you identified a business opportunity or risk and acted on it.", "How do you incorporate market trends or organizational priorities into your team’s objectives?" },
                    { 24, "Limited proficiency in English communication.", "Good proficiency with occasional mistakes.", "Highly proficient and clear in both written and verbal communication.", "Describe a situation where your communication skills influenced a high-level stakeholder.", "How do you ensure your presentations or reports are clear, concise, and impactful?" },
                    { 25, "Limited understanding of long-term strategic goals.", "Aligns daily tasks with broader organizational goals with some effort.", "Strong strategic vision that guides long-term success.", "Can you share an example where your strategic vision helped your team achieve a significant milestone?", "How do you align your long-term goals with the broader strategic direction of the organization?" },
                    { 26, "Limited understanding of business strategy and market trends.", "Applies market trends to team objectives with moderate success.", "Demonstrates strong business acumen, incorporating market trends and strategic insights into team decisions.", "Describe a time when you identified a business opportunity or risk and acted on it.", "How do you incorporate market trends or organizational priorities into your team’s objectives?" },
                    { 27, "Struggles to inspire and motivate team members.", "Motivates the team and contributes to positive outcomes.", "Inspires and motivates the team to achieve exceptional performance.", "Can you describe a situation where your leadership skills helped your team overcome a challenge?", "How do you inspire and motivate your team to achieve high performance?" },
                    { 28, "Struggles with managing change; resistance to new processes.", "Manages change effectively with some challenges.", "Leads successful change initiatives that drive improvement.", "Describe a time when you successfully led a change initiative. What challenges did you face?", "How do you manage change within your team or organization?" },
                    { 29, "Struggles to make decisions with limited information.", "Makes decisions with some confidence based on available information.", "Makes well-informed decisions with strong risk/benefit analysis.", "How do you evaluate the potential risks and benefits of your decisions?", "Share an example where you had to make a decision with limited information. What steps did you take?" },
                    { 30, "Limited involvement in innovative efforts.", "Contributes to innovation with moderate success.", "Consistently generates innovative ideas that improve performance.", "How do you approach brainstorming or problem-solving?", "Have you suggested a new process or idea that improved team performance? What was it?" },
                    { 31, "Limited understanding of global perspectives.", "Considers global perspectives in decision-making.", "Strong global perspective that drives international success.", "Can you share a time when your global perspective helped your team solve a complex problem?", "How do you ensure that your work takes into account global perspectives or international considerations?" },
                    { 32, "Limited ability to manage stakeholders.", "Manages stakeholder relationships with moderate success.", "Effectively engages and manages key stakeholders to drive success.", "Describe a time when you effectively managed a difficult stakeholder situation.", "How do you engage and manage relationships with key stakeholders?" }
                });

            migrationBuilder.InsertData(
                table: "AssessmentValues",
                columns: new[] { "Id", "AssessmentTypeId", "QuestionId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, "Technical Skills" },
                    { 2, 1, 2, "Customer Orientation" },
                    { 3, 1, 3, "Quality of Work" },
                    { 4, 1, 4, "Execution Discipline" },
                    { 5, 1, 5, "Communication Skills" },
                    { 6, 1, 6, "Adaptability" },
                    { 7, 1, 7, "Attention to Detail" },
                    { 8, 1, 8, "Physical Stamina" },
                    { 9, 2, 9, "Execution Discipline" },
                    { 10, 2, 10, "Managing Work" },
                    { 11, 2, 11, "Decision Making" },
                    { 12, 2, 12, "Agility" },
                    { 13, 2, 13, "Innovation" },
                    { 14, 2, 14, "Influencing with Impact" },
                    { 15, 2, 15, "Collaboration" },
                    { 16, 2, 16, "Customer Orientation" },
                    { 17, 2, 17, "English Proficiency" },
                    { 18, 2, 18, "Strategic Thinking" },
                    { 19, 3, 19, "Building an Effective Team" },
                    { 20, 3, 20, "Coaching Others" },
                    { 21, 3, 21, "Execution Discipline" },
                    { 22, 3, 22, "Planning and Organizing" },
                    { 23, 3, 23, "Business Acumen" },
                    { 24, 3, 24, "English Proficiency" },
                    { 25, 4, 25, "Strategic Vision" },
                    { 26, 4, 26, "Business Acumen" },
                    { 27, 4, 27, "Leadership" },
                    { 28, 4, 28, "Change Management" },
                    { 29, 4, 29, "Decision Making" },
                    { 30, 4, 30, "Innovation" },
                    { 31, 4, 31, "Global Perspective" },
                    { 32, 4, 32, "Stakeholder Management" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "AssessmentTypeId", "Department", "HiringManagerId", "InterviewDate", "Name", "Position" },
                values: new object[,]
                {
                    { 1, 1, "Engineering", 1, new DateTime(2025, 4, 27, 5, 46, 34, 669, DateTimeKind.Local).AddTicks(978), "John Doe", "Software Engineer" },
                    { 2, 2, "Management", 2, new DateTime(2025, 4, 28, 5, 46, 34, 689, DateTimeKind.Local).AddTicks(3069), "Jane Smith", "Project Manager" },
                    { 3, 3, "Engineering", 3, new DateTime(2025, 4, 27, 5, 46, 34, 689, DateTimeKind.Local).AddTicks(3532), "John Doe", "Software Engineer" },
                    { 4, 4, "Management", 4, new DateTime(2025, 4, 28, 5, 46, 34, 689, DateTimeKind.Local).AddTicks(3540), "Jane Smith", "Project Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentValues_AssessmentTypeId",
                table: "AssessmentValues",
                column: "AssessmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentValues_QuestionId",
                table: "AssessmentValues",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateAssessmentResults_CandidateId",
                table: "CandidateAssessmentResults",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEvaluationViewModels_AssessmentResultId",
                table: "CandidateEvaluationViewModels",
                column: "AssessmentResultId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEvaluationViewModels_CandidateAssessmentResultId",
                table: "CandidateEvaluationViewModels",
                column: "CandidateAssessmentResultId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEvaluationViewModels_CandidateId",
                table: "CandidateEvaluationViewModels",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEvaluationViewModels_ResultId",
                table: "CandidateEvaluationViewModels",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_AssessmentTypeId",
                table: "Candidates",
                column: "AssessmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_HiringManagerId",
                table: "Candidates",
                column: "HiringManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssessmentValues");

            migrationBuilder.DropTable(
                name: "CandidateEvaluationViewModels");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "CandidateAssessmentResults");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "AssessmentTypes");

            migrationBuilder.DropTable(
                name: "HiringManagers");
        }
    }
}
