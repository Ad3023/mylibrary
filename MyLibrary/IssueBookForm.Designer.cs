namespace MyLibrary
{
	partial class IssueBookForm
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.grpSearchBook = new System.Windows.Forms.GroupBox();
			this.dgvAvailableBooks = new System.Windows.Forms.DataGridView();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.grpDates = new System.Windows.Forms.GroupBox();
			this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btnIssue = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grpSearchBook.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAvailableBooks)).BeginInit();
			this.grpDates.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpSearchBook
			// 
			this.grpSearchBook.Controls.Add(this.dgvAvailableBooks);
			this.grpSearchBook.Controls.Add(this.txtSearch);
			this.grpSearchBook.Location = new System.Drawing.Point(12, 12);
			this.grpSearchBook.Name = "grpSearchBook";
			this.grpSearchBook.Size = new System.Drawing.Size(460, 300);
			this.grpSearchBook.TabIndex = 0;
			this.grpSearchBook.TabStop = false;
			this.grpSearchBook.Text = "Search Book";
			// 
			// dgvAvailableBooks
			// 
			this.dgvAvailableBooks.AllowUserToAddRows = false;
			this.dgvAvailableBooks.AllowUserToDeleteRows = false;
			this.dgvAvailableBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAvailableBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAvailableBooks.Location = new System.Drawing.Point(6, 45);
			this.dgvAvailableBooks.Name = "dgvAvailableBooks";
			this.dgvAvailableBooks.ReadOnly = true;
			this.dgvAvailableBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAvailableBooks.Size = new System.Drawing.Size(448, 249);
			this.dgvAvailableBooks.TabIndex = 1;
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(6, 19);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(448, 20);
			this.txtSearch.TabIndex = 0;
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
			// 
			// grpDates
			// 
			this.grpDates.Controls.Add(this.dtpDueDate);
			this.grpDates.Controls.Add(this.label2);
			this.grpDates.Controls.Add(this.dtpIssueDate);
			this.grpDates.Controls.Add(this.label1);
			this.grpDates.Location = new System.Drawing.Point(12, 318);
			this.grpDates.Name = "grpDates";
			this.grpDates.Size = new System.Drawing.Size(460, 80);
			this.grpDates.TabIndex = 1;
			this.grpDates.TabStop = false;
			this.grpDates.Text = "Dates";
			// 
			// dtpDueDate
			// 
			this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDueDate.Location = new System.Drawing.Point(280, 32);
			this.dtpDueDate.MinDate = new System.DateTime(2025, 5, 26, 20, 33, 33, 689);
			this.dtpDueDate.Name = "dtpDueDate";
			this.dtpDueDate.Size = new System.Drawing.Size(174, 20);
			this.dtpDueDate.TabIndex = 3;
			this.dtpDueDate.Value = new System.DateTime(2025, 5, 26, 20, 33, 33, 689);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(277, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Due Date:";
			// 
			// dtpIssueDate
			// 
			this.dtpIssueDate.Enabled = false;
			this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpIssueDate.Location = new System.Drawing.Point(6, 32);
			this.dtpIssueDate.Name = "dtpIssueDate";
			this.dtpIssueDate.Size = new System.Drawing.Size(174, 20);
			this.dtpIssueDate.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Issue Date:";
			// 
			// btnIssue
			// 
			this.btnIssue.Location = new System.Drawing.Point(316, 404);
			this.btnIssue.Name = "btnIssue";
			this.btnIssue.Size = new System.Drawing.Size(75, 30);
			this.btnIssue.TabIndex = 2;
			this.btnIssue.Text = "Issue";
			this.btnIssue.UseVisualStyleBackColor = true;
			this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(397, 404);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 30);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// IssueBookForm
			// 
			this.AcceptButton = this.btnIssue;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(484, 446);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnIssue);
			this.Controls.Add(this.grpDates);
			this.Controls.Add(this.grpSearchBook);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IssueBookForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Issue Book";
			this.Load += new System.EventHandler(this.IssueBookForm_Load);
			this.grpSearchBook.ResumeLayout(false);
			this.grpSearchBook.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAvailableBooks)).EndInit();
			this.grpDates.ResumeLayout(false);
			this.grpDates.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpSearchBook;
		private System.Windows.Forms.DataGridView dgvAvailableBooks;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.GroupBox grpDates;
		private System.Windows.Forms.DateTimePicker dtpDueDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpIssueDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnIssue;
		private System.Windows.Forms.Button btnCancel;
	}
}