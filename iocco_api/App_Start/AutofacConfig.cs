using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iocco_api.DataLayer;
using iocco_api.BusinessLayer;
using System.Web.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace iocco_api.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<EmployeeDatabase>()
                .As<IDbContext>()
                .As<EmployeeDatabase>()
                .InstancePerRequest()
                .PropertiesAutowired();
            builder.RegisterGeneric(typeof(BaseRepository<>))
                   .As(typeof(IBaseRepository<>))
                   .InstancePerRequest();
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}