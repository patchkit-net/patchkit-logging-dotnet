namespace PatchKit.Logging
{
    /// <summary>
    /// Dummy implementation of <see cref="ILogger"/>.
    /// </summary>
    public class DummyLogger : ILogger
    {
        private static DummyLogger _instance;

        /// <summary>
        /// Instance of <see cref="DummyLogger"/>.
        /// </summary>
        public static DummyLogger Instance => _instance ?? (_instance = new DummyLogger());

        /// <inheritdoc />
        public void Log(Message message)
        {
            // do nothing
        }
    }
}