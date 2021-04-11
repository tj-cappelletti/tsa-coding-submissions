using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tsa.Coding.Submissions.Blazor.Services;

namespace Tsa.Coding.Submissions.Blazor
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var dockerContainer = Configuration["DOCKER_CONTAINER"] != null && Configuration["DOCKER_CONTAINER"] == "Y";

                if(dockerContainer)
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
            else
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            
            services.AddServerSideBlazor();

            services.AddHttpClient<ISubmissionsService, SubmissionsService>();

            var identityServerUri = Configuration["IdentityServer:Uri"];
            var identityServerClientId = Configuration["IdentityServer:ClientId"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = identityServerUri;
                    options.ClientId = identityServerClientId;
                    options.ClientSecret = "a673bbae-71e4-4962-a623-665689c4dd34";
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ResponseMode = "query";
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    //TODO: Check if these are added by default
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("tsa.coding.submissions.read");
                    options.Scope.Add("tsa.coding.submissions.create");
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.TokenValidationParameters.NameClaimType = "name";
                    options.UsePkce = true;
                });

            services.AddScoped<TokenProvider>();
            services.AddScoped<TokenManager>();
        }
    }
}
