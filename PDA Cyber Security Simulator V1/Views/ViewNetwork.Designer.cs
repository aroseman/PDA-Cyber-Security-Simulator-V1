namespace PDA_Cyber_Security_Simulator_V1.Views
{
    partial class ViewNetwork
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
            this.btnLoadNetwork = new System.Windows.Forms.Button();
            this.txtNetworkName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoadNetwork
            // 
            this.btnLoadNetwork.Location = new System.Drawing.Point(698, 327);
            this.btnLoadNetwork.Name = "btnLoadNetwork";
            this.btnLoadNetwork.Size = new System.Drawing.Size(158, 53);
            this.btnLoadNetwork.TabIndex = 0;
            this.btnLoadNetwork.Text = "Load Network";
            this.btnLoadNetwork.UseVisualStyleBackColor = true;
            // 
            // txtNetworkName
            // 
            this.txtNetworkName.Location = new System.Drawing.Point(698, 207);
            this.txtNetworkName.Name = "txtNetworkName";
            this.txtNetworkName.Size = new System.Drawing.Size(158, 31);
            this.txtNetworkName.TabIndex = 1;
            // 
            // ViewNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2164, 1574);
            this.Controls.Add(this.txtNetworkName);
            this.Controls.Add(this.btnLoadNetwork);
            this.MaximumSize = new System.Drawing.Size(2190, 1645);
            this.Name = "ViewNetwork";
            this.Text = "7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadNetwork;
        private System.Windows.Forms.TextBox txtNetworkName;
    }
}