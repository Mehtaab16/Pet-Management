using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace Pet_Management
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            // Enable Windows Forms UI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run the login form
            Application.Run(new LoginForm());

            // Console application part (runs after closing the form)
            Console.WriteLine("Hello, World!");

            // Corrected connection string
            string connectionString = @"Data Source=MEHTAAB\MSSQLSERVER02;Initial Catalog=Pet Management;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString)) // Initialize connection
            {
                try
                {
                    conn.Open(); // Open connection
                    Console.WriteLine("Database connection successful!");

                    // Create SQL query
                    string query = "SELECT * FROM owners";

                    // Create DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    // Create DataTable
                    DataTable dataTable = new DataTable();

                    // Fill DataTable with data from database
                    adapter.Fill(dataTable);

                    // Loop through DataTable rows
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine($"{row["owner_id"]} - {row["name"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }
        }
    }
}




