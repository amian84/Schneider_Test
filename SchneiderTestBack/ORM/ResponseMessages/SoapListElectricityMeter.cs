
using ORM.Model;
using System.Collections.Generic;

namespace ORM.ResponseMessages
{
    /// <summary>
    /// Class to set soap message
    /// </summary>
    public class SoapListElectricityMeter : SOAPResponse
    {
        /// <summary>
        /// List of entities
        /// </summary>
        public List<ElectricityMeter> Entities { get; set; }
    }
}
