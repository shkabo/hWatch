namespace hWatch
{
    partial class Form1
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
            this.addressGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.numericSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnWatch = new System.Windows.Forms.Button();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lokacija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.addressGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // addressGridView
            // 
            this.addressGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.addressGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.addressGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addressGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPAddress,
            this.Lokacija,
            this.Status});
            this.addressGridView.Location = new System.Drawing.Point(-3, 0);
            this.addressGridView.Name = "addressGridView";
            this.addressGridView.Size = new System.Drawing.Size(909, 463);
            this.addressGridView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelSeconds);
            this.panel1.Controls.Add(this.numericSeconds);
            this.panel1.Controls.Add(this.btnWatch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 449);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 83);
            this.panel1.TabIndex = 1;
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Location = new System.Drawing.Point(532, 32);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(47, 13);
            this.labelSeconds.TabIndex = 3;
            this.labelSeconds.Text = "seconds";
            // 
            // numericSeconds
            // 
            this.numericSeconds.Location = new System.Drawing.Point(475, 29);
            this.numericSeconds.Name = "numericSeconds";
            this.numericSeconds.Size = new System.Drawing.Size(51, 20);
            this.numericSeconds.TabIndex = 2;
            this.numericSeconds.Tag = "";
            this.numericSeconds.ValueChanged += new System.EventHandler(this.numericSeconds_ValueChanged);
            // 
            // btnWatch
            // 
            this.btnWatch.Location = new System.Drawing.Point(326, 20);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(117, 35);
            this.btnWatch.TabIndex = 0;
            this.btnWatch.Text = "Watch";
            this.btnWatch.UseVisualStyleBackColor = true;
            this.btnWatch.Click += new System.EventHandler(this.btnWatch_Click);
            // 
            // IPAddress
            // 
            this.IPAddress.HeaderText = "IP Address/Domain";
            this.IPAddress.Name = "IPAddress";
            // 
            // Lokacija
            // 
            this.Lokacija.HeaderText = "Location";
            this.Lokacija.Name = "Lokacija";
            // 
            // Status
            // 
            this.Status.HeaderText = "Ping Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 532);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addressGridView);
            this.Name = "Form1";
            this.Text = "hWatch";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addressGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView addressGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.NumericUpDown numericSeconds;
        private System.Windows.Forms.Button btnWatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lokacija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

