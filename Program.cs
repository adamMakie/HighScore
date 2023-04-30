using Highscore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddRazorRuntimeCompilation();

builder.Services.AddSession(options =>
{
   options.Cookie.IsEssential = true;
});


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationContext>
	 (options => options.UseSqlServer(
		  builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDefaultIdentity<IdentityUser>(
	options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "Admin" }
	 );

app.MapControllerRoute(
	 name: "default",
	 pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
