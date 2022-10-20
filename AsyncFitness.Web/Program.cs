using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AsyncFitness.Web.Data;
using AsyncFitness.Web.Areas.Identity.Data;
using AsyncFitness.Infrastructure.DbContexts;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Infrastructure.Repository;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Core.Models.Facility;

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

            var connectionStringCore = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<FitnessContext>(options =>
            options.UseSqlServer(connectionStringCore));

            builder.Services.AddDefaultIdentity<AsyncFitnessUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AsyncFitnessWebContext>();

            // Add services to the container.
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Fitness", "/");
            });

            builder.Services.AddTransient<UserManager<AsyncFitnessUser>>();
            builder.Services.AddTransient<IRepository<Subscription>, SubscriptionRepository>();
            builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
            builder.Services.AddTransient<IRepository<Trainer>, TrainerRepository>();
            builder.Services.AddTransient<IRepository<FitnessCenter>, FitnessCenterRepository>();
            builder.Services.AddTransient<IRepository<GroupFitnessClass>, GroupFitnessClassRepository>();
            builder.Services.AddTransient<IRepository<GroupFitnessConcept>, GroupFitnessConceptRepository>();
            builder.Services.AddTransient<IRepository<GroupFitnessLocation>, GroupFitnessLocationRepository>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.InitializeCustomer(services);
                SeedData.InitializeSubscription(services);

                //SeedData.InitializeFitnessCenter(services);
                //SeedData.InitializeFitnessLocations(services);
                //SeedData.InitializeFitnessConcept(services);
                //SeedData.InitializeFitnessClass(services);
            }

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
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}