namespace PatchKit.Logging
{
    public class DummyLogger : ILogger
    {
        private static DummyLogger _instance;

        public static DummyLogger Instance => _instance ?? (_instance = new DummyLogger());

        public void Log(Message message)
        {
            // do nothing
        }
    }
}