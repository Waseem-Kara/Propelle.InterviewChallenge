namespace Propelle.InterviewChallenge.Application.EventBus
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent @event, TransientException message = null) where TEvent : class;
    }
}
