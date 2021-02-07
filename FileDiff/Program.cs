using System;
using System.Threading.Tasks;
using Autofac;
using FileDiff.Application.FileGenerator;
using FileDiff.Application.FileRunner;
using FileDiff.Application.IoC;
using FileDiff.Application.Validation;

namespace FileDiff
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var defaultConfiguration = new DefaultConfiguration();

            using (var scope = defaultConfiguration.Container.BeginLifetimeScope())
            {
                var input = scope.Resolve<IInput>();
                if (!input.Validate(args))
                {
                    return;
                }

                if (args[0] == "fileGenerator")
                {
                    var fileGenerator = scope.Resolve<IFileGenerator>();
                    await fileGenerator.Process(args[1], args[2], args[3]);
                } else if (args[0] == "fileRunner")
                {
                    var fileRunner = scope.Resolve<IFileRunner>();
                    await fileRunner.Process(args[1], args[2], args[3]);
                }
                else
                {
                    Console.WriteLine("Check your input parameters");
                }

            }
        }
    }
}