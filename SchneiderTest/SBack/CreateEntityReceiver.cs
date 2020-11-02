using Message;
using NServiceBus;
using ORM;
using ORM.Model;
using ORM.ResponseMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SBack
{
    /// <summary>
    /// Class to handle command createEntity
    /// </summary>
    public class CreateEntityReceiver : IHandleMessages<CreateEntityCommand>
    {
        /// <summary>
        /// Check create entity and call to ORM with correct entity to create it
        /// and publish response as CreateEntityEvent
        /// </summary>
        /// <param name="message">CreateEntityCommand command</param>
        /// <param name="context">IMessageHandlerContext</param>
        /// <returns>Publish task</returns>
        public Task Handle(CreateEntityCommand message, IMessageHandlerContext context)
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
            SOAPResponse response = DBManager.Get().CreateEntity(
                entType,
                message.SerialNumber,
                message.Brand,
                message.Model,
                message.Ip,
                message.Port);
            CreateEntityEvent createEvent = new CreateEntityEvent();
            createEvent.Code = response.Code;
            createEvent.Msg = response.Msg;
            createEvent.EntityType = message.EntityType;
            return context.Publish(createEvent);
        }
    }
}