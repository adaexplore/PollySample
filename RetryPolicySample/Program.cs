using Autofac;
using Polly.Registry;
using RetryPolicySample.Repositories;
using RetryPolicySample.Services;
using System;

namespace RetryPolicySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is an example of the use of the Retry policies.");

            var container = Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var boService = scope.Resolve<IBoService>();

                boService.Save("bo");
            }

            Console.WriteLine("\r\nEnd of retry, press any key...");

            Console.ReadKey();
        }

        private static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BoRepository>().As<IBoRepository>();

            builder.Register(c => PolicyConfig.RegisterPolicies()).As<IReadOnlyPolicyRegistry<string>>().SingleInstance();

            builder.RegisterType<BoService>().As<IBoService>();

            return builder.Build();
        }

    }
}
