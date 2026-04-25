namespace NorthSussexJudo
{
    partial class MainMenu
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Remove = new System.Windows.Forms.Button();
            this.RemoveTipLabel = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.Button();
            this.EditTipLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Register
            // 
            this.Register.AutoSize = true;
            this.Register.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register.Location = new System.Drawing.Point(12, 12);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(76, 26);
            this.Register.TabIndex = 0;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(807, 1);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            // 
            // FlowPanel
            // 
            this.FlowPanel.Location = new System.Drawing.Point(28, 64);
            this.FlowPanel.Name = "FlowPanel";
            this.FlowPanel.Size = new System.Drawing.Size(747, 370);
            this.FlowPanel.TabIndex = 3;
            // 
            // Remove
            // 
            this.Remove.AutoSize = true;
            this.Remove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remove.Location = new System.Drawing.Point(712, 12);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(76, 26);
            this.Remove.TabIndex = 4;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // RemoveTipLabel
            // 
            this.RemoveTipLabel.AutoSize = true;
            this.RemoveTipLabel.CausesValidation = false;
            this.RemoveTipLabel.Location = new System.Drawing.Point(286, 17);
            this.RemoveTipLabel.Name = "RemoveTipLabel";
            this.RemoveTipLabel.Size = new System.Drawing.Size(396, 16);
            this.RemoveTipLabel.TabIndex = 5;
            this.RemoveTipLabel.Text = "Click on any athlete to remove it. Click again to exit Remove Mode";
            this.RemoveTipLabel.Visible = false;
            // 
            // Edit
            // 
            this.Edit.AutoSize = true;
            this.Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit.Location = new System.Drawing.Point(94, 12);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(76, 26);
            this.Edit.TabIndex = 6;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // EditTipLabel
            // 
            this.EditTipLabel.AutoSize = true;
            this.EditTipLabel.CausesValidation = false;
            this.EditTipLabel.Location = new System.Drawing.Point(176, 17);
            this.EditTipLabel.Name = "EditTipLabel";
            this.EditTipLabel.Size = new System.Drawing.Size(343, 16);
            this.EditTipLabel.TabIndex = 7;
            this.EditTipLabel.Text = "Click on any athlete to edit it. Click again to exit Edit Mode";
            this.EditTipLabel.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EditTipLabel);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.RemoveTipLabel);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.FlowPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Register);
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel FlowPanel;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Label RemoveTipLabel;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Label EditTipLabel;
    }
}

