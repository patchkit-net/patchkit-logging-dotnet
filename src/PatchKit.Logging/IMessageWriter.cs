namespace PatchKit.Logging
{
    public interface IMessageWriter
    {
        void Write(Message message, MessageContext messageContext);
    }
}