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
            this.btnDeleteWM = new System.Windows.Forms.Button();
            this.btnCreateWM = new System.Windows.Forms.Button();
            this.dataGVWM = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefreshWM = new System.Windows.Forms.Button();
            this.tabEM = new System.Windows.Forms.TabPage();
            this.btnDeleteEM = new System.Windows.Forms.Button();
            this.btnCreateEM = new System.Windows.Forms.Button();
            this.dataGVEM = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefreshEM = new System.Windows.Forms.Button();
            this.tabGW = new System.Windows.Forms.TabPage();
            this.btnDeleteGW = new System.Windows.Forms.Button();
            this.btnCreateGW = new System.Windows.Forms.Button();
            this.dataGVGW = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btRefreshGW = new System.Windows.Forms.Button();
            this.getAllGatewaysResponseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabWM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVWM)).BeginInit();
            this.tabEM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVEM)).BeginInit();
            this.tabGW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVGW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAllGatewaysResponseBindingSource)).BeginInit();
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
            this.tabWM.Controls.Add(this.btnDeleteWM);
            this.tabWM.Controls.Add(this.btnCreateWM);
            this.tabWM.Controls.Add(this.dataGVWM);
            this.tabWM.Controls.Add(this.btnRefreshWM);
            this.tabWM.Location = new System.Drawing.Point(4, 25);
            this.tabWM.Name = "tabWM";
            this.tabWM.Padding = new System.Windows.Forms.Padding(3);
            this.tabWM.Size = new System.Drawing.Size(1048, 478);
            this.tabWM.TabIndex = 0;
            this.tabWM.Text = "Water Meter";
            this.tabWM.UseVisualStyleBackColor = true;
            // 
            // btnDeleteWM
            // 
            this.btnDeleteWM.Location = new System.Drawing.Point(866, 180);
            this.btnDeleteWM.Name = "btnDeleteWM";
            this.btnDeleteWM.Size = new System.Drawing.Size(156, 35);
            this.btnDeleteWM.TabIndex = 11;
            this.btnDeleteWM.Text = "Delete Water Meter";
            this.btnDeleteWM.UseVisualStyleBackColor = true;
            this.btnDeleteWM.Click += new System.EventHandler(this.btnDeleteWM_Click);
            // 
            // btnCreateWM
            // 
            this.btnCreateWM.Location = new System.Drawing.Point(866, 116);
            this.btnCreateWM.Name = "btnCreateWM";
            this.btnCreateWM.Size = new System.Drawing.Size(156, 35);
            this.btnCreateWM.TabIndex = 6;
            this.btnCreateWM.Text = "Create Water Meter";
            this.btnCreateWM.UseVisualStyleBackColor = true;
            this.btnCreateWM.Click += new System.EventHandler(this.btnCreateWM_Click);
            // 
            // dataGVWM
            // 
            this.dataGVWM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVWM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGVWM.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGVWM.Location = new System.Drawing.Point(42, 50);
            this.dataGVWM.MultiSelect = false;
            this.dataGVWM.Name = "dataGVWM";
            this.dataGVWM.ReadOnly = true;
            this.dataGVWM.RowTemplate.Height = 24;
            this.dataGVWM.Size = new System.Drawing.Size(807, 378);
            this.dataGVWM.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "id";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Serial Number";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Brand";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Model";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // btnRefreshWM
            // 
            this.btnRefreshWM.Location = new System.Drawing.Point(866, 50);
            this.btnRefreshWM.Name = "btnRefreshWM";
            this.btnRefreshWM.Size = new System.Drawing.Size(156, 35);
            this.btnRefreshWM.TabIndex = 4;
            this.btnRefreshWM.Text = "Refresh List";
            this.btnRefreshWM.UseVisualStyleBackColor = true;
            this.btnRefreshWM.Click += new System.EventHandler(this.btnRefreshWM_Click);
            // 
            // tabEM
            // 
            this.tabEM.Controls.Add(this.btnDeleteEM);
            this.tabEM.Controls.Add(this.btnCreateEM);
            this.tabEM.Controls.Add(this.dataGVEM);
            this.tabEM.Controls.Add(this.btnRefreshEM);
            this.tabEM.Location = new System.Drawing.Point(4, 25);
            this.tabEM.Name = "tabEM";
            this.tabEM.Padding = new System.Windows.Forms.Padding(3);
            this.tabEM.Size = new System.Drawing.Size(1048, 478);
            this.tabEM.TabIndex = 1;
            this.tabEM.Text = "Electricity Meter";
            this.tabEM.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEM
            // 
            this.btnDeleteEM.Location = new System.Drawing.Point(855, 197);
            this.btnDeleteEM.Name = "btnDeleteEM";
            this.btnDeleteEM.Size = new System.Drawing.Size(185, 35);
            this.btnDeleteEM.TabIndex = 10;
            this.btnDeleteEM.Text = "Delete Electricity Meter";
            this.btnDeleteEM.UseVisualStyleBackColor = true;
            this.btnDeleteEM.Click += new System.EventHandler(this.btnDeleteEM_Click);
            // 
            // btnCreateEM
            // 
            this.btnCreateEM.Location = new System.Drawing.Point(855, 118);
            this.btnCreateEM.Name = "btnCreateEM";
            this.btnCreateEM.Size = new System.Drawing.Size(185, 35);
            this.btnCreateEM.TabIndex = 7;
            this.btnCreateEM.Text = "Create Electricity Meter";
            this.btnCreateEM.UseVisualStyleBackColor = true;
            this.btnCreateEM.Click += new System.EventHandler(this.btnCreateEM_Click);
            // 
            // dataGVEM
            // 
            this.dataGVEM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVEM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGVEM.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGVEM.Location = new System.Drawing.Point(42, 50);
            this.dataGVEM.MultiSelect = false;
            this.dataGVEM.Name = "dataGVEM";
            this.dataGVEM.ReadOnly = true;
            this.dataGVEM.RowTemplate.Height = 24;
            this.dataGVEM.Size = new System.Drawing.Size(807, 378);
            this.dataGVEM.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Serial Number";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Brand";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Model";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // btnRefreshEM
            // 
            this.btnRefreshEM.Location = new System.Drawing.Point(855, 50);
            this.btnRefreshEM.Name = "btnRefreshEM";
            this.btnRefreshEM.Size = new System.Drawing.Size(185, 35);
            this.btnRefreshEM.TabIndex = 4;
            this.btnRefreshEM.Text = "Refresh List";
            this.btnRefreshEM.UseVisualStyleBackColor = true;
            this.btnRefreshEM.Click += new System.EventHandler(this.btnRefreshEM_Click);
            // 
            // tabGW
            // 
            this.tabGW.Controls.Add(this.btnDeleteGW);
            this.tabGW.Controls.Add(this.btnCreateGW);
            this.tabGW.Controls.Add(this.dataGVGW);
            this.tabGW.Controls.Add(this.btRefreshGW);
            this.tabGW.Location = new System.Drawing.Point(4, 25);
            this.tabGW.Name = "tabGW";
            this.tabGW.Size = new System.Drawing.Size(1048, 478);
            this.tabGW.TabIndex = 2;
            this.tabGW.Text = "Gateway";
            this.tabGW.UseVisualStyleBackColor = true;
            // 
            // btnDeleteGW
            // 
            this.btnDeleteGW.Location = new System.Drawing.Point(842, 188);
            this.btnDeleteGW.Name = "btnDeleteGW";
            this.btnDeleteGW.Size = new System.Drawing.Size(140, 35);
            this.btnDeleteGW.TabIndex = 9;
            this.btnDeleteGW.Text = "Delete Gateway";
            this.btnDeleteGW.UseVisualStyleBackColor = true;
            this.btnDeleteGW.Click += new System.EventHandler(this.btnDeleteGW_Click);
            // 
            // btnCreateGW
            // 
            this.btnCreateGW.Location = new System.Drawing.Point(842, 107);
            this.btnCreateGW.Name = "btnCreateGW";
            this.btnCreateGW.Size = new System.Drawing.Size(140, 35);
            this.btnCreateGW.TabIndex = 8;
            this.btnCreateGW.Text = "Create Gateway";
            this.btnCreateGW.UseVisualStyleBackColor = true;
            this.btnCreateGW.Click += new System.EventHandler(this.btnCreateGW_Click);
            // 
            // dataGVGW
            // 
            this.dataGVGW.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGVGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.snumber,
            this.brand,
            this.model,
            this.ip,
            this.port});
            this.dataGVGW.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGVGW.Location = new System.Drawing.Point(18, 30);
            this.dataGVGW.MultiSelect = false;
            this.dataGVGW.Name = "dataGVGW";
            this.dataGVGW.ReadOnly = true;
            this.dataGVGW.RowTemplate.Height = 24;
            this.dataGVGW.Size = new System.Drawing.Size(807, 378);
            this.dataGVGW.TabIndex = 3;
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
            // btRefreshGW
            // 
            this.btRefreshGW.Location = new System.Drawing.Point(842, 30);
            this.btRefreshGW.Name = "btRefreshGW";
            this.btRefreshGW.Size = new System.Drawing.Size(140, 35);
            this.btRefreshGW.TabIndex = 2;
            this.btRefreshGW.Text = "Refresh List";
            this.btRefreshGW.UseVisualStyleBackColor = true;
            this.btRefreshGW.Click += new System.EventHandler(this.btRefresh_Click_1);
            // 
            // getAllGatewaysResponseBindingSource
            // 
            this.getAllGatewaysResponseBindingSource.DataSource = typeof(SFrontForm.SBack.GetAllGatewaysResponse);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 507);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "SchneiderFront";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabWM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVWM)).EndInit();
            this.tabEM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVEM)).EndInit();
            this.tabGW.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGVGW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAllGatewaysResponseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabWM;
        private System.Windows.Forms.TabPage tabEM;
        private System.Windows.Forms.TabPage tabGW;
        private System.Windows.Forms.BindingSource getAllGatewaysResponseBindingSource;
        private System.Windows.Forms.Button btRefreshGW;
        private System.Windows.Forms.DataGridView dataGVGW;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn snumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn port;
        private System.Windows.Forms.DataGridView dataGVWM;
        private System.Windows.Forms.Button btnRefreshWM;
        private System.Windows.Forms.DataGridView dataGVEM;
        private System.Windows.Forms.Button btnRefreshEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnCreateWM;
        private System.Windows.Forms.Button btnCreateEM;
        private System.Windows.Forms.Button btnCreateGW;
        private System.Windows.Forms.Button btnDeleteGW;
        private System.Windows.Forms.Button btnDeleteWM;
        private System.Windows.Forms.Button btnDeleteEM;
    }
}

