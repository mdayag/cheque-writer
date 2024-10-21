namespace view.forms
{
    partial class frmChequeWriterView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtgView = new System.Windows.Forms.DataGridView();
            this.colBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChequeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBankId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrstn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateIssued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmountInWords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.gbMain.Controls.Add(this.label3);
            this.gbMain.Controls.Add(this.txtSearch);
            this.gbMain.Controls.Add(this.label2);
            this.gbMain.Controls.Add(this.label1);
            this.gbMain.Controls.Add(this.dtpTo);
            this.gbMain.Controls.Add(this.dtgView);
            this.gbMain.Controls.Add(this.dtpFrom);
            this.gbMain.Location = new System.Drawing.Point(11, 6);
            this.gbMain.Margin = new System.Windows.Forms.Padding(2);
            this.gbMain.Name = "gbMain";
            this.gbMain.Padding = new System.Windows.Forms.Padding(2);
            this.gbMain.Size = new System.Drawing.Size(1073, 561);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(14, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "&Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Location = new System.Drawing.Point(62, 57);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(219, 20);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(166, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&To:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&From:";
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(192, 20);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(89, 20);
            this.dtpTo.TabIndex = 4;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtgView
            // 
            this.dtgView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtgView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dtgView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBank,
            this.colChequeNumber,
            this.colBankId,
            this.colBrstn,
            this.colDateIssued,
            this.colPayee,
            this.colAmount,
            this.colAmountInWords});
            this.dtgView.Location = new System.Drawing.Point(8, 90);
            this.dtgView.Margin = new System.Windows.Forms.Padding(2);
            this.dtgView.Name = "dtgView";
            this.dtgView.RowTemplate.Height = 24;
            this.dtgView.Size = new System.Drawing.Size(1057, 460);
            this.dtgView.TabIndex = 7;
            // 
            // colBank
            // 
            this.colBank.DataPropertyName = "Bank";
            this.colBank.Frozen = true;
            this.colBank.HeaderText = "Bank";
            this.colBank.Name = "colBank";
            this.colBank.ReadOnly = true;
            // 
            // colChequeNumber
            // 
            this.colChequeNumber.DataPropertyName = "ChequeNumber";
            this.colChequeNumber.Frozen = true;
            this.colChequeNumber.HeaderText = "Cheque Number";
            this.colChequeNumber.Name = "colChequeNumber";
            this.colChequeNumber.ReadOnly = true;
            this.colChequeNumber.Width = 110;
            // 
            // colBankId
            // 
            this.colBankId.DataPropertyName = "BankId";
            this.colBankId.HeaderText = "BankId";
            this.colBankId.Name = "colBankId";
            this.colBankId.Visible = false;
            // 
            // colBrstn
            // 
            this.colBrstn.DataPropertyName = "Brstn";
            this.colBrstn.HeaderText = "BRSTN";
            this.colBrstn.Name = "colBrstn";
            this.colBrstn.ReadOnly = true;
            // 
            // colDateIssued
            // 
            this.colDateIssued.DataPropertyName = "DateIssued";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colDateIssued.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDateIssued.HeaderText = "Date Issued";
            this.colDateIssued.Name = "colDateIssued";
            this.colDateIssued.ReadOnly = true;
            this.colDateIssued.Width = 75;
            // 
            // colPayee
            // 
            this.colPayee.DataPropertyName = "Payee";
            this.colPayee.HeaderText = "Pay in order of";
            this.colPayee.Name = "colPayee";
            this.colPayee.ReadOnly = true;
            this.colPayee.Width = 200;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 90;
            // 
            // colAmountInWords
            // 
            this.colAmountInWords.DataPropertyName = "AmountInWords";
            this.colAmountInWords.HeaderText = "Amount in words";
            this.colAmountInWords.Name = "colAmountInWords";
            this.colAmountInWords.ReadOnly = true;
            this.colAmountInWords.Width = 600;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(61, 20);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 2;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // frmChequeWriterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1103, 586);
            this.Controls.Add(this.gbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmChequeWriterView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheque Writer View";
            this.Load += new System.EventHandler(this.frmChequeAutomationView_Load);
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridView dtgView;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChequeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBankId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrstn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateIssued;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmountInWords;
    }
}