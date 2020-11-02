using System;
using System.Threading.Tasks;
using Message;
using NServiceBus;
using SFrontForm.SBack;

namespace SFrontForm
{
    public class CreateEntityEventReceiver : IHandleMessages<CreateEntityEvent>
    {
        public Task Handle(CreateEntityEvent message, IMessageHandlerContext context)
        {
            Type entType = null;
            if (message.EntityType == "gw")
            {
                entType = typeof(Gateway);
            }
            if (message.EntityType == "em")
            {
                entType = typeof(ElectricityMeter);
            }
            if (message.EntityType == "wm")
            {
                entType = typeof(WaterMeter);
            }
            if (message.Code != 200)
            {
                Form1.Instance.ShowError(message.Msg);
            }
            Form1.Instance.RefreshGV(entType);
            return Task.CompletedTask;
        }
    }
}
