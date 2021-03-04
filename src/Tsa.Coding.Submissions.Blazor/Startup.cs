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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = "https://localhost:44353";
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClientId = "tsa.coding.submissions.web";
                    options.ClientSecret = "a673bbae-71e4-4962-a623-665689c4dd34";
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    //TODO: Check if these are added by default
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("tsa.coding.submissions.read");
                    options.Scope.Add("tsa.coding.submissions.create");
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.TokenValidationParameters.NameClaimType = "name";
                });

            services.AddScoped<TokenProvider>();
            services.AddScoped<TokenManager>();
        }
    }
}
