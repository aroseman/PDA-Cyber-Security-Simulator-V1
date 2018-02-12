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
            this.SuspendLayout();
            // 
            // btnSaveDeviceProperties
            // 
            this.btnSaveDeviceProperties.Location = new System.Drawing.Point(131, 404);
            this.btnSaveDeviceProperties.Name = "btnSaveDeviceProperties";
            this.btnSaveDeviceProperties.Size = new System.Drawing.Size(121, 47);
            this.btnSaveDeviceProperties.TabIndex = 0;
            this.btnSaveDeviceProperties.Text = "Save";
            this.btnSaveDeviceProperties.UseVisualStyleBackColor = true;
            // 
            // btnCancelPopup
            // 
            this.btnCancelPopup.Location = new System.Drawing.Point(480, 404);
            this.btnCancelPopup.Name = "btnCancelPopup";
            this.btnCancelPopup.Size = new System.Drawing.Size(96, 47);
            this.btnCancelPopup.TabIndex = 1;
            this.btnCancelPopup.Text = "Cancel";
            this.btnCancelPopup.UseVisualStyleBackColor = true;
            // 
            // DeviceProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 529);
            this.Controls.Add(this.btnCancelPopup);
            this.Controls.Add(this.btnSaveDeviceProperties);
            this.Name = "DeviceProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Properties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveDeviceProperties;
        private System.Windows.Forms.Button btnCancelPopup;
    }
}