using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tsa.Coding.Submissions.Core.DataContexts;
using Tsa.Coding.Submissions.Core.Repositories;

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
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SubmissionsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SubmissionsContext")));

            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddControllers();
        }
    }
}
