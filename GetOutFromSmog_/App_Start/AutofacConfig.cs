using Autofac;
using Autofac.Integration.Mvc;
using GetOutFromSmog_.Interfaces;
using GetOutFromSmog_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetOutFromSmog_.App_Start
{
public class AutofacConfig
{
    public static void ConfigureAutofac()
    {
        var builder = new ContainerBuilder();
        builder.RegisterControllers(typeof(MvcApplication).Assembly);
        builder.RegisterType<GetInfoAboutLongitude>().As<IGetInfoAboutCoordiateStation>();
        builder.RegisterType<ParseJsonToList>().As<IParseJsonToListAboutMeasureStation>();
        builder.RegisterType<ReturnNearestStationsIn100Km>().As<IReturnNearestStation>();
        var container = builder.Build();
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
}
}