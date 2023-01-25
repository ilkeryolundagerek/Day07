using AutoMapper;
using Day07.Areas.Dashboard.Models.MapProfiles;
using Day07.Data;
using Day07.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using UtilitiesCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
/*
builder
    .Services
    .AddDbContext<DefaultUserContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default_identity")));

builder
    .Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<DefaultUserContext>();
*/
builder
    .Services
    .AddDbContext<CustomUserContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("custom_identity")));

builder
    .Services
    .AddIdentity<CustomUser, CustomRole>()
    .AddEntityFrameworkStores<CustomUserContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IEmailSender, EmailSender>(options => new EmailSender(
    builder.Configuration["EMailSenderConfiguration:username"],
    builder.Configuration["EMailSenderConfiguration:password"],
    builder.Configuration["EMailSenderConfiguration:host"],
    builder.Configuration.GetValue<int>("EMailSenderConfiguration:port")
    ));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/identity/account/login";
    options.LogoutPath = "/identity/account/logout";
    options.AccessDeniedPath = "/identity/account/accessdenied";
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var map_cfg = new MapperConfiguration(cfg => cfg.AddProfile(new AccountMapProfile()));
IMapper mapper = map_cfg.CreateMapper();
builder.Services.AddSingleton(mapper);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
