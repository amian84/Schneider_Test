namespace SFrontForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabWM = new System.Windows.Forms.TabPage();
            this.tabEM = new System.Windows.Forms.TabPage();
            this.tabGW = new System.Windows.Forms.TabPage();
            this.btRefresh = new System.Windows.Forms.Button();
            this.getAllGatewaysResponseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGVWM = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabGW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getAllGatewaysResponseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVWM)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabWM);
            this.tabControl1.Controls.Add(this.tabEM);
            this.tabControl1.Controls.Add(this.tabGW);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1056, 507);
            this.tabControl1.TabIndex = 0;
            // 
            // tabWM
            // 
            this.tabWM.Location = new System.Drawing.Point(4, 25);
            this.tabWM.Name = "tabWM";
            this.tabWM.Padding = new System.Windows.Forms.Padding(3);
            this.tabWM.Size = new System.Drawing.Size(1024, 478);
            this.tabWM.TabIndex = 0;
            this.tabWM.Text = "Water Meter";
            this.tabWM.UseVisualStyleBackColor = true;
            // 
            // tabEM
            // 
            this.tabEM.Location = new System.Drawing.Point(4, 25);
            this.tabEM.Name = "tabEM";
            this.tabEM.Padding = new System.Windows.Forms.Padding(3);
            this.tabEM.Size = new System.Drawing.Size(1024, 478);
            this.tabEM.TabIndex = 1;
            this.tabEM.Text = "Electricity Meter";
            this.tabEM.UseVisualStyleBackColor = true;
            // 
            // tabGW
            // 
            this.tabGW.Controls.Add(this.dataGVWM);
            this.tabGW.Controls.Add(this.btRefresh);
            this.tabGW.Location = new System.Drawing.Point(4, 25);
            this.tabGW.Name = "tabGW";
            this.tabGW.Size = new System.Drawing.Size(1048, 478);
            this.tabGW.TabIndex = 2;
            this.tabGW.Text = "Gateway";
            this.tabGW.UseVisualStyleBackColor = true;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(842, 30);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(140, 35);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.Text = "Refresh List";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click_1);
            // 
            // getAllGatewaysResponseBindingSource
            // 
            this.getAllGatewaysResponseBindingSource.DataSource = typeof(SFrontForm.SBack.GetAllGatewaysResponse);
            // 
            // dataGVWM
            // 
            this.dataGVWM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVWM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.snumber,
            this.brand,
            this.model,
            this.ip,
            this.port});
            this.dataGVWM.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGVWM.Location = new System.Drawing.Point(18, 30);
            this.dataGVWM.Name = "dataGVWM";
            this.dataGVWM.ReadOnly = true;
            this.dataGVWM.RowTemplate.Height = 24;
            this.dataGVWM.Size = new System.Drawing.Size(807, 378);
            this.dataGVWM.TabIndex = 3;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // snumber
            // 
            this.snumber.HeaderText = "Serial Number";
            this.snumber.Name = "snumber";
            this.snumber.ReadOnly = true;
            // 
            // brand
            // 
            this.brand.HeaderText = "Brand";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            // 
            // model
            // 
            this.model.HeaderText = "Model";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            // 
            // ip
            // 
            this.ip.HeaderText = "Ip";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            // 
            // port
            // 
            this.port.HeaderText = "Port";
            this.port.Name = "port";
            this.port.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 507);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "SchneiderFront";
            this.tabControl1.ResumeLayout(false);
            this.tabGW.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.getAllGatewaysResponseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVWM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabWM;
        private System.Windows.Forms.TabPage tabEM;
        private System.Windows.Forms.TabPage tabGW;
        private System.Windows.Forms.BindingSource getAllGatewaysResponseBindingSource;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.DataGridView dataGVWM;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn snumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn port;
    }
}

