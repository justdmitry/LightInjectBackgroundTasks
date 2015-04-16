using System;

namespace LightInjectBackgroundTasks.Services
{
    public class SomeService
    {
        public DateTimeOffset GetNow()
        {
            return DateTimeOffset.Now;
        }
    }
}