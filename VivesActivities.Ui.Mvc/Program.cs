using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VivesActivities.Core;
using VivesActivities.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<VivesActivityService>();
builder.Services.AddScoped<LocationService>();

builder.Services.AddDbContext<VivesActivitiesDbContext>(options =>
{
    options.UseInMemoryDatabase(nameof(VivesActivitiesDbContext));
    //options.UseSqlServer("Server=.\\SqlExpress;Database=VivesActivities;Trusted_Connection=True;TrustServerCertificate=True");
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;

    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<VivesActivitiesDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/identity/signin";
    options.LoginPath = "/identity/signin";

    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using var scope = app.Services.CreateScope();

    var dbContext = scope.ServiceProvider.GetRequiredService<VivesActivitiesDbContext>();
    if (dbContext.Database.IsInMemory())
    {
        dbContext.Seed();
    }

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
