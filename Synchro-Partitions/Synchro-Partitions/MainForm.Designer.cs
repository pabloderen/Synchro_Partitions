namespace Synchro_Partitions
{
    partial class MainForm
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
            this.zoneCheckList = new System.Windows.Forms.CheckedListBox();
            this.cancleButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.elementCheckBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // zoneCheckList
            // 
            this.zoneCheckList.CheckOnClick = true;
            this.zoneCheckList.FormattingEnabled = true;
            this.zoneCheckList.Location = new System.Drawing.Point(27, 39);
            this.zoneCheckList.Name = "zoneCheckList";
            this.zoneCheckList.Size = new System.Drawing.Size(189, 214);
            this.zoneCheckList.TabIndex = 0;
            this.zoneCheckList.SelectedIndexChanged += new System.EventHandler(this.zoneCheckList_SelectedIndexChanged);
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(433, 320);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(125, 30);
            this.cancleButton.TabIndex = 1;
            this.cancleButton.Text = "Cancel";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(27, 320);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(125, 30);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // elementCheckBox
            // 
            this.elementCheckBox.CheckOnClick = true;
            this.elementCheckBox.FormattingEnabled = true;
            this.elementCheckBox.Location = new System.Drawing.Point(353, 39);
            this.elementCheckBox.Name = "elementCheckBox";
            this.elementCheckBox.Size = new System.Drawing.Size(189, 214);
            this.elementCheckBox.TabIndex = 2;
            this.elementCheckBox.SelectedIndexChanged += new System.EventHandler(this.elementCheckBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 362);
            this.Controls.Add(this.elementCheckBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.zoneCheckList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox zoneCheckList;
        private System.Windows.Forms.Button cancleButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckedListBox elementCheckBox;
    }
}