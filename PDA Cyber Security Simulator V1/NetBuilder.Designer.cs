﻿namespace PDA_Cyber_Security_Simulator_V1
{
    partial class NetBuilder
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
            this.canvas = new System.Windows.Forms.Panel();
            this.lblDrawEnabled = new System.Windows.Forms.Label();
            this.enableLineDraw = new System.Windows.Forms.Button();
            this.picTrashCan = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearNetwork = new System.Windows.Forms.Button();
            this.btnSaveNetwork = new System.Windows.Forms.Button();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.breadCrumbsPanel = new System.Windows.Forms.Panel();
            this.rootCrumb = new System.Windows.Forms.Label();
            this.canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrashCan)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.breadCrumbsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.AllowDrop = true;
            this.canvas.BackColor = System.Drawing.Color.LightGray;
            this.canvas.Controls.Add(this.lblDrawEnabled);
            this.canvas.Controls.Add(this.enableLineDraw);
            this.canvas.Controls.Add(this.picTrashCan);
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(443, 198);
            this.canvas.Margin = new System.Windows.Forms.Padding(6);
            this.canvas.Name = "canvas";
            this.tableLayoutPanel1.SetRowSpan(this.canvas, 2);
            this.canvas.Size = new System.Drawing.Size(1725, 1420);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            // 
            // lblDrawEnabled
            // 
            this.lblDrawEnabled.AutoSize = true;
            this.lblDrawEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawEnabled.Location = new System.Drawing.Point(162, 1330);
            this.lblDrawEnabled.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDrawEnabled.Name = "lblDrawEnabled";
            this.lblDrawEnabled.Size = new System.Drawing.Size(276, 37);
            this.lblDrawEnabled.TabIndex = 1;
            this.lblDrawEnabled.Text = "Drawing Enabled";
            // 
            // enableLineDraw
            // 
            this.enableLineDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableLineDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableLineDraw.Location = new System.Drawing.Point(1599, 33);
            this.enableLineDraw.Margin = new System.Windows.Forms.Padding(4);
            this.enableLineDraw.Name = "enableLineDraw";
            this.enableLineDraw.Size = new System.Drawing.Size(62, 50);
            this.enableLineDraw.TabIndex = 0;
            this.enableLineDraw.Text = "/";
            this.enableLineDraw.UseVisualStyleBackColor = true;
            this.enableLineDraw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.enableLineDraw_MouseClick);
            // 
            // picTrashCan
            // 
            this.picTrashCan.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.trash_can;
            this.picTrashCan.ImageLocation = "";
            this.picTrashCan.Location = new System.Drawing.Point(16, 1202);
            this.picTrashCan.Margin = new System.Windows.Forms.Padding(4);
            this.picTrashCan.MaximumSize = new System.Drawing.Size(138, 165);
            this.picTrashCan.Name = "picTrashCan";
            this.picTrashCan.Size = new System.Drawing.Size(138, 165);
            this.picTrashCan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTrashCan.TabIndex = 2;
            this.picTrashCan.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox3);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox4);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox5);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox6);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox7);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox8);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox9);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox10);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox11);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox12);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox13);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox14);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 198);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(425, 1295);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 162);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox2.Location = new System.Drawing.Point(218, 6);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 162);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox3.Location = new System.Drawing.Point(6, 180);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(200, 162);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox4.Location = new System.Drawing.Point(218, 180);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(200, 162);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox5.Location = new System.Drawing.Point(6, 354);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(200, 162);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox6.Location = new System.Drawing.Point(218, 354);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(200, 162);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox7.Location = new System.Drawing.Point(6, 528);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(200, 162);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox8.Location = new System.Drawing.Point(218, 528);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(200, 162);
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.White;
            this.pictureBox9.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox9.Location = new System.Drawing.Point(6, 702);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(200, 162);
            this.pictureBox9.TabIndex = 8;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.White;
            this.pictureBox10.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox10.Location = new System.Drawing.Point(218, 702);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(200, 162);
            this.pictureBox10.TabIndex = 9;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.White;
            this.pictureBox11.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox11.Location = new System.Drawing.Point(6, 876);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(200, 162);
            this.pictureBox11.TabIndex = 10;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.White;
            this.pictureBox12.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox12.Location = new System.Drawing.Point(218, 876);
            this.pictureBox12.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(200, 162);
            this.pictureBox12.TabIndex = 11;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.White;
            this.pictureBox13.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox13.Location = new System.Drawing.Point(6, 1050);
            this.pictureBox13.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(200, 162);
            this.pictureBox13.TabIndex = 12;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.White;
            this.pictureBox14.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox14.Location = new System.Drawing.Point(218, 1050);
            this.pictureBox14.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(200, 162);
            this.pictureBox14.TabIndex = 13;
            this.pictureBox14.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.14719F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.85281F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.canvas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2174, 1624);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(144)))), ((int)(((byte)(24)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.breadCrumbsPanel);
            this.panel2.Controls.Add(this.pictureBox15);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2162, 180);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearNetwork);
            this.panel1.Controls.Add(this.btnSaveNetwork);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 1503);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 118);
            this.panel1.TabIndex = 4;
            // 
            // btnClearNetwork
            // 
            this.btnClearNetwork.Location = new System.Drawing.Point(221, 16);
            this.btnClearNetwork.Margin = new System.Windows.Forms.Padding(100, 10, 0, 0);
            this.btnClearNetwork.Name = "btnClearNetwork";
            this.btnClearNetwork.Size = new System.Drawing.Size(105, 46);
            this.btnClearNetwork.TabIndex = 16;
            this.btnClearNetwork.Text = "Clear";
            this.btnClearNetwork.UseVisualStyleBackColor = true;
            // 
            // btnSaveNetwork
            // 
            this.btnSaveNetwork.Location = new System.Drawing.Point(64, 16);
            this.btnSaveNetwork.Margin = new System.Windows.Forms.Padding(100, 10, 0, 0);
            this.btnSaveNetwork.Name = "btnSaveNetwork";
            this.btnSaveNetwork.Size = new System.Drawing.Size(105, 46);
            this.btnSaveNetwork.TabIndex = 15;
            this.btnSaveNetwork.Text = "Save";
            this.btnSaveNetwork.UseVisualStyleBackColor = true;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox15.Image = global::PDA_Cyber_Security_Simulator_V1.Properties.Resources.pda;
            this.pictureBox15.Location = new System.Drawing.Point(0, 0);
            this.pictureBox15.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(2162, 180);
            this.pictureBox15.TabIndex = 1;
            this.pictureBox15.TabStop = false;
            // 
            // breadCrumbsPanel
            // 
            this.breadCrumbsPanel.Controls.Add(this.rootCrumb);
            this.breadCrumbsPanel.Location = new System.Drawing.Point(542, 6);
            this.breadCrumbsPanel.Margin = new System.Windows.Forms.Padding(6);
            this.breadCrumbsPanel.Name = "breadCrumbsPanel";
            this.breadCrumbsPanel.Size = new System.Drawing.Size(400, 167);
            this.breadCrumbsPanel.TabIndex = 5;
            // 
            // rootCrumb
            // 
            this.rootCrumb.AutoSize = true;
            this.rootCrumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(121)))), ((int)(((byte)(14)))));
            this.rootCrumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rootCrumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootCrumb.Location = new System.Drawing.Point(24, 52);
            this.rootCrumb.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.rootCrumb.Name = "rootCrumb";
            this.rootCrumb.Size = new System.Drawing.Size(173, 65);
            this.rootCrumb.TabIndex = 0;
            this.rootCrumb.Text = "Home";
            this.rootCrumb.Click += new System.EventHandler(this.rootCrumb_Click);
            // 
            // NetBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2174, 1624);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "NetBuilder";
            this.Text = "NetBuilder";
            this.canvas.ResumeLayout(false);
            this.canvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrashCan)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.breadCrumbsPanel.ResumeLayout(false);
            this.breadCrumbsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button enableLineDraw;
        private System.Windows.Forms.Label lblDrawEnabled;
        private System.Windows.Forms.PictureBox picTrashCan;
        private System.Windows.Forms.Button btnSaveNetwork;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearNetwork;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Panel breadCrumbsPanel;
        private System.Windows.Forms.Label rootCrumb;
    }
}