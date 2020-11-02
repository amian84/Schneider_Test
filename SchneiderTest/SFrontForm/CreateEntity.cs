using Message;
using SFrontForm.SBack;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFrontForm
{
    public struct ResponseSOAP
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
    public partial class CreateEntity : Form
    {
        private ServiceSoap Soap;
        private Type EntType;
        private Form1 ParentFormFront;
        public CreateEntity(Form1 parentForm)
        {
            InitializeComponent();
            Soap = new ServiceSoapClient();
            ParentFormFront = parentForm;
        }

        /// <summary>
        /// Set type of entity to create.
        /// Check type and enable ip and port if is GW
        /// </summary>
        /// <param name="ent">Entity type, can be (Gateway, ElectricityMeter or WaterMeter)</param>
        public void SetEntityType(Type ent)
        {
            EntType = ent;
            bool visible = false;
            if (ent == typeof(Gateway))
            {
                visible = true;
            }
            lbIp.Visible = visible;
            lbPort.Visible = visible;
            txtIp.Visible = visible;
            txtPort.Visible = visible;
        }

        /// <summary>
        /// Close windows
        /// </summary>
        /// <param name="sender">button control</param>
        /// <param name="e">Arguments for event that fire the click button</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


        /// <summary>
        /// Get data from all textbox and call to SOAP back to create
        /// the entity depends of entity type variable or send via nbusservice
        /// </summary>
        /// <param name="sender">button control</param>
        /// <param name="e">Arguments for event that fire the click button</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string serialNumber = txtSN.Text;
            string brand = txtBrand.Text;
            string model = txtModel.Text;
            string ip = txtIp.Text;
            string port = txtPort.Text;
            if (chNService.Checked)
            {
                SendByNBus(serialNumber, brand, model, ip, port).GetAwaiter().GetResult();
                this.Close();
                this.Dispose();
            }
            else
            {
                ResponseSOAP response = new ResponseSOAP();
                response.Code = 500;
                response.Message = "Can't create entity for unkonwn entity";
                
                if (EntType == typeof(Gateway))
                {
                    response = CreateGW(serialNumber, brand, model, ip, port);
                }
                else if (EntType == typeof(ElectricityMeter))
                {
                    response = CreateEM(serialNumber, brand, model);
                }
                else if (EntType == typeof(WaterMeter))
                {
                    response = CreateWM(serialNumber, brand, model);
                }
                if (response.Code != 200)
                {
                    MessageBox.Show(
                        "Error creating entity: " + response.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    ParentFormFront.RefreshGV(EntType);
                    this.Close();
                    this.Dispose();
                }
            }
            
        }


        /// <summary>
        /// Call Soap method to create Water Meter entity
        /// </summary>
        /// <param name="serialNumber">Serial Number</param>
        /// <param name="brand">Brand </param>
        /// <param name="model">Model</param>
        /// <returns>ResponseSOAP object with Soap response </returns>
        private ResponseSOAP CreateWM(string serialNumber, string brand, string model)
        {
            ResponseSOAP response = new ResponseSOAP();
            CreateWaterMeterRequest rq = new CreateWaterMeterRequest();
            rq.Body = new CreateWaterMeterRequestBody();
            rq.Body.serial = serialNumber;
            rq.Body.brand = brand;
            rq.Body.model = model;

            CreateWaterMeterResponse res = Soap.CreateWaterMeter(rq);
            response.Code = res.Body.CreateWaterMeterResult.Code;
            response.Message = res.Body.CreateWaterMeterResult.Msg;
            return response;
        }

        /// <summary>
        /// Call Soap method to create Electricity Meter entity
        /// </summary>
        /// <param name="serialNumber">Serial Number</param>
        /// <param name="brand">Brand </param>
        /// <param name="model">Model</param>
        /// <returns>ResponseSOAP object with Soap response </returns>
        private ResponseSOAP CreateEM(string serialNumber, string brand, string model)
        {
            ResponseSOAP response = new ResponseSOAP();
            CreateElectricityMeterRequest rq = new CreateElectricityMeterRequest();
            rq.Body = new CreateElectricityMeterRequestBody();
            rq.Body.serial = serialNumber;
            rq.Body.brand = brand;
            rq.Body.model = model;

            CreateElectricityMeterResponse res = Soap.CreateElectricityMeter(rq);
            response.Code = res.Body.CreateElectricityMeterResult.Code;
            response.Message = res.Body.CreateElectricityMeterResult.Msg;
            return response;
        }

        /// <summary>
        /// Call Soap method to create Gateway entity
        /// </summary>
        /// <param name="serialNumber">Serial Number</param>
        /// <param name="brand">Brand </param>
        /// <param name="model">Model</param>
        /// <param name="ip">IP</param>
        /// <param name="port">Port</param>
        /// <returns>ResponseSOAP object with Soap response </returns>
        private ResponseSOAP CreateGW(string serialNumber, string brand, string model, string ip, string port)
        {
            ResponseSOAP response = new ResponseSOAP();
            CreateGatewayRequest rq = new CreateGatewayRequest();
            rq.Body = new CreateGatewayRequestBody();
            rq.Body.serial = serialNumber;
            rq.Body.brand = brand;
            rq.Body.model = model;
            rq.Body.ip = ip;
            rq.Body.port = port;
            CreateGatewayResponse res = Soap.CreateGateway(rq);
            response.Code = res.Body.CreateGatewayResult.Code;
            response.Message = res.Body.CreateGatewayResult.Msg;
            return response;
        }

        /// <summary>
        ///  Only allow numbers and dots in textbox for IP
        /// </summary>
        /// <param name="sender">text box control</param>
        /// <param name="e">key pressed event</param>
        private void txtIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Only allow numbers in textbox for Port
        /// </summary>
        /// <param name="sender">text box control</param>
        /// <param name="e">key pressed event</param>
        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public async Task SendByNBus(
            string serialNumber, 
            string brand, 
            string model, 
            string ip, 
            string port
        )
        {
            var command = new CreateEntityCommand ();
            string entType = "";
            if (typeof(Gateway) == EntType)
            {
                entType = "gw";
            }
            if (typeof(WaterMeter) == EntType)
            {
                entType = "wm";
            }
            if (typeof(ElectricityMeter) == EntType)
            {
                entType = "em";
            }
            command.EntityType = entType;
            command.SerialNumber = serialNumber;
            command.Brand = brand;
            command.Model = model;
            command.Ip = ip;
            int? portConverted = null;
            if (!string.IsNullOrEmpty(port))
            {
                int portInt;
                int.TryParse(port, out portInt);
                portConverted = portInt;
            }
            command.Port = portConverted;

            // Send the command
            await ParentFormFront.GetEndpoint().Send(command, new NServiceBus.SendOptions())
                .ConfigureAwait(false);
        }
    }
}
