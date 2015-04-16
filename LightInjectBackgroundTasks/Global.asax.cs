using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using LightInjectBackgroundTasks.Services;
using LightInjectBackgroundTasks.LightInject;

namespace LightInjectBackgroundTasks
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static ServiceContainer Container;

        public Task bgTask;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Container = new ServiceContainer();
            Container.RegisterControllers();
            Container.Register<SomeService>(new PerScopeLifetime());
            Container.EnableMvc();
            Container.ScopeManagerProvider = new PerLogicalCallContextScopeManagerProvider();

            bgTask = Task.Run(() => BackgroundTask.DoSomething());
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            Container.BeginScope();
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            Container.EndCurrentScope();
        }
    }
}
