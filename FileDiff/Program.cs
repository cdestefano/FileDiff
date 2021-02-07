using System.Threading.Tasks;
using Autofac;
using FileDiff.Application.FileGenerator;
using FileDiff.Application.IoC;

namespace FileDiff
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var defaultConfiguration = new DefaultConfiguration();

            using (var scope = defaultConfiguration.Container.BeginLifetimeScope())
            {
                var directoryProcessor = scope.Resolve<IFileGenerator>();
                await directoryProcessor.Process(args[0], args[1], args[2]);
            }
        }
    }
}