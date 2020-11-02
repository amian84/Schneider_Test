using NServiceBus;
using System;
namespace Message
{
    /// <summary>
    /// Class to define the event of create entities
    /// </summary>
    public class CreateEntityEvent: IEvent
    {
        public string EntityType { get; set; }
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}
