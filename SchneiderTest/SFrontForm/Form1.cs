using Message;
using NServiceBus;
using SFrontForm.SBack;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFrontForm
{
    public partial class Form1 : Form
    {
        private IEndpointInstance _endpointInstance;
        private ServiceSoap Soap;
        //Static instance to get from others class
        public static Form1 Instance { get; set; }
        public Form1()
        {
            InitializeComponent();
            Soap = new ServiceSoapClient();
            InitializeSenderNBusAsync().GetAwaiter().GetResult();
            Form1.Instance = this;
        }

        /// <summary>
        /// Function to return endpoint for NServiceBus
        /// </summary>
        /// <returns>IEndpointInstance with endpoint</returns>
        public IEndpointInstance GetEndpoint()
        {
            return _endpointInstance;
        }

        /// <summary>
        /// Function to show message box warning
        /// </summary>
        /// <param name="msg">message</param>
        public void ShowError(string msg)
        {
            MessageBox.Show(
                "Some error occur creating entity from other process: " + msg,
                "Warn",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }


        /// <summary>
        /// Initialize Nbus configuration, in that case we configure SFrontForm
        /// as a endpoint to send commands. Define route of CreateEntityCommand
        /// to endpoint SBack
        /// </summary>
        /// <returns>Task of async awaiter</returns>
        private async Task InitializeSenderNBusAsync()
        {
            var endpointConfiguration = new EndpointConfiguration("SFrontForm");

            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(CreateEntityCommand), "SBack");

            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.AuditProcessedMessagesTo("audit");
           
            _endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Refresh grid view for gateways
        /// </summary>
        /// <param name="sender">Button control</param>
        /// <param name="e">Arguments of event</param>
        private void btRefresh_Click_1(object sender, EventArgs e)
        {
            
            GetAllGatewaysRequest rq = new GetAllGatewaysRequest();

            GetAllGatewaysResponse res = Soap.GetAllGateways(rq);
            if (res.Body.GetAllGatewaysResult.Code == 200)
            {
                if (dataGVEM.InvokeRequired)
                {
                    dataGVGW.Invoke((System.Threading.ThreadStart)delegate
                    {
                        dataGVGW.Rows.Clear();
                    });
                }
                else
                {
                    dataGVGW.Rows.Clear();
                }
                    
                foreach (Gateway gw in res.Body.GetAllGatewaysResult.Entities)
                {
                    if (dataGVEM.InvokeRequired)
                    {
                        dataGVGW.Invoke((System.Threading.ThreadStart)delegate
                        {
                            dataGVGW.Rows.Add(
                                gw.Id.ToString(), 
                                gw.SerialNumber, 
                                gw.Brand, 
                                gw.Model, 
                                gw.Ip, 
                                gw.Port.ToString()
                            );
                        });
                    }
                    else
                    {
                        dataGVGW.Rows.Add(
                            gw.Id.ToString(), 
                            gw.SerialNumber, 
                            gw.Brand, 
                            gw.Model, 
                            gw.Ip, 
                            gw.Port.ToString()
                        );
                    }
                    
                }
            }
            
        }

        /// <summary>
        /// Refresh grid view for electricity meters
        /// </summary>
        /// <param name="sender">button control</param>
        /// <param name="e">arguents of event</param>
        private void btnRefreshEM_Click(object sender, EventArgs e)
        {
            GetAllElectricityMeterRequest rq = new GetAllElectricityMeterRequest();

            GetAllElectricityMeterResponse res = Soap.GetAllElectricityMeter(rq);
            if (res.Body.GetAllElectricityMeterResult.Code == 200)
            {
                if (dataGVEM.InvokeRequired)
                {
                    dataGVEM.Invoke((System.Threading.ThreadStart)delegate
                    {
                        dataGVEM.Rows.Clear();
                    });
                }
                else
                {
                    dataGVEM.Rows.Clear();
                }
                foreach (ElectricityMeter em in res.Body.GetAllElectricityMeterResult.Entities)
                {
                    if (dataGVEM.InvokeRequired)
                    {
                        dataGVEM.Invoke((System.Threading.ThreadStart)delegate
                        {
                            dataGVEM.Rows.Add(em.Id.ToString(), em.SerialNumber, em.Brand, em.Model);
                        });
                    }
                    else
                    {
                        dataGVEM.Rows.Add(em.Id.ToString(), em.SerialNumber, em.Brand, em.Model);
                    }
                        
                }
            }
        }

        /// <summary>
        /// Refresh grid view for water meters
        /// </summary>
        /// <param name="sender">button control</param>
        /// <param name="e">arguments of event</param>
        private void btnRefreshWM_Click(object sender, EventArgs e)
        {
            GetAllWaterMeterRequest rq = new GetAllWaterMeterRequest();
            GetAllWaterMeterResponse res = Soap.GetAllWaterMeter(rq);
            if (res.Body.GetAllWaterMeterResult.Code == 200)
            {
                if (dataGVWM.InvokeRequired)
                {
                    dataGVWM.Invoke((System.Threading.ThreadStart)delegate
                    {
                        dataGVWM.Rows.Clear();
                    });
                }
                else
                {
                    dataGVWM.Rows.Clear();
                }
                
                foreach (WaterMeter wm in res.Body.GetAllWaterMeterResult.Entities)
                {
                    if (dataGVWM.InvokeRequired)
                    {
                        dataGVWM.Invoke((System.Threading.ThreadStart)delegate
                        {
                            dataGVWM.Rows.Add(wm.Id.ToString(), wm.SerialNumber, wm.Brand, wm.Model);
                        });
                    }
                    else
                    {
                        dataGVWM.Rows.Add(wm.Id.ToString(), wm.SerialNumber, wm.Brand, wm.Model);
                    }
                }
            }
        }


        /// <summary>
        /// Function to refresh a grid view depends of entity type
        /// </summary>
        /// <param name="entType">Entity type</param>
        public void RefreshGV(Type entType)
        {
            if (entType == typeof(Gateway))
            {
                btRefresh_Click_1(null, null);
            }
            else if (entType == typeof(ElectricityMeter))
            {
                btnRefreshEM_Click(null, null);
            }
            else if (entType == typeof(WaterMeter))
            {
                btnRefreshWM_Click(null, null);
            }
        }


        /// <summary>
        /// Create Water Meter using SOAP
        /// </summary>
        /// <param name="sender">button control</param>
        /// <param name="e">arguments of event</param>
        private void btnCreateWM_Click(object sender, EventArgs e)
        {
            CreateEntity ce = new CreateEntity(this);
            ce.SetEntityType(typeof(WaterMeter));
            ce.ShowDialog();
        }

        /// <summary>
        /// Create Electricity Meter using SOAP
        /// </summary>
        /// <param name="sender">button control</param>
        /// <param name="e">arguments of event</param>
        private void btnCreateEM_Click(object sender, EventArgs e)
        {
            CreateEntity ce = new CreateEntity(this);
            ce.SetEntityType(typeof(ElectricityMeter));
            ce.ShowDialog();
        }

        /// <summary>
        /// Create Gateway using SOAP
        /// </summary>
        /// <param name="sender">button control</param>
        /// <param name="e">arguments of event</param>
        private void btnCreateGW_Click(object sender, EventArgs e)
        {
            CreateEntity ce = new CreateEntity(this);
            ce.SetEntityType(typeof(Gateway));
            ce.ShowDialog();
        }

        /// <summary>
        /// Function to eliminate the entity by serial number that is selected in the gridview depending on the type of entity
        /// </summary>
        /// <param name="dataGV">DataGridView control</param>
        /// <param name="entType">Type of entity</param>
        private string DeleteSerialEntitySelected(DataGridView dataGV, Type entType)
        {
            string serial = null;
            DataGridViewSelectedRowCollection selected = dataGV.SelectedRows;
            if (selected.Count > 0)
            {
                foreach (DataGridViewRow row in selected)
                {
                    serial = row.Cells[1].Value.ToString();
                    DialogResult resultDR = MessageBox.Show(
                        "Are you sure to delete element with serial: " + serial,
                        "Delete",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);
                    if (resultDR == DialogResult.OK)
                    {
                        if (entType == typeof(Gateway))
                        {
                            DeleteGW(serial);
                        }
                        else if (entType == typeof(WaterMeter))
                        {
                            DeleteWM(serial);
                        }
                        else if (entType == typeof(ElectricityMeter))
                        {
                            DeleteEM(serial);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "You must select a element from gid",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            return serial;
        }

        /// <summary>
        /// Function to delete gateway by serial using SOAP
        /// </summary>
        /// <param name="serial">serial number</param>
        private void DeleteGW(string serial)
        {
            DeleteGatewayBySerialRequest rq = new DeleteGatewayBySerialRequest();
            rq.Body = new DeleteGatewayBySerialRequestBody();
            rq.Body.serial = serial;
            DeleteGatewayBySerialResponse result = Soap.DeleteGatewayBySerial(rq);
            if (result.Body.DeleteGatewayBySerialResult.Code != 200)
            {
                MessageBox.Show(
                    "Error deleting element with serial: " + serial + ", message:" + result.Body.DeleteGatewayBySerialResult.Msg,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                btRefresh_Click_1(null, null);
            }
        }

        /// <summary>
        /// Function to delete electricity meter by serial using SOAP
        /// </summary>
        /// <param name="serial">serial number</param>
        private void DeleteEM(string serial)
        {
            DeleteElectricityMeterBySerialRequest rq = new DeleteElectricityMeterBySerialRequest();
            rq.Body = new DeleteElectricityMeterBySerialRequestBody();
            rq.Body.serial = serial;
            DeleteElectricityMeterBySerialResponse result = Soap.DeleteElectricityMeterBySerial(rq);
            if (result.Body.DeleteElectricityMeterBySerialResult.Code != 200)
            {
                MessageBox.Show(
                    "Error deleting element with serial: " + serial + ", message:" + result.Body.DeleteElectricityMeterBySerialResult.Msg,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                btnRefreshEM_Click(null, null);
            }
        }

        /// <summary>
        /// Function to delete water meter by serial using SOAP
        /// </summary>
        /// <param name="serial">serial number</param>
        private void DeleteWM(string serial)
        {
            DeleteWaterMeterBySerialRequest rq = new DeleteWaterMeterBySerialRequest();
            rq.Body = new DeleteWaterMeterBySerialRequestBody();
            rq.Body.serial = serial;
            DeleteWaterMeterBySerialResponse result = Soap.DeleteWaterMeterBySerial(rq);
            if (result.Body.DeleteWaterMeterBySerialResult.Code != 200)
            {
                MessageBox.Show(
                    "Error deleting element with serial: " + serial + ", message:" + result.Body.DeleteWaterMeterBySerialResult.Msg,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                btnRefreshWM_Click(null, null);
            }
        }

        /// <summary>
        /// Delete Gateway by serial
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args</param>
        private void btnDeleteGW_Click(object sender, EventArgs e)
        {
            DeleteSerialEntitySelected(dataGVGW, typeof(Gateway));
        }

        /// <summary>
        /// Delete Electricity Meter by serial
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args</param>
        private void btnDeleteEM_Click(object sender, EventArgs e)
        {
            DeleteSerialEntitySelected(dataGVEM, typeof(ElectricityMeter));
        }

        /// <summary>
        /// Delete Water Meter by serial
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args</param>
        private void btnDeleteWM_Click(object sender, EventArgs e)
        {
            DeleteSerialEntitySelected(dataGVEM, typeof(WaterMeter));
        }

        /// <summary>
        /// Stop endpoint when form closing
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event args</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _endpointInstance?.Stop().GetAwaiter().GetResult();
        }


    }
}
