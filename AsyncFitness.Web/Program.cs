using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AsyncFitness.Web.Data;
using AsyncFitness.Web.Areas.Identity.Data;

namespace AsyncFitness.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("AsyncFitnessWebContextConnection") ?? throw new InvalidOperationException("Connection string 'AsyncFitnessWebContextConnection' not found.");

            builder.Services.AddDbContext<AsyncFitnessWebContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<AsyncFitnessUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AsyncFitnessWebContext>();

            // Add services to the container.
            builder.Services.AddRazorPages();

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