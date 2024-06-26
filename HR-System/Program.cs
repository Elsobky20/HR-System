using HR_System.DataBase;
using HR_System.Services.AttendanceServices;
using HR_System.Services.EmployeeServices;
using HR_System.Services.GeneralSettingServices;
using HR_System.Services.OfficialVacationServices;
using HR_System.Services.SalaryReport;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString(name: "DefaultConnectoin") ??
    throw new InvalidOperationException(message: "No connection string was found");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<ApplicationDbContext>()
      .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IAttendanceServices, AttendanceServices>();
builder.Services.AddScoped<IOfficialVacationServices, OfficialVacationServices>();
builder.Services.AddScoped<IGeneralSettingServices, GeneralSettingServices>();
builder.Services.AddScoped<ISalaryReport, SalaryReport>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
