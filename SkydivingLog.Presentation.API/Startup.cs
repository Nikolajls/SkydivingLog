using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using SkydivingLog.Infrastructure.Queries;
using SkydivingLog.Infrastructure.Queries.Associations;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            Configuration = configuration;
            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IDbConnection>(ctx => new SqlConnection("Server=.;Integrated Security=true; Database=SkydivingLog; MultipleActiveResultSets=True;"));
            services.AddControllers().AddNewtonsoftJson(opts => 
                opts.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddMediatR(typeof(AssemblyAnchor).Assembly);

        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<AssociationService>().As<IAssociationService>().SingleInstance();
            // Register your own things directly with Autofac, like:

            var canopyRegulations = Assembly.GetAssembly(typeof(ICanopyRegulations))
                .GetTypes()
                .Where(type => typeof(ICanopyRegulations).IsAssignableFrom(type) && !type.IsAbstract)
                .ToList();
            foreach (var regulation in canopyRegulations)
            {

                var name = regulation.Name;
                var associationType = regulation.BaseType?.GenericTypeArguments.FirstOrDefault();
                if (associationType == null) continue;
                var associationInstance = (IAssociation)Activator.CreateInstance(associationType);
                builder.RegisterType(regulation).Keyed<ICanopyRegulations>(associationInstance.Association).SingleInstance();
                 }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

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
