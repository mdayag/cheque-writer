namespace view.forms
{
    partial class frmChequeWriterEntry
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
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDateIssued = new System.Windows.Forms.DateTimePicker();
            this.txtBrstn = new System.Windows.Forms.TextBox();
            this.txtChequeNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumberInWords = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.gbMain.Controls.Add(this.cboBank);
            this.gbMain.Controls.Add(this.label8);
            this.gbMain.Controls.Add(this.label7);
            this.gbMain.Controls.Add(this.chkPrint);
            this.gbMain.Controls.Add(this.txtPayee);
            this.gbMain.Controls.Add(this.label6);
            this.gbMain.Controls.Add(this.dtpDateIssued);
            this.gbMain.Controls.Add(this.txtBrstn);
            this.gbMain.Controls.Add(this.txtChequeNumber);
            this.gbMain.Controls.Add(this.label5);
            this.gbMain.Controls.Add(this.label4);
            this.gbMain.Controls.Add(this.label3);
            this.gbMain.Controls.Add(this.label34);
            this.gbMain.Controls.Add(this.label2);
            this.gbMain.Controls.Add(this.btnFinish);
            this.gbMain.Controls.Add(this.label1);
            this.gbMain.Controls.Add(this.txtNumberInWords);
            this.gbMain.Controls.Add(this.txtNumber);
            this.gbMain.Location = new System.Drawing.Point(9, 3);
            this.gbMain.Margin = new System.Windows.Forms.Padding(2);
            this.gbMain.Name = "gbMain";
            this.gbMain.Padding = new System.Windows.Forms.Padding(2);
            this.gbMain.Size = new System.Drawing.Size(382, 330);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            // 
            // cboBank
            // 
            this.cboBank.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Location = new System.Drawing.Point(133, 20);
            this.cboBank.Margin = new System.Windows.Forms.Padding(2);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(116, 21);
            this.cboBank.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(87, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ban&k :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(122, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "*";
            // 
            // chkPrint
            // 
            this.chkPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkPrint.AutoSize = true;
            this.chkPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrint.ForeColor = System.Drawing.Color.Red;
            this.chkPrint.Location = new System.Drawing.Point(38, 298);
            this.chkPrint.Margin = new System.Windows.Forms.Padding(2);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(52, 17);
            this.chkPrint.TabIndex = 16;
            this.chkPrint.Text = "&Print";
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // txtPayee
            // 
            this.txtPayee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPayee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPayee.Location = new System.Drawing.Point(133, 140);
            this.txtPayee.Margin = new System.Windows.Forms.Padding(2);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(218, 20);
            this.txtPayee.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(25, 142);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "P&ay to the order of :";
            // 
            // dtpDateIssued
            // 
            this.dtpDateIssued.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateIssued.Location = new System.Drawing.Point(133, 110);
            this.dtpDateIssued.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateIssued.Name = "dtpDateIssued";
            this.dtpDateIssued.Size = new System.Drawing.Size(116, 20);
            this.dtpDateIssued.TabIndex = 8;
            // 
            // txtBrstn
            // 
            this.txtBrstn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBrstn.Location = new System.Drawing.Point(133, 80);
            this.txtBrstn.Margin = new System.Windows.Forms.Padding(2);
            this.txtBrstn.Name = "txtBrstn";
            this.txtBrstn.Size = new System.Drawing.Size(116, 20);
            this.txtBrstn.TabIndex = 6;
            // 
            // txtChequeNumber
            // 
            this.txtChequeNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtChequeNumber.Location = new System.Drawing.Point(133, 51);
            this.txtChequeNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtChequeNumber.Name = "txtChequeNumber";
            this.txtChequeNumber.Size = new System.Drawing.Size(116, 20);
            this.txtChequeNumber.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(55, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "&Date Issued :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(75, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "&BRSTN :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(41, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Check Number :";
            // 
            // label34
            // 
            this.label34.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.Red;
            this.label34.Location = new System.Drawing.Point(122, 166);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(11, 13);
            this.label34.TabIndex = 26;
            this.label34.Text = "*";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(34, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Amou&nt in words :";
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(259, 292);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(2);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(92, 27);
            this.btnFinish.TabIndex = 17;
            this.btnFinish.Text = "&Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(48, 171);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "&Enter Amount :";
            // 
            // txtNumberInWords
            // 
            this.txtNumberInWords.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumberInWords.ForeColor = System.Drawing.Color.Red;
            this.txtNumberInWords.Location = new System.Drawing.Point(38, 213);
            this.txtNumberInWords.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumberInWords.Multiline = true;
            this.txtNumberInWords.Name = "txtNumberInWords";
            this.txtNumberInWords.ReadOnly = true;
            this.txtNumberInWords.Size = new System.Drawing.Size(313, 68);
            this.txtNumberInWords.TabIndex = 15;
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumber.Location = new System.Drawing.Point(133, 169);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(116, 20);
            this.txtNumber.TabIndex = 12;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            this.txtNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumber_KeyDown);
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            this.txtNumber.Leave += new System.EventHandler(this.txtNumber_Leave);
            // 
            // frmChequeWriterEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(400, 365);
            this.Controls.Add(this.gbMain);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmChequeWriterEntry";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque Writer Entry";
            this.Load += new System.EventHandler(this.frmChequeAutomationEntry_Load);
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumberInWords;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.DateTimePicker dtpDateIssued;
        private System.Windows.Forms.TextBox txtBrstn;
        private System.Windows.Forms.TextBox txtChequeNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Label label8;
    }
}