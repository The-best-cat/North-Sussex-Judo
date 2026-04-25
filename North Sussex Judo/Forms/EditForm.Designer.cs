namespace NorthSussexJudo
{
    partial class EditForm
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
            this.components = new System.ComponentModel.Container();
            this.NameError = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CoachingHourList = new System.Windows.Forms.ComboBox();
            this.HourError = new System.Windows.Forms.ErrorProvider(this.components);
            this.CompetitionError = new System.Windows.Forms.ErrorProvider(this.components);
            this.WeightError = new System.Windows.Forms.ErrorProvider(this.components);
            this.Cancel = new System.Windows.Forms.Button();
            this.Confirm = new System.Windows.Forms.Button();
            this.PrivateCoachingLabel = new System.Windows.Forms.Label();
            this.CompetitionBox = new System.Windows.Forms.TextBox();
            this.CompetitionLabel = new System.Windows.Forms.Label();
            this.WeightCatList = new System.Windows.Forms.ComboBox();
            this.WeightCatLabel = new System.Windows.Forms.Label();
            this.WeightBox = new System.Windows.Forms.TextBox();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.TrainingPlanList = new System.Windows.Forms.ComboBox();
            this.PlanLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CatError = new System.Windows.Forms.ErrorProvider(this.components);
            this.NameBox = new System.Windows.Forms.TextBox();
            this.PlanError = new System.Windows.Forms.ErrorProvider(this.components);
            this.InvalidNameError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NameError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HourError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompetitionError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvalidNameError)).BeginInit();
            this.SuspendLayout();
            // 
            // NameError
            // 
            this.NameError.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "hours";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "kg";
            // 
            // CoachingHourList
            // 
            this.CoachingHourList.AllowDrop = true;
            this.CoachingHourList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CoachingHourList.FormattingEnabled = true;
            this.CoachingHourList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CoachingHourList.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.CoachingHourList.Location = new System.Drawing.Point(210, 243);
            this.CoachingHourList.Name = "CoachingHourList";
            this.CoachingHourList.Size = new System.Drawing.Size(151, 24);
            this.CoachingHourList.TabIndex = 32;
            // 
            // HourError
            // 
            this.HourError.ContainerControl = this;
            // 
            // CompetitionError
            // 
            this.CompetitionError.ContainerControl = this;
            // 
            // WeightError
            // 
            this.WeightError.ContainerControl = this;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Cancel.AutoSize = true;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Cancel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Cancel.Location = new System.Drawing.Point(255, 306);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 31);
            this.Cancel.TabIndex = 31;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Confirm
            // 
            this.Confirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Confirm.Location = new System.Drawing.Point(163, 306);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 31);
            this.Confirm.TabIndex = 30;
            this.Confirm.Text = "Save";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // PrivateCoachingLabel
            // 
            this.PrivateCoachingLabel.AutoSize = true;
            this.PrivateCoachingLabel.Location = new System.Drawing.Point(42, 246);
            this.PrivateCoachingLabel.Name = "PrivateCoachingLabel";
            this.PrivateCoachingLabel.Size = new System.Drawing.Size(162, 16);
            this.PrivateCoachingLabel.TabIndex = 29;
            this.PrivateCoachingLabel.Text = "Private Coaching (weekly)";
            // 
            // CompetitionBox
            // 
            this.CompetitionBox.Location = new System.Drawing.Point(210, 207);
            this.CompetitionBox.Name = "CompetitionBox";
            this.CompetitionBox.Size = new System.Drawing.Size(151, 22);
            this.CompetitionBox.TabIndex = 28;
            this.CompetitionBox.Text = "0";
            this.CompetitionBox.WordWrap = false;
            this.CompetitionBox.TextChanged += new System.EventHandler(this.CompetitionBox_TextChanged);
            this.CompetitionBox.Validating += new System.ComponentModel.CancelEventHandler(this.CompetitionBox_Validating);
            // 
            // CompetitionLabel
            // 
            this.CompetitionLabel.AutoSize = true;
            this.CompetitionLabel.Location = new System.Drawing.Point(78, 210);
            this.CompetitionLabel.Name = "CompetitionLabel";
            this.CompetitionLabel.Size = new System.Drawing.Size(126, 16);
            this.CompetitionLabel.TabIndex = 27;
            this.CompetitionLabel.Text = "No. of Comptetitions";
            // 
            // WeightCatList
            // 
            this.WeightCatList.AllowDrop = true;
            this.WeightCatList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeightCatList.FormattingEnabled = true;
            this.WeightCatList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.WeightCatList.Location = new System.Drawing.Point(210, 171);
            this.WeightCatList.Name = "WeightCatList";
            this.WeightCatList.Size = new System.Drawing.Size(151, 24);
            this.WeightCatList.TabIndex = 26;
            this.WeightCatList.SelectedIndexChanged += new System.EventHandler(this.WeightCatList_SelectedIndexChanged);
            // 
            // WeightCatLabel
            // 
            this.WeightCatLabel.AutoSize = true;
            this.WeightCatLabel.Location = new System.Drawing.Point(97, 174);
            this.WeightCatLabel.Name = "WeightCatLabel";
            this.WeightCatLabel.Size = new System.Drawing.Size(107, 16);
            this.WeightCatLabel.TabIndex = 25;
            this.WeightCatLabel.Text = "Weight Category";
            // 
            // WeightBox
            // 
            this.WeightBox.Location = new System.Drawing.Point(210, 135);
            this.WeightBox.Name = "WeightBox";
            this.WeightBox.Size = new System.Drawing.Size(151, 22);
            this.WeightBox.TabIndex = 24;
            this.WeightBox.Text = "0";
            this.WeightBox.WordWrap = false;
            this.WeightBox.TextChanged += new System.EventHandler(this.WeightBox_TextChanged);
            this.WeightBox.Validating += new System.ComponentModel.CancelEventHandler(this.WeightBox_Validating);
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(155, 138);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(49, 16);
            this.WeightLabel.TabIndex = 23;
            this.WeightLabel.Text = "Weight";
            // 
            // TrainingPlanList
            // 
            this.TrainingPlanList.AllowDrop = true;
            this.TrainingPlanList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrainingPlanList.FormattingEnabled = true;
            this.TrainingPlanList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TrainingPlanList.Location = new System.Drawing.Point(210, 99);
            this.TrainingPlanList.Name = "TrainingPlanList";
            this.TrainingPlanList.Size = new System.Drawing.Size(151, 24);
            this.TrainingPlanList.TabIndex = 22;
            this.TrainingPlanList.SelectedIndexChanged += new System.EventHandler(this.TrainingPlanList_SelectedIndexChanged);
            // 
            // PlanLabel
            // 
            this.PlanLabel.AutoSize = true;
            this.PlanLabel.Location = new System.Drawing.Point(118, 102);
            this.PlanLabel.Name = "PlanLabel";
            this.PlanLabel.Size = new System.Drawing.Size(86, 16);
            this.PlanLabel.TabIndex = 21;
            this.PlanLabel.Text = "Training Plan";
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.CausesValidation = false;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(169, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(147, 29);
            this.TitleLabel.TabIndex = 20;
            this.TitleLabel.Text = "Edit Athlete";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.CausesValidation = false;
            this.NameLabel.Location = new System.Drawing.Point(160, 66);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(44, 16);
            this.NameLabel.TabIndex = 19;
            this.NameLabel.Text = "Name";
            // 
            // CatError
            // 
            this.CatError.ContainerControl = this;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(210, 63);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(151, 22);
            this.NameBox.TabIndex = 18;
            this.NameBox.WordWrap = false;
            this.NameBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameBox_Validating);
            // 
            // PlanError
            // 
            this.PlanError.ContainerControl = this;
            // 
            // InvalidNameError
            // 
            this.InvalidNameError.ContainerControl = this;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 353);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CoachingHourList);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.PrivateCoachingLabel);
            this.Controls.Add(this.CompetitionBox);
            this.Controls.Add(this.CompetitionLabel);
            this.Controls.Add(this.WeightCatList);
            this.Controls.Add(this.WeightCatLabel);
            this.Controls.Add(this.WeightBox);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.TrainingPlanList);
            this.Controls.Add(this.PlanLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameBox);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NameError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HourError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompetitionError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvalidNameError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CoachingHourList;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Label PrivateCoachingLabel;
        private System.Windows.Forms.TextBox CompetitionBox;
        private System.Windows.Forms.Label CompetitionLabel;
        private System.Windows.Forms.ComboBox WeightCatList;
        private System.Windows.Forms.Label WeightCatLabel;
        private System.Windows.Forms.TextBox WeightBox;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.ComboBox TrainingPlanList;
        private System.Windows.Forms.Label PlanLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.ErrorProvider NameError;
        private System.Windows.Forms.ErrorProvider HourError;
        private System.Windows.Forms.ErrorProvider CompetitionError;
        private System.Windows.Forms.ErrorProvider WeightError;
        private System.Windows.Forms.ErrorProvider CatError;
        private System.Windows.Forms.ErrorProvider PlanError;
        private System.Windows.Forms.ErrorProvider InvalidNameError;
    }
}