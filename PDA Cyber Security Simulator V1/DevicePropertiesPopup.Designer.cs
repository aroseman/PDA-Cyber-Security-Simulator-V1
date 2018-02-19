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
            this.devPropFlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.lblDeviceIP = new System.Windows.Forms.Label();
            this.txtDeviceIP = new System.Windows.Forms.TextBox();
            this.lblDeviceMac = new System.Windows.Forms.Label();
            this.txtDeviceMac = new System.Windows.Forms.TextBox();
            this.lblDeviceDescription = new System.Windows.Forms.Label();
            this.txtDeviceDescription = new System.Windows.Forms.TextBox();
            this.lblDeviceNotes = new System.Windows.Forms.Label();
            this.txtDeviceNotes = new System.Windows.Forms.TextBox();
            this.devPropFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveDeviceProperties
            // 
            this.btnSaveDeviceProperties.Location = new System.Drawing.Point(38, 565);
            this.btnSaveDeviceProperties.Margin = new System.Windows.Forms.Padding(38, 20, 0, 4);
            this.btnSaveDeviceProperties.Name = "btnSaveDeviceProperties";
            this.btnSaveDeviceProperties.Size = new System.Drawing.Size(120, 46);
            this.btnSaveDeviceProperties.TabIndex = 0;
            this.btnSaveDeviceProperties.Text = "Save";
            this.btnSaveDeviceProperties.UseVisualStyleBackColor = true;
            this.btnSaveDeviceProperties.Click += new System.EventHandler(this.btnSaveDeviceProperties_Click);
            // 
            // btnCancelPopup
            // 
            this.btnCancelPopup.Location = new System.Drawing.Point(346, 565);
            this.btnCancelPopup.Margin = new System.Windows.Forms.Padding(188, 20, 4, 4);
            this.btnCancelPopup.Name = "btnCancelPopup";
            this.btnCancelPopup.Size = new System.Drawing.Size(96, 46);
            this.btnCancelPopup.TabIndex = 1;
            this.btnCancelPopup.Text = "Cancel";
            this.btnCancelPopup.UseVisualStyleBackColor = true;
            // 
            // devPropFlowLayoutPanel1
            // 
            this.devPropFlowLayoutPanel1.Controls.Add(this.lblDeviceName);
            this.devPropFlowLayoutPanel1.Controls.Add(this.txtDeviceName);
            this.devPropFlowLayoutPanel1.Controls.Add(this.lblDeviceIP);
            this.devPropFlowLayoutPanel1.Controls.Add(this.txtDeviceIP);
            this.devPropFlowLayoutPanel1.Controls.Add(this.lblDeviceMac);
            this.devPropFlowLayoutPanel1.Controls.Add(this.txtDeviceMac);
            this.devPropFlowLayoutPanel1.Controls.Add(this.lblDeviceDescription);
            this.devPropFlowLayoutPanel1.Controls.Add(this.txtDeviceDescription);
            this.devPropFlowLayoutPanel1.Controls.Add(this.lblDeviceNotes);
            this.devPropFlowLayoutPanel1.Controls.Add(this.txtDeviceNotes);
            this.devPropFlowLayoutPanel1.Controls.Add(this.btnSaveDeviceProperties);
            this.devPropFlowLayoutPanel1.Controls.Add(this.btnCancelPopup);
            this.devPropFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devPropFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.devPropFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.devPropFlowLayoutPanel1.Name = "devPropFlowLayoutPanel1";
            this.devPropFlowLayoutPanel1.Size = new System.Drawing.Size(464, 733);
            this.devPropFlowLayoutPanel1.TabIndex = 2;
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceName.Location = new System.Drawing.Point(6, 6);
            this.lblDeviceName.Margin = new System.Windows.Forms.Padding(6, 6, 0, 0);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(112, 37);
            this.lblDeviceName.TabIndex = 7;
            this.lblDeviceName.Text = "Name:";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceName.Location = new System.Drawing.Point(40, 49);
            this.txtDeviceName.Margin = new System.Windows.Forms.Padding(40, 6, 500, 6);
            this.txtDeviceName.MaxLength = 50;
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(293, 44);
            this.txtDeviceName.TabIndex = 2;
            // 
            // lblDeviceIP
            // 
            this.lblDeviceIP.AutoSize = true;
            this.lblDeviceIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceIP.Location = new System.Drawing.Point(6, 105);
            this.lblDeviceIP.Margin = new System.Windows.Forms.Padding(6, 6, 0, 0);
            this.lblDeviceIP.Name = "lblDeviceIP";
            this.lblDeviceIP.Size = new System.Drawing.Size(55, 37);
            this.lblDeviceIP.TabIndex = 8;
            this.lblDeviceIP.Text = "IP:";
            // 
            // txtDeviceIP
            // 
            this.txtDeviceIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceIP.Location = new System.Drawing.Point(40, 148);
            this.txtDeviceIP.Margin = new System.Windows.Forms.Padding(40, 6, 600, 6);
            this.txtDeviceIP.MaxLength = 15;
            this.txtDeviceIP.Name = "txtDeviceIP";
            this.txtDeviceIP.Size = new System.Drawing.Size(293, 44);
            this.txtDeviceIP.TabIndex = 3;
            // 
            // lblDeviceMac
            // 
            this.lblDeviceMac.AutoSize = true;
            this.lblDeviceMac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceMac.Location = new System.Drawing.Point(6, 204);
            this.lblDeviceMac.Margin = new System.Windows.Forms.Padding(6, 6, 0, 0);
            this.lblDeviceMac.Name = "lblDeviceMac";
            this.lblDeviceMac.Size = new System.Drawing.Size(97, 37);
            this.lblDeviceMac.TabIndex = 9;
            this.lblDeviceMac.Text = "MAC:";
            // 
            // txtDeviceMac
            // 
            this.txtDeviceMac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceMac.Location = new System.Drawing.Point(40, 247);
            this.txtDeviceMac.Margin = new System.Windows.Forms.Padding(40, 6, 600, 6);
            this.txtDeviceMac.MaxLength = 17;
            this.txtDeviceMac.Name = "txtDeviceMac";
            this.txtDeviceMac.Size = new System.Drawing.Size(293, 44);
            this.txtDeviceMac.TabIndex = 4;
            // 
            // lblDeviceDescription
            // 
            this.lblDeviceDescription.AutoSize = true;
            this.lblDeviceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceDescription.Location = new System.Drawing.Point(6, 303);
            this.lblDeviceDescription.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.lblDeviceDescription.Name = "lblDeviceDescription";
            this.lblDeviceDescription.Size = new System.Drawing.Size(186, 37);
            this.lblDeviceDescription.TabIndex = 10;
            this.lblDeviceDescription.Text = "Description:";
            // 
            // txtDeviceDescription
            // 
            this.txtDeviceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceDescription.Location = new System.Drawing.Point(40, 346);
            this.txtDeviceDescription.Margin = new System.Windows.Forms.Padding(40, 6, 600, 6);
            this.txtDeviceDescription.MaxLength = 100;
            this.txtDeviceDescription.Name = "txtDeviceDescription";
            this.txtDeviceDescription.Size = new System.Drawing.Size(396, 44);
            this.txtDeviceDescription.TabIndex = 5;
            // 
            // lblDeviceNotes
            // 
            this.lblDeviceNotes.AutoSize = true;
            this.lblDeviceNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceNotes.Location = new System.Drawing.Point(6, 396);
            this.lblDeviceNotes.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDeviceNotes.Name = "lblDeviceNotes";
            this.lblDeviceNotes.Size = new System.Drawing.Size(110, 37);
            this.lblDeviceNotes.TabIndex = 11;
            this.lblDeviceNotes.Text = "Notes:";
            // 
            // txtDeviceNotes
            // 
            this.txtDeviceNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceNotes.Location = new System.Drawing.Point(40, 439);
            this.txtDeviceNotes.Margin = new System.Windows.Forms.Padding(40, 6, 600, 6);
            this.txtDeviceNotes.MaximumSize = new System.Drawing.Size(396, 100);
            this.txtDeviceNotes.MaxLength = 200;
            this.txtDeviceNotes.MinimumSize = new System.Drawing.Size(396, 100);
            this.txtDeviceNotes.Multiline = true;
            this.txtDeviceNotes.Name = "txtDeviceNotes";
            this.txtDeviceNotes.Size = new System.Drawing.Size(396, 100);
            this.txtDeviceNotes.TabIndex = 6;
            // 
            // DeviceProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 733);
            this.Controls.Add(this.devPropFlowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DeviceProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Properties";
            this.devPropFlowLayoutPanel1.ResumeLayout(false);
            this.devPropFlowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveDeviceProperties;
        private System.Windows.Forms.Button btnCancelPopup;
        private System.Windows.Forms.FlowLayoutPanel devPropFlowLayoutPanel1;
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