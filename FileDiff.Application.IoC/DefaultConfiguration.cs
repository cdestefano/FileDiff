using Autofac;
using FileDiff.Application.Directory;
using FileDiff.Application.Validation;

namespace FileDiff.Application.IoC
{
    public class DefaultConfiguration
    {
        public DefaultConfiguration()
        {
            var builder = new ContainerBuilder();

            RegisterComponents(builder);

            Container = builder.Build();
        }

        public IContainer Container { get; set; }

        private void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<Directory.Directory>().As<IDirectory>();
            builder.RegisterType<FileGenerator>().As<IFileGenerator>();
            builder.RegisterType<Input>().As<IInput>();
            builder.RegisterType<Validator>().As<IValidator>();

            // Implement a real logger if you want to redirect errors outside of the Console.
            builder.RegisterType<ErrorLogger>().As<IErrorLogger>();
        }
    }
}