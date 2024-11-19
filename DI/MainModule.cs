using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LogixApi_v02.DI
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //builder.RegisterType<MainRepositoryManager>().As<IMainRepositoryManager>().InstancePerLifetimeScope();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.Load("LogixApi-v04"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
