using System;
using Autofac;

namespace IocModule
{
    public class IoC
    {
        private readonly IContainer _container;
        private static readonly Lazy<IoC> Instance = new Lazy<IoC>(() => new IoC());

        private IoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MainModule>();
            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Instance.Value._container.Resolve<T>();
        }
    }
}