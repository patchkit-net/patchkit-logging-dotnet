namespace PatchKit.Logging
{
    public interface IMessageFormatter
    {
        string Format(Message message, MessageContext messageContext);
    }
}