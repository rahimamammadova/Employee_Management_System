using EMS_BLL.Mapping;
using EMS_BLL.Validations;
using EMS_DAL.Data;
using EMS_DAL.Models;
using EMS_DAL.Repository;
using EMS_DAL.Repository.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbIdentityContext>(
         opts =>
         {
             opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"));
             opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
         }
    );

builder.Services.AddIdentity<AppUser, AppRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = true;
    opts.Password.RequireLowercase = true;
    opts.Password.RequireUppercase = true;
    opts.Password.RequireDigit = true;
}
).AddEntityFrameworkStores<AppDbIdentityContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddAutoMapper(typeof(CustomMapping));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(DepartmentValidator).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
