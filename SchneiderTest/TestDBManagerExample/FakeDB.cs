using ORM;
using ORM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDBManagerExample
{
    public class FakeDB : IDataModel
    {
        public List<Gateway> Gateways;

        public Gateway AddGateway(Gateway gw)
        {
            Gateways.Add(gw);
            return gw;
        }

        public void Dispose()
        {
            Gateways.Clear();
        }

        public IEnumerable<Gateway> GetGateways()
        {
            return Gateways;
        }
    }
}
