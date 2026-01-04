namespace Kolyya.Api.Messages
{
    public record TouristicCardOrdered(
        Guid OrderId,
        string CardTitle,
        string Destination,
        string OrderedBy,
        DateTime OrderedAt
    );
}