using Propelle.InterviewChallenge.EventHandling;

namespace Propelle.InterviewChallenge.Application.EventBus
{
    public class SimpleEventBus : IEventBus
    {
        private readonly InMemoryEventExchange _exchange;

        public SimpleEventBus(InMemoryEventExchange exchange)
        {
            _exchange = exchange;
        }

        public async Task Publish<TEvent>(TEvent @event, TransientException error = null)
            where TEvent : class
        {
            try
            {
                /* If you've found this, you're eagled-eyed! Let us know in the interview if you see this, and have a think about the ramifications of 
                * changing SimulatePotentialFailure() to have a higher than zero chance of throwing an exception (i.e. simulating a real event-bus being unavailable at times) */
                PointOfFailure.SimulatePotentialFailure();

                await _exchange.Publish(@event);
            }
            catch (TransientException e)
            {
                await Publish(@event, e);
            }
        }
    }
}
