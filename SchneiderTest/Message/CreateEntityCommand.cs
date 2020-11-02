using NServiceBus;
using System;

namespace Message
{
    public class CreateEntityCommand: ICommand
    {
        public string EntityType { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Ip { get; set; }
        public int? Port { get; set; }
    }
}
