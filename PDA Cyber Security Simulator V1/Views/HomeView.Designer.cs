namespace PDA_Cyber_Security_Simulator_V1.Views
{
    partial class HomeView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulateAttackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeScreen = new System.Windows.Forms.TableLayoutPanel();
            this.configureNetwork = new System.Windows.Forms.Panel();
            this.configureNetworkLabel = new System.Windows.Forms.Label();
            this.simulateAttack = new System.Windows.Forms.Panel();
            this.simulateAttackLabel = new System.Windows.Forms.Label();
            this.viewNetwork = new System.Windows.Forms.Panel();
            this.viewNetworkLabel = new System.Windows.Forms.Label();
            this.testNetwork = new System.Windows.Forms.Panel();
            this.testNetworkLabel = new System.Windows.Forms.Label();
            this.breadCrumbFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.breadCrumbsPanel = new System.Windows.Forms.Panel();
            this.rootCrumb = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.homeScreen.SuspendLayout();
            this.configureNetwork.SuspendLayout();
            this.simulateAttack.SuspendLayout();
            this.viewNetwork.SuspendLayout();
            this.testNetwork.SuspendLayout();
            this.breadCrumbFlowLayoutPanel.SuspendLayout();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.breadCrumbsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(2164, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newNetworkToolStripMenuItem,
            this.selectNetworkToolStripMenuItem,
            this.simulateAttackToolStripMenuItem,
            this.testNetworkToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 36);
            this.toolStripMenuItem1.Text = "File";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // newNetworkToolStripMenuItem
            // 
            this.newNetworkToolStripMenuItem.Name = "newNetworkToolStripMenuItem";
            this.newNetworkToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.newNetworkToolStripMenuItem.Text = "New Network";
            // 
            // selectNetworkToolStripMenuItem
            // 
            this.selectNetworkToolStripMenuItem.Name = "selectNetworkToolStripMenuItem";
            this.selectNetworkToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.selectNetworkToolStripMenuItem.Text = "Select Network";
            // 
            // simulateAttackToolStripMenuItem
            // 
            this.simulateAttackToolStripMenuItem.Name = "simulateAttackToolStripMenuItem";
            this.simulateAttackToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.simulateAttackToolStripMenuItem.Text = "Simulate Attack";
            // 
            // testNetworkToolStripMenuItem
            // 
            this.testNetworkToolStripMenuItem.Name = "testNetworkToolStripMenuItem";
            this.testNetworkToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.testNetworkToolStripMenuItem.Text = "Test Network";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editNetworkToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(67, 36);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editNetworkToolStripMenuItem
            // 
            this.editNetworkToolStripMenuItem.Name = "editNetworkToolStripMenuItem";
            this.editNetworkToolStripMenuItem.Size = new System.Drawing.Size(251, 38);
            this.editNetworkToolStripMenuItem.Text = "Edit Network";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewNetworkToolStripMenuItem,
            this.labsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewNetworkToolStripMenuItem
            // 
            this.viewNetworkToolStripMenuItem.Name = "viewNetworkToolStripMenuItem";
            this.viewNetworkToolStripMenuItem.Size = new System.Drawing.Size(262, 38);
            this.viewNetworkToolStripMenuItem.Text = "View Network";
            // 
            // labsToolStripMenuItem
            // 
            this.labsToolStripMenuItem.Name = "labsToolStripMenuItem";
            this.labsToolStripMenuItem.Size = new System.Drawing.Size(262, 38);
            this.labsToolStripMenuItem.Text = "Labs";
            // 
            // homeScreen
            // 
            this.homeScreen.ColumnCount = 2;
            this.homeScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.homeScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.homeScreen.Controls.Add(this.configureNetwork, 0, 0);
            this.homeScreen.Controls.Add(this.simulateAttack, 1, 1);
            this.homeScreen.Controls.Add(this.viewNetwork, 1, 0);
            this.homeScreen.Controls.Add(this.testNetwork, 0, 1);
            this.homeScreen.Location = new System.Drawing.Point(88, 256);
            this.homeScreen.Margin = new System.Windows.Forms.Padding(6);
            this.homeScreen.Name = "homeScreen";
            this.homeScreen.RowCount = 2;
            this.homeScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.homeScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.homeScreen.Size = new System.Drawing.Size(1584, 662);
            this.homeScreen.TabIndex = 1;
            // 
            // configureNetwork
            // 
            this.configureNetwork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.configureNetwork.Controls.Add(this.configureNetworkLabel);
            this.configureNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configureNetwork.Location = new System.Drawing.Point(6, 6);
            this.configureNetwork.Margin = new System.Windows.Forms.Padding(6);
            this.configureNetwork.Name = "configureNetwork";
            this.configureNetwork.Size = new System.Drawing.Size(780, 319);
            this.configureNetwork.TabIndex = 4;
            // 
            // configureNetworkLabel
            // 
            this.configureNetworkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configureNetworkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configureNetworkLabel.ForeColor = System.Drawing.Color.White;
            this.configureNetworkLabel.Location = new System.Drawing.Point(0, 0);
            this.configureNetworkLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.configureNetworkLabel.Name = "configureNetworkLabel";
            this.configureNetworkLabel.Size = new System.Drawing.Size(780, 319);
            this.configureNetworkLabel.TabIndex = 0;
            this.configureNetworkLabel.Text = "Create Network";
            this.configureNetworkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // simulateAttack
            // 
            this.simulateAttack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(192)))));
            this.simulateAttack.Controls.Add(this.simulateAttackLabel);
            this.simulateAttack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulateAttack.Location = new System.Drawing.Point(798, 337);
            this.simulateAttack.Margin = new System.Windows.Forms.Padding(6);
            this.simulateAttack.Name = "simulateAttack";
            this.simulateAttack.Size = new System.Drawing.Size(780, 319);
            this.simulateAttack.TabIndex = 7;
            // 
            // simulateAttackLabel
            // 
            this.simulateAttackLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulateAttackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulateAttackLabel.ForeColor = System.Drawing.Color.White;
            this.simulateAttackLabel.Location = new System.Drawing.Point(0, 0);
            this.simulateAttackLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.simulateAttackLabel.Name = "simulateAttackLabel";
            this.simulateAttackLabel.Size = new System.Drawing.Size(780, 319);
            this.simulateAttackLabel.TabIndex = 3;
            this.simulateAttackLabel.Text = "Simulate Attack";
            this.simulateAttackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewNetwork
            // 
            this.viewNetwork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(24)))), ((int)(((byte)(48)))));
            this.viewNetwork.Controls.Add(this.viewNetworkLabel);
            this.viewNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewNetwork.Location = new System.Drawing.Point(798, 6);
            this.viewNetwork.Margin = new System.Windows.Forms.Padding(6);
            this.viewNetwork.Name = "viewNetwork";
            this.viewNetwork.Size = new System.Drawing.Size(780, 319);
            this.viewNetwork.TabIndex = 5;
            // 
            // viewNetworkLabel
            // 
            this.viewNetworkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewNetworkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewNetworkLabel.ForeColor = System.Drawing.Color.White;
            this.viewNetworkLabel.Location = new System.Drawing.Point(0, 0);
            this.viewNetworkLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.viewNetworkLabel.Name = "viewNetworkLabel";
            this.viewNetworkLabel.Size = new System.Drawing.Size(780, 319);
            this.viewNetworkLabel.TabIndex = 1;
            this.viewNetworkLabel.Text = "View/Edit Network";
            this.viewNetworkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // testNetwork
            // 
            this.testNetwork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(120)))));
            this.testNetwork.Controls.Add(this.testNetworkLabel);
            this.testNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testNetwork.Location = new System.Drawing.Point(6, 337);
            this.testNetwork.Margin = new System.Windows.Forms.Padding(6);
            this.testNetwork.Name = "testNetwork";
            this.testNetwork.Size = new System.Drawing.Size(780, 319);
            this.testNetwork.TabIndex = 6;
            // 
            // testNetworkLabel
            // 
            this.testNetworkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testNetworkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testNetworkLabel.ForeColor = System.Drawing.Color.White;
            this.testNetworkLabel.Location = new System.Drawing.Point(0, 0);
            this.testNetworkLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.testNetworkLabel.Name = "testNetworkLabel";
            this.testNetworkLabel.Size = new System.Drawing.Size(780, 319);
            this.testNetworkLabel.TabIndex = 2;
            this.testNetworkLabel.Text = "Test Network";
            this.testNetworkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // breadCrumbFlowLayoutPanel
            // 
            this.breadCrumbFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.breadCrumbFlowLayoutPanel.Controls.Add(this.imagePanel);
            this.breadCrumbFlowLayoutPanel.Controls.Add(this.breadCrumbsPanel);
            this.breadCrumbFlowLayoutPanel.Location = new System.Drawing.Point(0, 52);
            this.breadCrumbFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.breadCrumbFlowLayoutPanel.Name = "breadCrumbFlowLayoutPanel";
            this.breadCrumbFlowLayoutPanel.Size = new System.Drawing.Size(1764, 192);
            this.breadCrumbFlowLayoutPanel.TabIndex = 2;
            // 
            // imagePanel
            // 
            this.imagePanel.BackColor = System.Drawing.SystemColors.Control;
            this.imagePanel.Controls.Add(this.pictureBox1);
            this.imagePanel.Location = new System.Drawing.Point(6, 6);
            this.imagePanel.Margin = new System.Windows.Forms.Padding(6);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(524, 167);
            this.imagePanel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(524, 167);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // breadCrumbsPanel
            // 
            this.breadCrumbsPanel.Controls.Add(this.rootCrumb);
            this.breadCrumbsPanel.Location = new System.Drawing.Point(542, 6);
            this.breadCrumbsPanel.Margin = new System.Windows.Forms.Padding(6);
            this.breadCrumbsPanel.Name = "breadCrumbsPanel";
            this.breadCrumbsPanel.Size = new System.Drawing.Size(400, 167);
            this.breadCrumbsPanel.TabIndex = 4;
            // 
            // rootCrumb
            // 
            this.rootCrumb.AutoSize = true;
            this.rootCrumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rootCrumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootCrumb.Location = new System.Drawing.Point(24, 52);
            this.rootCrumb.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.rootCrumb.Name = "rootCrumb";
            this.rootCrumb.Size = new System.Drawing.Size(173, 65);
            this.rootCrumb.TabIndex = 0;
            this.rootCrumb.Text = "Home";
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2164, 1062);
            this.Controls.Add(this.breadCrumbFlowLayoutPanel);
            this.Controls.Add(this.homeScreen);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "HomeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDA Cyber Security Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.homeScreen.ResumeLayout(false);
            this.configureNetwork.ResumeLayout(false);
            this.simulateAttack.ResumeLayout(false);
            this.viewNetwork.ResumeLayout(false);
            this.testNetwork.ResumeLayout(false);
            this.breadCrumbFlowLayoutPanel.ResumeLayout(false);
            this.imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.breadCrumbsPanel.ResumeLayout(false);
            this.breadCrumbsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labsToolStripMenuItem;

        private System.Windows.Forms.TableLayoutPanel homeScreen;
        private System.Windows.Forms.Panel configureNetwork;
        private System.Windows.Forms.Label configureNetworkLabel;
        private System.Windows.Forms.Panel simulateAttack;
        private System.Windows.Forms.Label simulateAttackLabel;
        private System.Windows.Forms.Panel viewNetwork;
        private System.Windows.Forms.Label viewNetworkLabel;
        private System.Windows.Forms.Panel testNetwork;
        private System.Windows.Forms.Label testNetworkLabel;
        private System.Windows.Forms.ToolStripMenuItem simulateAttackToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem testNetworkToolStripMenuItem;

        private System.Windows.Forms.Panel breadCrumbsPanel;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.FlowLayoutPanel breadCrumbFlowLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label rootCrumb;

    }
}

