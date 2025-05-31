using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyLibrary
{
	public partial class IssueBookForm : Form
	{
        private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MyLibrary;Integrated Security=True;";

        public IssueBookForm()
		{
			InitializeComponent();
			dtpIssueDate.Value = DateTime.Today;
			dtpDueDate.MinDate = DateTime.Today;
		}

		// Load books into DataGridView
		private void LoadAvailableBooks(string searchTerm = "")
		{
			try
			{
				using (var conn = new SqlConnection(ConnectionString))
				{
					conn.Open();
					string query = @"SELECT BookID, Title, Author, AvailableCopies 
                                   FROM Books 
                                   WHERE AvailableCopies > 0 
                                   AND (Title LIKE @Search OR Author LIKE @Search)";

					SqlCommand cmd = new SqlCommand(query, conn);
					cmd.Parameters.AddWithValue("@Search", $"%{searchTerm}%");

					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					adapter.Fill(dt);

					dgvAvailableBooks.DataSource = dt; // Bind to DataGridView
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Event handler for search box
		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			LoadAvailableBooks(txtSearch.Text); // Reload books on text change
		}

		// Initialize data on form load
		private void IssueBookForm_Load(object sender, EventArgs e)
		{
			LoadAvailableBooks(); // Load all books initially
		}

		// Issue button click handler
		private void btnIssue_Click(object sender, EventArgs e)
		{
			// Your issue book logic here
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}