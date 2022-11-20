using DataModels.Entities;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 5;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IGymService, GymService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IApplicationFormService, ApplicationFormService>();
builder.Services.AddScoped<IAdminMailboxService, AdminMailboxService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IClientService, ClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(area =>
{
    area.MapDefaultControllerRoute();

    area.MapControllerRoute(
      name: "Writer",
      pattern: "{area:exists}/{controller=Writer}/{action=GetWriterScreen}/{id?}"
    );
});
    //app.MapControllerRoute(
    //name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");

    //app.MapControllerRoute(
    //  name: "areas",
    //  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    //);

app.MapRazorPages();

app.Run();
