using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Pet_Management.Models;
public partial class SearchForm : Form
{
    private TextBox txtSearch;
    private ComboBox cmbFilter;
    private Button btnSearch;
    private DataGridView dgvResults;

    public SearchForm()
    {
        InitializeComponent(); // Ensure default UI initialization is called
        btnSearch.Click += BtnSearch_Click;
    }

    private void InitializeComponent()
    {
        this.txtSearch = new TextBox() { Top = 20, Left = 20, Width = 200 };
        this.cmbFilter = new ComboBox() { Top = 20, Left = 240, Width = 150 };
        this.cmbFilter.Items.AddRange(new string[] { "Pet Name", "Owner Name", "Appointment Type", "Diagnosis" });
        this.cmbFilter.SelectedIndex = 0; // Default selection
        this.btnSearch = new Button() { Text = "Search", Top = 20, Left = 410, Width = 100 };
        this.btnSearch.Click += BtnSearch_Click; // Attach event properly
        this.dgvResults = new DataGridView() { Top = 60, Left = 20, Width = 500, Height = 300 };
        this.dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Add Controls to Form
        this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.cmbFilter);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.dgvResults);

        // Set form properties
        this.ClientSize = new System.Drawing.Size(600, 400);
        this.Text = "Search Form";
    }

    private void BtnSearch_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtSearch.Text))
        {
            MessageBox.Show("Please enter a search term.");
            return;
        }

        PerformSearch();
    }

    private void PerformSearch()
    {
        try
        {
            string connectionString = "Data Source=MEHTAAB\\MSSQLSERVER02;Initial Catalog=Pet Management;Integrated Security=True;TrustServerCertificate=True"; // Replace with your actual DB connection string
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = GenerateQuery(); // Get SQL query based on filter

                // Debug: Show the query being executed
                MessageBox.Show("Executing query: " + query);

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchValue", "%" + txtSearch.Text + "%"); // Add parameterized search

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Check if data is retrieved
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No results found."); // Display message if no data is returned
                        }

                        dgvResults.DataSource = dt; // Load results into DataGridView
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error during search: " + ex.Message);
        }
    }

    private string GenerateQuery()
    {
        string filter = cmbFilter.SelectedItem.ToString();
        string query = "";

        switch (filter)
        {
            case "Pet Name":
                query = "SELECT pet_id, name, species, breed FROM Pets WHERE name LIKE @searchValue";
                break;
            case "Owner Name":
                query = "SELECT owner_id, name, phone FROM Owners WHERE name LIKE @searchValue";
                break;
            case "Appointment Type":
                query = "SELECT appointment_id, type, status FROM Appointments WHERE type LIKE @searchValue";
                break;
            case "Diagnosis":
                query = "SELECT record_id, diagnosis, treatment FROM MedicalRecords WHERE diagnosis LIKE @searchValue";
                break;
            default:
                query = "SELECT pet_id, name FROM Pets"; // Default query (No search filter)
                break;
        }

        return query;
    }
}

