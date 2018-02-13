namespace PDA_Cyber_Security_Simulator_V1
{
    partial class DeviceProperties
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
            this.btnSaveDeviceProperties = new System.Windows.Forms.Button();
            this.btnCancelPopup = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.lblDeviceIP = new System.Windows.Forms.Label();
            this.txtDeviceIP = new System.Windows.Forms.TextBox();
            this.txtDeviceMac = new System.Windows.Forms.TextBox();
            this.txtDeviceDescription = new System.Windows.Forms.TextBox();
            this.txtDeviceNotes = new System.Windows.Forms.TextBox();
            this.lblDeviceMac = new System.Windows.Forms.Label();
            this.lblDeviceDescription = new System.Windows.Forms.Label();
            this.lblDeviceNotes = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveDeviceProperties
            // 
            this.btnSaveDeviceProperties.Location = new System.Drawing.Point(19, 348);
            this.btnSaveDeviceProperties.Margin = new System.Windows.Forms.Padding(19, 2, 0, 2);
            this.btnSaveDeviceProperties.Name = "btnSaveDeviceProperties";
            this.btnSaveDeviceProperties.Size = new System.Drawing.Size(60, 24);
            this.btnSaveDeviceProperties.TabIndex = 0;
            this.btnSaveDeviceProperties.Text = "Save";
            this.btnSaveDeviceProperties.UseVisualStyleBackColor = true;
            this.btnSaveDeviceProperties.Click += new System.EventHandler(this.btnSaveDeviceProperties_Click);
            // 
            // btnCancelPopup
            // 
            this.btnCancelPopup.Location = new System.Drawing.Point(173, 348);
            this.btnCancelPopup.Margin = new System.Windows.Forms.Padding(94, 2, 2, 2);
            this.btnCancelPopup.Name = "btnCancelPopup";
            this.btnCancelPopup.Size = new System.Drawing.Size(48, 24);
            this.btnCancelPopup.TabIndex = 1;
            this.btnCancelPopup.Text = "Cancel";
            this.btnCancelPopup.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblDeviceName);
            this.flowLayoutPanel1.Controls.Add(this.txtDeviceName);
            this.flowLayoutPanel1.Controls.Add(this.lblDeviceIP);
            this.flowLayoutPanel1.Controls.Add(this.txtDeviceIP);
            this.flowLayoutPanel1.Controls.Add(this.lblDeviceMac);
            this.flowLayoutPanel1.Controls.Add(this.txtDeviceMac);
            this.flowLayoutPanel1.Controls.Add(this.lblDeviceDescription);
            this.flowLayoutPanel1.Controls.Add(this.txtDeviceDescription);
            this.flowLayoutPanel1.Controls.Add(this.lblDeviceNotes);
            this.flowLayoutPanel1.Controls.Add(this.txtDeviceNotes);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveDeviceProperties);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelPopup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 381);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceName.Location = new System.Drawing.Point(3, 3);
            this.lblDeviceName.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(55, 20);
            this.lblDeviceName.TabIndex = 7;
            this.lblDeviceName.Text = "Name:";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceName.Location = new System.Drawing.Point(20, 26);
            this.txtDeviceName.Margin = new System.Windows.Forms.Padding(20, 3, 250, 3);
            this.txtDeviceName.MaxLength = 50;
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(100, 26);
            this.txtDeviceName.TabIndex = 2;
            // 
            // lblDeviceIP
            // 
            this.lblDeviceIP.AutoSize = true;
            this.lblDeviceIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceIP.Location = new System.Drawing.Point(3, 58);
            this.lblDeviceIP.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblDeviceIP.Name = "lblDeviceIP";
            this.lblDeviceIP.Size = new System.Drawing.Size(28, 20);
            this.lblDeviceIP.TabIndex = 8;
            this.lblDeviceIP.Text = "IP:";
            // 
            // txtDeviceIP
            // 
            this.txtDeviceIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceIP.Location = new System.Drawing.Point(20, 81);
            this.txtDeviceIP.Margin = new System.Windows.Forms.Padding(20, 3, 300, 3);
            this.txtDeviceIP.MaxLength = 11;
            this.txtDeviceIP.Name = "txtDeviceIP";
            this.txtDeviceIP.Size = new System.Drawing.Size(100, 26);
            this.txtDeviceIP.TabIndex = 3;
            // 
            // txtDeviceMac
            // 
            this.txtDeviceMac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceMac.Location = new System.Drawing.Point(20, 136);
            this.txtDeviceMac.Margin = new System.Windows.Forms.Padding(20, 3, 300, 3);
            this.txtDeviceMac.MaxLength = 17;
            this.txtDeviceMac.Name = "txtDeviceMac";
            this.txtDeviceMac.Size = new System.Drawing.Size(100, 26);
            this.txtDeviceMac.TabIndex = 4;
            // 
            // txtDeviceDescription
            // 
            this.txtDeviceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceDescription.Location = new System.Drawing.Point(20, 191);
            this.txtDeviceDescription.Margin = new System.Windows.Forms.Padding(20, 3, 300, 3);
            this.txtDeviceDescription.MaxLength = 100;
            this.txtDeviceDescription.Name = "txtDeviceDescription";
            this.txtDeviceDescription.Size = new System.Drawing.Size(200, 26);
            this.txtDeviceDescription.TabIndex = 5;
            // 
            // txtDeviceNotes
            // 
            this.txtDeviceNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceNotes.Location = new System.Drawing.Point(20, 243);
            this.txtDeviceNotes.Margin = new System.Windows.Forms.Padding(20, 3, 300, 3);
            this.txtDeviceNotes.MaximumSize = new System.Drawing.Size(200, 100);
            this.txtDeviceNotes.MaxLength = 200;
            this.txtDeviceNotes.MinimumSize = new System.Drawing.Size(200, 100);
            this.txtDeviceNotes.Name = "txtDeviceNotes";
            this.txtDeviceNotes.Size = new System.Drawing.Size(200, 100);
            this.txtDeviceNotes.TabIndex = 6;
            // 
            // lblDeviceMac
            // 
            this.lblDeviceMac.AutoSize = true;
            this.lblDeviceMac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceMac.Location = new System.Drawing.Point(3, 113);
            this.lblDeviceMac.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblDeviceMac.Name = "lblDeviceMac";
            this.lblDeviceMac.Size = new System.Drawing.Size(48, 20);
            this.lblDeviceMac.TabIndex = 9;
            this.lblDeviceMac.Text = "MAC:";
            // 
            // lblDeviceDescription
            // 
            this.lblDeviceDescription.AutoSize = true;
            this.lblDeviceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceDescription.Location = new System.Drawing.Point(3, 168);
            this.lblDeviceDescription.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblDeviceDescription.Name = "lblDeviceDescription";
            this.lblDeviceDescription.Size = new System.Drawing.Size(93, 20);
            this.lblDeviceDescription.TabIndex = 10;
            this.lblDeviceDescription.Text = "Description:";
            // 
            // lblDeviceNotes
            // 
            this.lblDeviceNotes.AutoSize = true;
            this.lblDeviceNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceNotes.Location = new System.Drawing.Point(3, 220);
            this.lblDeviceNotes.Name = "lblDeviceNotes";
            this.lblDeviceNotes.Size = new System.Drawing.Size(55, 20);
            this.lblDeviceNotes.TabIndex = 11;
            this.lblDeviceNotes.Text = "Notes:";
            this.lblDeviceNotes.Click += new System.EventHandler(this.label3_Click);
            // 
            // DeviceProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 381);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DeviceProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Properties";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveDeviceProperties;
        private System.Windows.Forms.Button btnCancelPopup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.TextBox txtDeviceIP;
        private System.Windows.Forms.TextBox txtDeviceMac;
        private System.Windows.Forms.TextBox txtDeviceDescription;
        private System.Windows.Forms.TextBox txtDeviceNotes;
        private System.Windows.Forms.Label lblDeviceIP;
        private System.Windows.Forms.Label lblDeviceMac;
        private System.Windows.Forms.Label lblDeviceDescription;
        private System.Windows.Forms.Label lblDeviceNotes;
    }
}