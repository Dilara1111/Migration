using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DAL;




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(connectionString)
    );
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );
app.MapDefaultControllerRoute();



app.Run();
