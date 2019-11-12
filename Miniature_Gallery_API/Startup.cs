using Miniature_Gallery_API.Core.Models;
using Miniature_Gallery_API.Core.Services;
using Miniature_Gallery_API.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;

namespace Miniature_Gallery_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            // Use SQL Database if in Azure, otherwise, use SQLite
            //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            //    services.AddDbContext<AppDbContext>(options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("MiniatureGalleryConnection")));
            //else
            //    services.AddDbContext<AppDbContext>(options =>
            //            options.UseSqlite("Data Source=MiniatureGallery.db"));

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();

            // TODO: Prep Part 1: Add Identity services (Part 1 of prep exercise)
            // add Identity-related services
            services.AddIdentity<AppUser, IdentityRole>()
                // tell Identity which DbContext to use for user-related tables
                .AddEntityFrameworkStores<AppDbContext>();

            // TODO: Prep Part 2: Add JWT support 
            // Add JWT support
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddScoped<IMiniatureRepository, MiniatureRepository>();
            services.AddScoped<IMiniatureService, MiniatureService>();
            services.AddScoped<IMiniatureRepository, MiniatureRepository>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameRepository, GameRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // TODO: Class Project: Seed admin user
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseMvc();

            // create admin user if it doesn't already exist
            SeedAdminUser(userManager, roleManager);
        }

        private void SeedAdminUser(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // create an Admin role, if it doesn't already exist
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = roleManager.CreateAsync(adminRole).Result;
            }

            // create an Admin user, if it doesn't already exist
            //if (userManager.FindByNameAsync("admin").Result == null)
            //{
            //    AppUser user = new AppUser
            //    {
            //        UserName = "admin@test.com",
            //        Email = "admin@test.com"
            //    };

            //    // add the Admin user to the Admin role
            //    IdentityResult result = userManager.CreateAsync(user, "AdminPassword123!").Result;

            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRoleAsync(user, "Admin").Wait();
            //    }
            //}
        }

    }
}
