using System.Net.Mime;
using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entites;
using WebGUI.Components;
using WebGUI.Components.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/accessdenied";
    });



builder.Services.AddCascadingAuthenticationState();


builder.Services.AddDbContextFactory<DishContext>(
    options => options.UseMySql(
        builder.Configuration
            .GetConnectionString("AdditionalConnection"),
        new MySqlServerVersion(new Version(8, 0, 27))
    )
);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
/*builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));*/
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



//


builder.Services.AddTransient<IRepositoryAsync<Dish>, DishRepositoryAsync>();
builder.Services.AddTransient<IRepositoryAsync<Category>, CategoryRepositoryAsync>();
builder.Services.AddTransient<IRepositoryAsync<CategoriesDishesJT>, CategoriesDishesJtRepoAsync>();
builder.Services.AddTransient<IRepositoryAsync<AllergenDishesJT>, AllergensDishesJTRepositoryAsync>();
builder.Services.AddTransient<IRepositoryAsync<Allergens>, AllergensRepositoryAsync>();
builder.Services.AddTransient<IRepositoryAsync<User>,UserRepoAsync>();

//
builder.Services.AddScoped<ShoppingCart>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.

app.Run();