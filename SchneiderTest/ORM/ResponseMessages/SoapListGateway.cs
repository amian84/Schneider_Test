using ORM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.ResponseMessages
{
    /// <summary>
    /// Class to set soap message
    /// </summary>
    public class SoapListGateway: SOAPResponse
    {
        /// <summary>
        /// List of entities
        /// </summary>
        public List<Gateway> Entities { get; set; }
    }
}
