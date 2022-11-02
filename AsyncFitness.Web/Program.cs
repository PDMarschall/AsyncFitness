using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AsyncFitness.Web.Data;
using AsyncFitness.Web.Areas.Identity.Data;
using AsyncFitness.Infrastructure.DbContexts;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Infrastructure.Repository;
using AsyncFitness.Infrastructure.DataServices;

namespace AsyncFitness.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            ConfigureDbContext(builder);
            ConfigureIdentity(builder);
            ConfigureDI(builder);

            WebApplication app = builder.Build();

            SeedDatabase(app);

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

        private static void ConfigureDbContext(WebApplicationBuilder builder)
        {
            string connectionStringIdentity = builder.Configuration.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Connection string 'IdentityConnection' not found.");
            builder.Services.AddDbContext<AsyncFitnessWebContext>(options =>
            options.UseSqlServer(connectionStringIdentity));

            string connectionStringCore = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<FitnessContext>(options =>
            options.UseSqlServer(connectionStringCore));
        }

        private static void ConfigureIdentity(WebApplicationBuilder builder)
        {
            builder.Services.AddDefaultIdentity<AsyncFitnessUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AsyncFitnessWebContext>();

            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Fitness", "/");
            });

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
        }

        private static void ConfigureDI(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IRepository<Subscription>, SubscriptionRepository>();
            builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
            builder.Services.AddTransient<IRepository<Trainer>, TrainerRepository>();
            builder.Services.AddTransient<IRepository<FitnessCenter>, FitnessCenterRepository>();
            builder.Services.AddTransient<IRepository<GroupFitnessClass>, GroupFitnessClassRepository>();
            builder.Services.AddTransient<IRepository<GroupFitnessConcept>, GroupFitnessConceptRepository>();
            builder.Services.AddTransient<IRepository<GroupFitnessLocation>, GroupFitnessLocationRepository>();

            builder.Services.AddTransient<IGroupFitnessClassBookingService, GroupFitnessClassBookingService>();
            builder.Services.AddTransient<IGroupFitnessClassCalendarCreationService, GroupFitnessClassCalendarCreationService>();
        }

        private static void SeedDatabase(WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                SeedData.CreateInitialDb(services);
            }
        }
    }
}