namespace SkydivingCRM.SkydivingClubService.Business.RabbitMq.Senders
{
    public interface ISender<in TRabbitMqEvent> 
    {
        void Send(TRabbitMqEvent ev);
    }
}