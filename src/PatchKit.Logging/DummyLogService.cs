namespace PatchKit.Logging
{
    public class DummyLogService : ILogService
    {
        private static DummyLogService _instance;

        public static DummyLogService Instance => _instance ?? (_instance = new DummyLogService());

        public void AddWriter(ILogWriter writer)
        {
            // do nothing because writers are not used anywhere
        }

        public void RemoveWriter(ILogWriter writer)
        {
            // do nothing because no writers are registered
        }

        public void Log(LogMessage message)
        {
            // do nothing
        }
    }
}