using Kolyya.Api.Messages;
using MassTransit;

namespace Kolyya.Api.Consumers
{
    public class TouristicCardOrderedConsumer : IConsumer<TouristicCardOrdered>
    {
        public Task Consume(ConsumeContext<TouristicCardOrdered> context)
        {
            var message = context.Message;

            Console.WriteLine("📬 Commande reçue !");
            Console.WriteLine($"🧾 Destination: {message.Destination}");
            Console.WriteLine($"🧾 Titre: {message.CardTitle}");
            Console.WriteLine($"🧾 Utilisateur: {message.OrderedBy}");

            // (tu peux plus tard sauvegarder en DB, appeler un email, etc.)

            return Task.CompletedTask;
        }
    }
}
