using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AsyncFitness.Web.Data;
using AsyncFitness.Web.Areas.Identity.Data;
using AsyncFitness.Infrastructure.DbContexts;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models;
using AsyncFitness.Infrastructure.Repository;

namespace AsyncFitness.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionStringIdentity = builder.Configuration.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Connection string 'IdentityConnection' not found.");     
            builder.Services.AddDbContext<AsyncFitnessWebContext>(options =>
            options.UseSqlServer(connectionStringIdentity));

            var connectionStringCore = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<FitnessContext>(options =>
            options.UseSqlServer(connectionStringCore));

            builder.Services.AddDefaultIdentity<AsyncFitnessUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AsyncFitnessWebContext>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddTransient<IRepository<Subscription>, SubscriptionRepository>();
            builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
            builder.Services.AddTransient<IRepository<Trainer>, TrainerRepository>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}