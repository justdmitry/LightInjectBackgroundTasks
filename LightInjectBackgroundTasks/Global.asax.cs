using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using LightInject;
using LightInjectBackgroundTasks.Services;

namespace LightInjectBackgroundTasks
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static ServiceContainer Container;

        public Task bgTask;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Container = new ServiceContainer();
            Container.ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider();
            Container.RegisterControllers();
            Container.Register<SomeService>(new PerScopeLifetime());
            Container.EnableMvc();

            bgTask = Task.Run(() => BackgroundTask.DoSomething());
        }
    }
}
