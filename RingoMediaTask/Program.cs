
using Application.Contract;
using Application.IServices;
using Application.Services;
using Context;
using DTOs;
using Hangfire;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("Db")));
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddHangfireServer();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped < Application.Contract.IBaseRepository<Department, int>, Infrastructure.BaseRepository<Department, int>>();
builder.Services.AddScoped < Application.Contract.IBaseRepository<Reminder, int>, Infrastructure.BaseRepository<Reminder, int>>();
builder.Services.AddScoped<IDepartmentService, DepartmentServices>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Db"));
});



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
app.UseHangfireDashboard("/DashBoard");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
