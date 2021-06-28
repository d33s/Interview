namespace Interview.App_Start
{
    using Autofac;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Interview.DataAccessLayer;

    internal static class Registration
    {
        public static IContainer CreateContainerInstance()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonDataAccess>().As<IDataAccess>();
            return builder.Build();
        }
    }
}