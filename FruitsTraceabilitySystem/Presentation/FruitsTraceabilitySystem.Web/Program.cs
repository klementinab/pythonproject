using FruitsTraceabilitySystem.Application.Mappings;
using FruitsTraceabilitySystem.Application.Services.EmailSender;
using FruitsTraceabilitySystem.Infra.Data.Context;
using FruitsTraceabilitySystem.Infra.IoC;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("FruitsTraceability"), sqlServerOptionsAction: x =>
             {
                 x.EnableRetryOnFailure();
             }), ServiceLifetime.Transient);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
DependencyContainer.RegisterService(builder.Services);
MappingConfig.RegisterMapp();
builder.Services.AddScoped<IEmailSender, EmailSenderService>();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Administrator/AccessDenied");
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
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
