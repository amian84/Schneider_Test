using ORM.Model;
using System;
using System.Collections.Generic;

namespace ORM
{
    public interface IDataModel: IDisposable
    {
        IEnumerable<Gateway> GetGateways();
        Gateway AddGateway(Gateway gw);
    }
}