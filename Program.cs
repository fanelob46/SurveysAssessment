using Microsoft.EntityFrameworkCore;
using SurveysAssessment.Data;
using SurveysAssessment.Services.SurveyService;
using SurveysAssessment.Services.UserFavouriteFood;
using SurveysAssessment.Services.UserRatings;
using SurveysAssessment.Services.Users;

var builder = WebApplication.CreateBuilder(args);


//for Entity framework

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRatingService, UserRatingService>();
builder.Services.AddScoped<IUserFavouriteFoodService, UserFavouriteFoodService>();
builder.Services.AddScoped<ISurveyService, SurveyService>();

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Survey}/{action=NewSurvey}/{id?}");

app.Run();
