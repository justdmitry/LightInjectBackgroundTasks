using System;
using System.Threading;

namespace LightInjectBackgroundTasks.Services
{
    public class BackgroundTask
    {
        public static void DoSomething()
        {
            Thread.Sleep(20 * 1000); // 20 sec

            // ORIGINALLY:
            // will fail there with
            //  Object reference not set to an instance of an object
            //    at LightInject.Web.PerWebRequestScopeManagerProvider.GetScopeManager() 
            //      in c:\GitHub\LightInject\NuGet\Build\Net45\LightInject.Web\LightInject.Web.cs:line 149
            using (MvcApplication.Container.BeginScope())
            {
                var service = MvcApplication.Container.GetInstance<SomeService>();
                var t = service.GetNow();
            }
        }
    }
}