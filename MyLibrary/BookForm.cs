using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyLibrary
{
	public partial class BookForm : Form
	{
        private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MyLibrary;Integrated Security=True;";
        public int BookId { get; set; } = -1;

		public BookForm()
		{
			InitializeComponent();
		}

		private void BookForm_Load(object sender, EventArgs e)
		{
			if (BookId > 0) LoadBookDetails();
		}

		private void LoadBookDetails()
		{
			try
			{
				using (var connection = new SqlConnection(ConnectionString))
				{
					connection.Open();
					var command = new SqlCommand(
						"SELECT Title, Author, Year, AvailableCopies FROM Books WHERE BookID = @ID",
						connection);
					command.Parameters.AddWithValue("@ID", BookId);

					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							txtTitle.Text = reader["Title"].ToString();
							txtAuthor.Text = reader["Author"].ToString();
							txtYear.Text = reader["Year"].ToString();
							txtCopies.Text = reader["AvailableCopies"].ToString();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading book: {ex.Message}", "Error",
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

					if (BookId > 0)
					{
						// Update existing book
						command = new SqlCommand(
							"UPDATE Books SET Title = @Title, Author = @Author, " +
							"Year = @Year, AvailableCopies = @Copies WHERE BookID = @ID",
							connection);
						command.Parameters.AddWithValue("@ID", BookId);
					}
					else
					{
						// Insert new book
						command = new SqlCommand(
							"INSERT INTO Books (Title, Author, Year, AvailableCopies) " +
							"VALUES (@Title, @Author, @Year, @Copies)",
							connection);
					}

					command.Parameters.AddWithValue("@Title", txtTitle.Text);
					command.Parameters.AddWithValue("@Author", txtAuthor.Text);
					command.Parameters.AddWithValue("@Year", int.Parse(txtYear.Text));
					command.Parameters.AddWithValue("@Copies", int.Parse(txtCopies.Text));

					command.ExecuteNonQuery();

					MessageBox.Show("Book saved successfully!", "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error saving book: {ex.Message}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (BookId < 0) return;

			if (MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete",
				MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				try
				{
					using (var connection = new SqlConnection(ConnectionString))
					{
						connection.Open();
						var command = new SqlCommand(
							"DELETE FROM Books WHERE BookID = @ID", connection);
						command.Parameters.AddWithValue("@ID", BookId);
						command.ExecuteNonQuery();
					}

					MessageBox.Show("Book deleted successfully!", "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error deleting book: {ex.Message}", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private bool ValidateInputs()
		{
			if (string.IsNullOrWhiteSpace(txtTitle.Text))
			{
				MessageBox.Show("Please enter a title", "Validation Error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!int.TryParse(txtYear.Text, out int year) || year < 0)
			{
				MessageBox.Show("Please enter a valid publication year", "Validation Error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (!int.TryParse(txtCopies.Text, out int copies) || copies < 0)
			{
				MessageBox.Show("Please enter a valid number of copies", "Validation Error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}
	}
}