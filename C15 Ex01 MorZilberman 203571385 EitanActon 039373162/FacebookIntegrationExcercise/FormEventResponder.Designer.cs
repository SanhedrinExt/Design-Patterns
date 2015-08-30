namespace FacebookIntegrationExcercise
{
    partial class FormEventResponder
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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRSVPOptions = new System.Windows.Forms.ComboBox();
            this.buttonRespond = new System.Windows.Forms.Button();
            this.checkedListBoxEvents = new System.Windows.Forms.CheckedListBox();
            this.buttonCheckAll = new System.Windows.Forms.Button();
            this.buttonUncheckAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Events you have not responded to";
            // 
            // comboBoxRSVPOptions
            // 
            this.comboBoxRSVPOptions.FormattingEnabled = true;
            this.comboBoxRSVPOptions.Location = new System.Drawing.Point(15, 219);
            this.comboBoxRSVPOptions.Name = "comboBoxRSVPOptions";
            this.comboBoxRSVPOptions.Size = new System.Drawing.Size(155, 21);
            this.comboBoxRSVPOptions.TabIndex = 50;
            // 
            // buttonRespond
            // 
            this.buttonRespond.Location = new System.Drawing.Point(198, 211);
            this.buttonRespond.Name = "buttonRespond";
            this.buttonRespond.Size = new System.Drawing.Size(74, 34);
            this.buttonRespond.TabIndex = 51;
            this.buttonRespond.Text = "Respond";
            this.buttonRespond.UseVisualStyleBackColor = true;
            this.buttonRespond.Click += new System.EventHandler(this.buttonRespond_Click);
            // 
            // checkedListBoxEvents
            // 
            this.checkedListBoxEvents.CheckOnClick = true;
            this.checkedListBoxEvents.FormattingEnabled = true;
            this.checkedListBoxEvents.Location = new System.Drawing.Point(15, 39);
            this.checkedListBoxEvents.Name = "checkedListBoxEvents";
            this.checkedListBoxEvents.Size = new System.Drawing.Size(546, 154);
            this.checkedListBoxEvents.TabIndex = 52;
            // 
            // buttonCheckAll
            // 
            this.buttonCheckAll.Location = new System.Drawing.Point(400, 13);
            this.buttonCheckAll.Name = "buttonCheckAll";
            this.buttonCheckAll.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckAll.TabIndex = 53;
            this.buttonCheckAll.Text = "Check all";
            this.buttonCheckAll.UseVisualStyleBackColor = true;
            this.buttonCheckAll.Click += new System.EventHandler(this.buttonCheckAll_Click);
            // 
            // buttonUncheckAll
            // 
            this.buttonUncheckAll.Location = new System.Drawing.Point(481, 13);
            this.buttonUncheckAll.Name = "buttonUncheckAll";
            this.buttonUncheckAll.Size = new System.Drawing.Size(75, 23);
            this.buttonUncheckAll.TabIndex = 54;
            this.buttonUncheckAll.Text = "Uncheck all";
            this.buttonUncheckAll.UseVisualStyleBackColor = true;
            this.buttonUncheckAll.Click += new System.EventHandler(this.buttonUncheckAll_Click);
            // 
            // EventResponder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 255);
            this.Controls.Add(this.buttonUncheckAll);
            this.Controls.Add(this.buttonCheckAll);
            this.Controls.Add(this.checkedListBoxEvents);
            this.Controls.Add(this.buttonRespond);
            this.Controls.Add(this.comboBoxRSVPOptions);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventResponder";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Event Responder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxRSVPOptions;
        private System.Windows.Forms.Button buttonRespond;
        private System.Windows.Forms.CheckedListBox checkedListBoxEvents;
        private System.Windows.Forms.Button buttonCheckAll;
        private System.Windows.Forms.Button buttonUncheckAll;
    }
}