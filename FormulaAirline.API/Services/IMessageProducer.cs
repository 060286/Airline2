namespace FormulaAirline.API.Services;

/// <summary>
/// Interface IMessageProducer
/// </summary>
public interface IMessageProducer
{
    public void SendingMessage<T>(T message);
}