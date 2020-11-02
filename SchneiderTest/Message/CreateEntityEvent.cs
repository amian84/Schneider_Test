using NServiceBus;
using System;
namespace Message
{
    public class CreateEntityEvent: IEvent
    {
        public string EntityType { get; set; }
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}
