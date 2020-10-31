using SFrontForm.SBack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFrontForm
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }


        private void btRefresh_Click_1(object sender, EventArgs e)
        {
            
            SBack.ServiceSoap soap = new SBack.ServiceSoapClient();
            SBack.GetAllGatewaysRequest rq = new SBack.GetAllGatewaysRequest();

            SBack.GetAllGatewaysResponse res = soap.GetAllGateways(rq);
            if (res.Body.GetAllGatewaysResult.Code == 200)
            {
                foreach (Gateway gw in res.Body.GetAllGatewaysResult.Entities)
                {
                    dataGVWM.Rows.Add(gw.Id.ToString(), gw.SerialNumber, gw.Brand, gw.Model, gw.Ip, gw.Port.ToString());
                }
            }

            


        }

        private void dataGVWM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
