using System;
using System.Threading.Tasks;
using Message;
using NServiceBus;
using SFrontForm.SBack;

namespace SFrontForm
{
    /// <summary>
    /// Class to handle create entity events
    /// </summary>
    public class CreateEntityEventReceiver : IHandleMessages<CreateEntityEvent>
    {
        /// <summary>
        /// Check type and code of soap response and show warning and refresh grid view depending of entity type
        /// </summary>
        /// <param name="message">Message contract</param>
        /// <param name="context">IMessageHandlerContext</param>
        /// <returns></returns>
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
