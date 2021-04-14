using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Tsa.Coding.Submissions.Core.DataContexts;
using Tsa.Coding.Submissions.Core.Repositories;
using Tsa.Coding.Submissions.WebApi.Repositories;

namespace Tsa.Coding.Submissions.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var dockerContainer = Configuration["DOCKER_CONTAINER"] != null && Configuration["DOCKER_CONTAINER"] == "Y";

                if (dockerContainer)
                {
                    var updateCaCertificatesProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            Arguments = "update-ca-certificates",
                            CreateNoWindow = true,
                            FileName = "/bin/bash",
                            UseShellExecute = false
                        }
                    };

                    updateCaCertificatesProcess.Start();
                    updateCaCertificatesProcess.WaitForExit();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var requireAuthenticatedUserPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            services.AddDbContext<SubmissionsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SubmissionsContext")));

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IProblemRepository, ProblemRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = Configuration["IdentityServer:Uri"];

                    options.TokenValidationParameters = new TokenValidationParameters { ValidateAudience = false };
                });

            services.AddControllers(configure =>
            {
                configure.Filters.Add(new AuthorizeFilter(requireAuthenticatedUserPolicy));
            });
        }
    }
}
