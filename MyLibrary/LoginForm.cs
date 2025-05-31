using MyLibrary;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyLibraryApp
{
	public partial class LoginForm : Form
	{
		private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MyLibrary;Integrated Security=True;";

		public LoginForm()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(ConnectionString))
				{
					string query = @"SELECT COUNT(*) FROM Users 
                                   WHERE Username = @Username 
                                   AND Password = @Password";

					connection.Open();

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
						command.Parameters.AddWithValue("@Password", txtPassword.Text);

						int result = (int)command.ExecuteScalar();

						if (result > 0)
						{
							this.Hide();
							new MainForm().Show();
						}
						else
						{
							MessageBox.Show("Invalid username or password!", "Login Failed",
										  MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
			catch (SqlException ex)
			{
				MessageBox.Show($"Database error: {ex.Message}", "Error",
							  MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}", "Error",
							  MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}