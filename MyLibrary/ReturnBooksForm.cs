using MyLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace MyLibrary
{
	public partial class ReturnBooksForm : Form
	{
        private const string ConnectionString =@"Server=(localdb)\MSSQLLocalDB;Database=LibraryManagement;Integrated Security=True;";


        public ReturnBooksForm()
		{
			InitializeComponent();
			ConfigureGrid();
		}

		private void ConfigureGrid()
		{
			dgvBorrowers.AutoGenerateColumns = false;

			dgvBorrowers.Columns.Add(new DataGridViewTextBoxColumn
			{
				DataPropertyName = "BorrowerID",
				HeaderText = "ID",
				ReadOnly = true
			});

			dgvBorrowers.Columns.Add(new DataGridViewTextBoxColumn
			{
				DataPropertyName = "Name",
				HeaderText = "Name"
			});

			dgvBorrowers.Columns.Add(new DataGridViewTextBoxColumn
			{
				DataPropertyName = "Email",
				HeaderText = "Email"
			});

			dgvBorrowers.Columns.Add(new DataGridViewTextBoxColumn
			{
				DataPropertyName = "Phone",
				HeaderText = "Phone"
			});
		}

		private void LoadBorrowers()
		{
			try
			{
				using (var connection = new SqlConnection(ConnectionString))
				{
					connection.Open();
					var adapter = new SqlDataAdapter(
						"SELECT BorrowerID, Name, Email, Phone FROM Borrowers",
						connection);
					var table = new DataTable();
					adapter.Fill(table);
					dgvBorrowers.DataSource = table;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading borrowers: {ex.Message}");
			}
		}

		private void BorrowersManagementForm_Load(object sender, EventArgs e)
		{
			LoadBorrowers();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (dgvBorrowers.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a borrower to remove");
				return;
			}

			var borrowerId = Convert.ToInt32(dgvBorrowers.SelectedRows[0].Cells["BorrowerID"].Value);

			if (MessageBox.Show("Are you sure you want to remove this borrower?", "Confirm Removal",
				MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				try
				{
					using (var connection = new SqlConnection(ConnectionString))
					{
						connection.Open();
						var command = new SqlCommand(
							"DELETE FROM Borrowers WHERE BorrowerID = @ID",
							connection);
						command.Parameters.AddWithValue("@ID", borrowerId);
						command.ExecuteNonQuery();
					}
					LoadBorrowers();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error removing borrower: {ex.Message}");
				}
			}
		}

		private void btnReturn_Click(object sender, EventArgs e)
		{
			if (dgvBorrowers.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a borrower");
				return;
			}

			var borrowerId = Convert.ToInt32(dgvBorrowers.SelectedRows[0].Cells["BorrowerID"].Value);
			ShowReturnBooksForm(borrowerId);
		}

		private void ShowReturnBooksForm(int borrowerId)
		{
			// Now matches the new constructor
			////using (var returnForm = new ReturnBooksForm(borrowerId))
			//{
			//	returnForm.ShowDialog();
			//}
		
	}

        private void dgvBorrowers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}