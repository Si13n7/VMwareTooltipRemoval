namespace Patcher
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BackLayout = new System.Windows.Forms.Panel();
            this.RestoreBtn = new System.Windows.Forms.Button();
            this.PatchBtn = new System.Windows.Forms.Button();
            this.SlideText = new System.Windows.Forms.Label();
            this.SildeBorder = new System.Windows.Forms.Label();
            this.SlideBack = new System.Windows.Forms.Label();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.DemoBox = new System.Windows.Forms.PictureBox();
            this.MinBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.DemoScreen = new System.Windows.Forms.Timer(this.components);
            this.SlideDemo = new System.Windows.Forms.Timer(this.components);
            this.SlideDemoGlow = new System.Windows.Forms.Timer(this.components);
            this.BackLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BackLayout
            // 
            this.BackLayout.BackColor = System.Drawing.Color.White;
            this.BackLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackLayout.Controls.Add(this.RestoreBtn);
            this.BackLayout.Controls.Add(this.PatchBtn);
            this.BackLayout.Controls.Add(this.SlideText);
            this.BackLayout.Controls.Add(this.SildeBorder);
            this.BackLayout.Controls.Add(this.SlideBack);
            this.BackLayout.Controls.Add(this.HeaderLabel);
            this.BackLayout.Controls.Add(this.DemoBox);
            this.BackLayout.Controls.Add(this.MinBtn);
            this.BackLayout.Controls.Add(this.CloseBtn);
            this.BackLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackLayout.Location = new System.Drawing.Point(0, 0);
            this.BackLayout.Name = "BackLayout";
            this.BackLayout.Size = new System.Drawing.Size(343, 270);
            this.BackLayout.TabIndex = 0;
            // 
            // RestoreBtn
            // 
            this.RestoreBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.RestoreBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.RestoreBtn.FlatAppearance.BorderSize = 0;
            this.RestoreBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.RestoreBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RestoreBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.RestoreBtn.Location = new System.Drawing.Point(219, 220);
            this.RestoreBtn.Name = "RestoreBtn";
            this.RestoreBtn.Size = new System.Drawing.Size(115, 23);
            this.RestoreBtn.TabIndex = 8;
            this.RestoreBtn.Text = "RESTORE";
            this.RestoreBtn.UseVisualStyleBackColor = false;
            this.RestoreBtn.Click += new System.EventHandler(this.RestoreBtn_Click);
            // 
            // PatchBtn
            // 
            this.PatchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.PatchBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.PatchBtn.FlatAppearance.BorderSize = 0;
            this.PatchBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.PatchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PatchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PatchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatchBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.PatchBtn.Location = new System.Drawing.Point(7, 220);
            this.PatchBtn.Name = "PatchBtn";
            this.PatchBtn.Size = new System.Drawing.Size(115, 23);
            this.PatchBtn.TabIndex = 7;
            this.PatchBtn.Text = "PATCH";
            this.PatchBtn.UseVisualStyleBackColor = false;
            this.PatchBtn.Click += new System.EventHandler(this.PatchBtn_Click);
            // 
            // SlideText
            // 
            this.SlideText.AutoSize = true;
            this.SlideText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.SlideText.Font = new System.Drawing.Font("Segoe Print", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlideText.ForeColor = System.Drawing.Color.DarkGray;
            this.SlideText.Location = new System.Drawing.Point(21, 249);
            this.SlideText.Name = "SlideText";
            this.SlideText.Size = new System.Drawing.Size(532, 16);
            this.SlideText.TabIndex = 6;
            this.SlideText.Text = "VMware Workstation Player - Tooltip Removal ¸.•´¯`* developed by $î13ñ7™ ¸.•´¯`* " +
    "chiptune composed by Radix";
            // 
            // SildeBorder
            // 
            this.SildeBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SildeBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SildeBorder.Location = new System.Drawing.Point(0, 247);
            this.SildeBorder.Name = "SildeBorder";
            this.SildeBorder.Size = new System.Drawing.Size(341, 1);
            this.SildeBorder.TabIndex = 5;
            this.SildeBorder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlideBack
            // 
            this.SlideBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.SlideBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SlideBack.Location = new System.Drawing.Point(0, 248);
            this.SlideBack.Name = "SlideBack";
            this.SlideBack.Size = new System.Drawing.Size(341, 20);
            this.SlideBack.TabIndex = 4;
            this.SlideBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.HeaderLabel.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.Location = new System.Drawing.Point(3, 3);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(282, 23);
            this.HeaderLabel.TabIndex = 3;
            this.HeaderLabel.Text = "VMware Workstation Player - Tooltip Removal";
            this.HeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DemoBox
            // 
            this.DemoBox.BackColor = System.Drawing.Color.Transparent;
            this.DemoBox.Location = new System.Drawing.Point(0, 29);
            this.DemoBox.Name = "DemoBox";
            this.DemoBox.Size = new System.Drawing.Size(341, 192);
            this.DemoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DemoBox.TabIndex = 2;
            this.DemoBox.TabStop = false;
            // 
            // MinBtn
            // 
            this.MinBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.MinBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Goldenrod;
            this.MinBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.MinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MinBtn.Location = new System.Drawing.Point(291, 3);
            this.MinBtn.Name = "MinBtn";
            this.MinBtn.Size = new System.Drawing.Size(22, 23);
            this.MinBtn.TabIndex = 1;
            this.MinBtn.Text = "±";
            this.MinBtn.UseVisualStyleBackColor = false;
            this.MinBtn.Click += new System.EventHandler(this.MinBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.CloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.CloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CloseBtn.Location = new System.Drawing.Point(316, 3);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(22, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "X";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // DemoScreen
            // 
            this.DemoScreen.Enabled = true;
            this.DemoScreen.Interval = 25;
            this.DemoScreen.Tick += new System.EventHandler(this.DemoScreen_Tick);
            // 
            // SlideDemo
            // 
            this.SlideDemo.Enabled = true;
            this.SlideDemo.Interval = 35;
            this.SlideDemo.Tick += new System.EventHandler(this.SlideDemo_Tick);
            // 
            // SlideDemoGlow
            // 
            this.SlideDemoGlow.Enabled = true;
            this.SlideDemoGlow.Tick += new System.EventHandler(this.SlideDemoGlow_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 270);
            this.Controls.Add(this.BackLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VMware Workstation Player - Tooltip Removal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.BackLayout.ResumeLayout(false);
            this.BackLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackLayout;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button MinBtn;
        private System.Windows.Forms.Timer DemoScreen;
        private System.Windows.Forms.PictureBox DemoBox;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label SildeBorder;
        private System.Windows.Forms.Label SlideBack;
        private System.Windows.Forms.Label SlideText;
        private System.Windows.Forms.Timer SlideDemo;
        private System.Windows.Forms.Timer SlideDemoGlow;
        private System.Windows.Forms.Button RestoreBtn;
        private System.Windows.Forms.Button PatchBtn;
    }
}

