using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Variance;
using MediatR;
using SkydivingLog.Infrastructure.Queries;
using SkydivingLog.Infrastructure.Queries.Persons;

namespace Prototype
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = SetupAutofac();
            var mediatr = container.Resolve<IMediator>();
            var result = await mediatr.Send(new GetPersonNameById.Query() { Id = 1 });
            Console.WriteLine($"Person with Id 1 names({result?.Name})");
            Console.WriteLine("Idling...");
            Console.ReadLine();
        }

        private static IContainer SetupAutofac()
        {
            var builder = new ContainerBuilder();
            RegisterMediator(builder);

            builder.Register(context =>
            {
                var sqlConnection = new SqlConnection("Server=.;Integrated Security=true; Database=SkydivingLog; MultipleActiveResultSets=True;");
                return sqlConnection;
            }).InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var sqlConnection = new SqlConnection("Server=.;Integrated Security=true; Database=SkydivingLog; MultipleActiveResultSets=True;");
                return sqlConnection;
            }).As<IDbConnection>().InstancePerLifetimeScope();
            var container = builder.Build();
            return container;
        }


        private static void RegisterMediator(ContainerBuilder builder)
        {
            // Mediator itself
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // Enables contravariant Resolve() for interfaces with single contravariant ("in") arg
            builder
                .RegisterSource(new ContravariantRegistrationSource());



            // Request handlers
            builder.RegisterAssemblyTypes(typeof(AssemblyAnchor).GetTypeInfo().Assembly).AsImplementedInterfaces(); // via assembly scan

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
        }
    }
}
