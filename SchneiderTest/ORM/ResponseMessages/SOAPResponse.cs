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
    public class SOAPResponse
    {
        /// <summary>
        /// Code of soap return message
        /// </summary>
        public int Code { get; set; }
        // <summary>
        /// Message to return in soap response
        /// </summary>
        public string Msg { get; set; }
    }
}
