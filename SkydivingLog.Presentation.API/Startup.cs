using System.Data;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkydivingLog.Infrastructure.Queries;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;

namespace SkydivingLog.Presentation.API
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
            services.AddScoped<IDbConnection>(ctx => new SqlConnection("Server=.;Integrated Security=true; Database=SkydivingLog; MultipleActiveResultSets=True;"));
            //services.AddSingleton<ICanopyRegulations>(ctx => new DanishCanopyRegulations());
            services.AddControllers();
            services.AddMediatR(typeof(AssemblyAnchor).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
