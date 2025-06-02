using FYP.BLL.Interfaces;
using FYP.BLL.Services;
using FYP.BlazorUI.Components;
using FYP.DAL;
using FYP.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<FYP.DAL.ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Add authentication state management
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

builder.Services.AddAuthentication(AppConstant.AuthScheme)
    .AddCookie(AppConstant.AuthScheme, cookieOptions =>
    {
        cookieOptions.Cookie.Name = AppConstant.AuthScheme;
    })
    .AddGoogle(GoogleDefaults.AuthenticationScheme, googleOptions =>
    {
        googleOptions.ClientId = "";
        googleOptions.ClientSecret = "";
        googleOptions.AccessDeniedPath = "/access-denied";
        googleOptions.SignInScheme = AppConstant.AuthScheme;
    });

// Register BLL services
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IContactUsService, ContactUsService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IAdminDashboardService, AdminDashboardService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddScoped<IClaimsTransformation, CustomClaimsTransformer>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IChatService, HuggingFaceFreeService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Configure authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
