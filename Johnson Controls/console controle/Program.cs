using console_controle.Models;
using Microsoft.EntityFrameworkCore;
using console_controle.Data;
using Microsoft.AspNetCore.Identity;
using console_controle.Controllers;

var builder = WebApplication.CreateBuilder(args);

// إضافة DbContext إلى الخدمة (يجب أن يتوافق مع الـ ApplicationDbContext)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"))
);

// إضافة خدمات Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireRecruiterRole", policy => policy.RequireRole("Recruiter"));
    options.AddPolicy("RequireHiringManagerRole", policy => policy.RequireRole("HarringManger"));
});

// إضافة خدمات MVC
builder.Services.AddControllersWithViews();

// تهيئة تطبيق الويب
var app = builder.Build();

// تكوين الـ HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// تهيئة روتين الـ Razor Pages
app.MapRazorPages();

// تكوين الـ Controller Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
