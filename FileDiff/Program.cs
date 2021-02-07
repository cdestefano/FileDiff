using Autofac;
using FileDiff.Application.Directory;
using FileDiff.Application.IoC;

namespace FileDiff
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var defaultConfiguration = new DefaultConfiguration();

            using (var scope = defaultConfiguration.Container.BeginLifetimeScope())
            {
                var directoryProcessor = scope.Resolve<IFileGenerator>();
                directoryProcessor.Process(args[0], args[1], args[2]);
            }
        }
    }
}