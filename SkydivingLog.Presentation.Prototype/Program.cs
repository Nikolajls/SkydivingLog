using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Variance;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using SkydivingLog.Infrastructure.Queries;
using SkydivingLog.Infrastructure.Queries.Associations;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;
using SkydivingLog.Infrastructure.Queries.Gear.Canopies;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Presentation.Prototype
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = SetupAutofac();
            var mediatr = container.Resolve<IMediator>();
            //var a = container.ResolveNamed<ICanopyRegulations>(Association.DFU);
            //var b = container.ResolveNamed<ICanopyRegulations>(Association.USPA);
            //A

            var smallestJumper = new FindSmallestSizeCanopy.Query
            {
                JumpingAssociation = Association.DFU,
                JumpNumbers = 40,
                NakedWeightKg = 85
            };
            var smallestSqft = await mediatr.Send(smallestJumper);
            Console.WriteLine($"Jumper with #{smallestJumper.JumpNumbers} and exit weight {smallestJumper.TotalWeight} minimum sqft canopy is {smallestSqft} in {smallestJumper.JumpingAssociation}");

            var request = new CanPersonJumpCanopy.Query
            {
                JumpingAssociation = Association.USPA,
                JumpNumbers = smallestJumper.JumpNumbers,
                NakedWeightKg = smallestJumper.NakedWeightKg,
                LeadWeightKg = smallestJumper.LeadWeightKg,
                CanopySqft = smallestSqft - 10
            };
            var mayJumper = await mediatr.Send(request);

            Console.WriteLine($"Can a jumper with #{request.JumpNumbers} jumps and exit weight {request.TotalWeight} jump a {request.CanopySqft} canopy? {(mayJumper ? "Yes" : "No ")} in {request.JumpingAssociation}");


            Console.WriteLine("Idling...");
            Console.ReadLine();
        }

        private static IContainer SetupAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AssociationService>().As<IAssociationService>().SingleInstance();
        

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
                Console.WriteLine($"Registered {regulation.Name} as ICanopyRegulations with keyed {associationInstance.Association}");
            }

            builder.AddMediatR(typeof(AssemblyAnchor).Assembly);

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


        //private static void RegisterMediator(ContainerBuilder builder)
        //{
        //    // Mediator itself
        //    builder
        //        .RegisterType<Mediator>()
        //        .As<IMediator>()
        //        .InstancePerLifetimeScope();

        //    // Enables contravariant Resolve() for interfaces with single contravariant ("in") arg
        //    builder
        //        .RegisterSource(new ContravariantRegistrationSource());
            
        //    // Request handlers
        //    builder.RegisterAssemblyTypes(typeof(AssemblyAnchor).GetTypeInfo().Assembly).AsImplementedInterfaces(); // via assembly scan

        //    // request & notification handlers
        //    builder.Register<ServiceFactory>(context =>
        //    {
        //        var c = context.Resolve<IComponentContext>();
        //        return t => c.Resolve(t);
        //    });
        //}
    }
}
