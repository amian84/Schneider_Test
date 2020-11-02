namespace SFrontForm
{
    partial class CreateEntity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSN = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lbSN = new System.Windows.Forms.Label();
            this.lbBrand = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.lbIp = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chNService = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtSN
            // 
            this.txtSN.Location = new System.Drawing.Point(120, 20);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(249, 22);
            this.txtSN.TabIndex = 0;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(120, 69);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(249, 22);
            this.txtBrand.TabIndex = 1;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(120, 120);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(249, 22);
            this.txtModel.TabIndex = 2;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(120, 176);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(145, 22);
            this.txtIp.TabIndex = 3;
            this.txtIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIp_KeyPress);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(326, 176);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(43, 22);
            this.txtPort.TabIndex = 4;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // lbSN
            // 
            this.lbSN.AutoSize = true;
            this.lbSN.Location = new System.Drawing.Point(12, 23);
            this.lbSN.Name = "lbSN";
            this.lbSN.Size = new System.Drawing.Size(102, 17);
            this.lbSN.TabIndex = 5;
            this.lbSN.Text = "Serial Number:";
            // 
            // lbBrand
            // 
            this.lbBrand.AutoSize = true;
            this.lbBrand.Location = new System.Drawing.Point(12, 74);
            this.lbBrand.Name = "lbBrand";
            this.lbBrand.Size = new System.Drawing.Size(50, 17);
            this.lbBrand.TabIndex = 6;
            this.lbBrand.Text = "Brand:";
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Location = new System.Drawing.Point(12, 123);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(50, 17);
            this.lbModel.TabIndex = 7;
            this.lbModel.Text = "Model:";
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Location = new System.Drawing.Point(12, 181);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(23, 17);
            this.lbIp.TabIndex = 8;
            this.lbIp.Text = "Ip:";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(282, 179);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(38, 17);
            this.lbPort.TabIndex = 9;
            this.lbPort.Text = "Port:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(289, 282);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 33);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(184, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 33);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chNService
            // 
            this.chNService.AutoSize = true;
            this.chNService.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chNService.Location = new System.Drawing.Point(12, 234);
            this.chNService.Name = "chNService";
            this.chNService.Size = new System.Drawing.Size(162, 21);
            this.chNService.TabIndex = 12;
            this.chNService.Text = "Send via NbusSerice";
            this.chNService.UseVisualStyleBackColor = true;
            // 
            // CreateEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 339);
            this.Controls.Add(this.chNService);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbIp);
            this.Controls.Add(this.lbModel);
            this.Controls.Add(this.lbBrand);
            this.Controls.Add(this.lbSN);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtSN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateEntity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateEntity";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lbSN;
        private System.Windows.Forms.Label lbBrand;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chNService;
    }
}