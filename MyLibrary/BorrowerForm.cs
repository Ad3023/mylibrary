using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyLibrary
{
	public partial class BorrowerForm : Form
	{
        private const string ConnectionString = @"Server=(local db)\MSSQLLocalDB;Database=MyLibrary;Integrated Security=True;";
        public int BorrowerId { get; set; } = -1;

		public BorrowerForm()
		{
			InitializeComponent();
		}

		private void BorrowerForm_Load(object sender, EventArgs e)
		{
			if (BorrowerId > 0) LoadBorrowerDetails();
		}

		private void LoadBorrowerDetails()
		{
			try
			{
				using (var connection = new SqlConnection(ConnectionString))
				{
					connection.Open();
					var command = new SqlCommand(
						"SELECT Name, Email, Phone FROM Borrowers WHERE BorrowerID = @ID",
						connection);
					command.Parameters.AddWithValue("@ID", BorrowerId);

					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							txtName.Text = reader["Name"].ToString();
							txtEmail.Text = reader["Email"].ToString();
							txtPhone.Text = reader["Phone"].ToString();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading borrower: {ex.Message}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!ValidateInputs()) return;

			try
			{
				using (var connection = new SqlConnection(ConnectionString))
				{
					connection.Open();
					SqlCommand command;

					if (BorrowerId > 0)
					{
                        command = new SqlCommand(
    "UPDATE Borrowers SET Name = @Name, Email = @Email, " +
    "PhoneNumber = @Phone WHERE BorrowerID = @ID", // ✅ Fixed
    connection);
                    }
					else
					{
                        command = new SqlCommand(
    "INSERT INTO Borrowers (Name, Email, PhoneNumber) " + // ✅ Fixed
    "VALUES (@Name, @Email, @Phone)",
    connection);
                    }

					command.Parameters.AddWithValue("@Name", txtName.Text);
					command.Parameters.AddWithValue("@Email", txtEmail.Text);
					command.Parameters.AddWithValue("@Phone", txtPhone.Text);

					command.ExecuteNonQuery();

					MessageBox.Show("Borrower saved successfully!", "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error saving borrower: {ex.Message}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (BorrowerId < 0) return;

			if (MessageBox.Show("Are you sure you want to delete this borrower?", "Confirm Delete",
				MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					using (var connection = new SqlConnection(ConnectionString))
					{
						connection.Open();
						var command = new SqlCommand(
							"DELETE FROM Borrowers WHERE BorrowerID = @ID",
							connection);
						command.Parameters.AddWithValue("@ID", BorrowerId);
						command.ExecuteNonQuery();
					}

					MessageBox.Show("Borrower deleted successfully!", "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error deleting borrower: {ex.Message}", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private bool ValidateInputs()
		{
			if (string.IsNullOrWhiteSpace(txtName.Text))
			{
				MessageBox.Show("Please enter a name", "Validation Error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!IsValidEmail(txtEmail.Text))
			{
				MessageBox.Show("Please enter a valid email address", "Validation Error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
if (!IsValidPhoneNumber(txtPhone.Text))
			{
				MessageBox.Show("Please enter a valid phone number (10 digits)", "Validation Error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private bool IsValidEmail(string email)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}

		private bool IsValidPhoneNumber(string phone)
		{
			return Regex.IsMatch(phone, @"^\d{10}$");
		}

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}