using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SBack
{
    public class Global : System.Web.HttpApplication
    {
        public static IEndpointInstance _endpointInstance;
        protected void Application_Start(object sender, EventArgs e)
        {
            AsyncStart().GetAwaiter().GetResult();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            _endpointInstance?.Stop().GetAwaiter().GetResult();
        }

        async Task AsyncStart()
        {
            var endpointConfiguration = new EndpointConfiguration("SBack");

            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            
            _endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);
        }
    }
}