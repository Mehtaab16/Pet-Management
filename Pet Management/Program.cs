using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Keeping SqlClient reference
using Pet_Management.Models; // Namespace for generated EF models

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
            Application.Run(new SearchForm());  // Make sure SearchForm is being run here

            // Console application part (runs after closing the form)
            Console.WriteLine("Hello, World!");

            // Connection string for reference (Not used in EF directly)
            string connectionString = @"Data Source=MEHTAAB\MSSQLSERVER02;Initial Catalog=Pet Management;Integrated Security=True;TrustServerCertificate=True";
            Console.WriteLine("Using database: " + connectionString);

            // Database operations using Entity Framework
            using (var context = new PetManagementContext()) // Database Context
            {
                try
                {
                    Console.WriteLine("Fetching owners from database using EF...");

                    var owners = context.Owners.ToList(); // Fetch data from "owners" table

                    Console.WriteLine("Owners List:");
                    foreach (var owner in owners)
                    {
                        Console.WriteLine($"{owner.OwnerId} - {owner.Name}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
