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

namespace Pet_Management
{
    public partial class CreateForm : Form
    {
        private TabControl tabControl;
        private ComboBox cmbOwner, cmbPet, cmbSpecies, cmbBreed, cmbGender, cmbAge, cmbDiagnosis, cmbTreatment, cmbVet, cmbAppType;
        private string connectionString = "Data Source=MEHTAAB\\MSSQLSERVER02;Initial Catalog=Pet Management;Integrated Security=True;TrustServerCertificate=True";

        public CreateForm()
        {
            SetupUI();
            LoadOwners();
            LoadPets();
            LoadSpecies();
            LoadBreed();
            LoadGender();
            LoadAge();
            LoadDiagnosis();
            LoadTreatment();
            LoadVet();
            LoadAppointmentType();
        }

        private void SetupUI()
        {
            this.Text = "Paws & Co - Manage Records";
            this.Width = 400;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;

            tabControl = new TabControl { Width = this.ClientSize.Width - 20, Height = this.ClientSize.Height - 20 };
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            TabPage tabOwner = new TabPage("Owner");
            TabPage tabPet = new TabPage("Pet");
            TabPage tabAppointment = new TabPage("Appointment");
            TabPage tabMedical = new TabPage("Medical Record");

            // Owner Tab
            Label lblOwner = new Label() { Text = "Owner:", Top = 30, Left = 20, Width = 80 };
            cmbOwner = new ComboBox() { Top = 30, Left = 120, Width = 200 };
            Label lblAddress = new Label() { Text = "Address:", Top = 70, Left = 20, Width = 80 };
            TextBox txtAddress = new TextBox() { Top = 70, Left = 120, Width = 200 };
            Label lblPhone = new Label() { Text = "Phone:", Top = 110, Left = 20, Width = 80 };
            TextBox txtPhone = new TextBox() { Top = 110, Left = 120, Width = 200 };
            Button btnSaveOwner = new Button() { Text = "Save Owner", Top = 150, Left = 120, Width = 150 };
            btnSaveOwner.Click += (s, e) => SaveOwner(cmbOwner.Text, txtAddress.Text, txtPhone.Text);
            tabOwner.Controls.AddRange(new Control[] { lblOwner, cmbOwner, lblAddress, txtAddress, lblPhone, txtPhone, btnSaveOwner });

            // Pet Tab
            Label lblPetName = new Label() { Text = "Pet Name:", Top = 30, Left = 20, Width = 80 };
            TextBox txtPetName = new TextBox() { Top = 30, Left = 120, Width = 200 };
            Label lblSpecies = new Label() { Text = "Species:", Top = 70, Left = 20, Width = 80 };
            cmbSpecies = new ComboBox() { Top = 70, Left = 120, Width = 200 };
            Label lblBreed = new Label() { Text = "Breed:", Top = 110, Left = 20, Width = 80 };
            cmbBreed = new ComboBox() { Top = 110, Left = 120, Width = 200 };
            Label lblGender = new Label() { Text = "Gender:", Top = 150, Left = 20, Width = 80 };
            cmbGender = new ComboBox() { Top = 150, Left = 120, Width = 200 };
            Label lblAge = new Label() { Text = "Age:", Top = 190, Left = 20, Width = 80 };
            cmbAge = new ComboBox() { Top = 190, Left = 120, Width = 200 };
            Button btnSavePet = new Button() { Text = "Save Pet", Top = 230, Left = 120, Width = 150 };
            btnSavePet.Click += (s, e) => SavePet(txtPetName.Text, cmbSpecies.Text, cmbBreed.Text, cmbGender.Text, cmbAge.Text);
            tabPet.Controls.AddRange(new Control[] { lblPetName, txtPetName, lblSpecies, cmbSpecies, lblBreed, cmbBreed, lblGender, cmbGender, lblAge, cmbAge, btnSavePet });

            // Appointment Tab
            Label lblAppDate = new Label() { Text = "Date:", Top = 30, Left = 20, Width = 80 };
            DateTimePicker dtpAppDate = new DateTimePicker() { Top = 30, Left = 120, Width = 200 };
            Label lblAppType = new Label() { Text = "Type:", Top = 70, Left = 20, Width = 80 }; // Adjusted position
            cmbAppType = new ComboBox() { Top = 70, Left = 120, Width = 200 }; // Adjusted position
            Button btnSaveApp = new Button() { Text = "Save Appointment", Top = 70, Left = 120, Width = 180 };
            btnSaveApp.Click += (s, e) => SaveAppointment(cmbAppType.Text);
            tabAppointment.Controls.AddRange(new Control[] { lblAppDate, dtpAppDate, cmbPet, lblAppType, cmbAppType, btnSaveApp });

            // Medical Record Tab
            Label lblDiagnosis = new Label() { Text = "Diagnosis:", Top = 30, Left = 20, Width = 80 };
            cmbDiagnosis = new ComboBox() { Top = 30, Left = 120, Width = 200 };
            Label lblTreatment = new Label() { Text = "Treatment:", Top = 70, Left = 20, Width = 80 };
            cmbTreatment = new ComboBox() { Top = 70, Left = 120, Width = 200 };
            Label lblVet = new Label() { Text = "Vet Name:", Top = 110, Left = 20, Width = 80 };
            cmbVet = new ComboBox() { Top = 110, Left = 120, Width = 200 };
            Button btnSaveMed = new Button() { Text = "Save Medical Record", Top = 150, Left = 120, Width = 200 };
            btnSaveMed.Click += (s, e) => SaveMedicalRecord(cmbDiagnosis.Text, cmbTreatment.Text, cmbVet.Text);
            tabMedical.Controls.AddRange(new Control[] { lblDiagnosis, cmbDiagnosis, lblTreatment, cmbTreatment, lblVet, cmbVet, btnSaveMed });

            tabControl.TabPages.AddRange(new TabPage[] { tabOwner, tabPet, tabAppointment, tabMedical });
            this.Controls.Add(tabControl);
        }

        private void LoadOwners() {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT owner_id, name FROM owners", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbOwner.DataSource = dt;
                    cmbOwner.DisplayMember = "name";  // Show owner name
                    cmbOwner.ValueMember = "owner_id"; // Store owner ID internally
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading owners: " + ex.Message);
                }
            }
        }

        private void LoadPets()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT pet_id, name FROM pets", conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Ensure cmbPet is not null before assigning DataSource
                            if (cmbPet != null)
                            {
                                cmbPet.DataSource = dt;
                                cmbPet.DisplayMember = "name";  // Display pet name
                                cmbPet.ValueMember = "pet_id";  // Store pet ID
                            }
                            else
                            {
                                MessageBox.Show("cmbPet is null. Initialization issue detected.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pets: " + ex.Message);
            }
        }

        private void LoadSpecies() {
         
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT species FROM pets", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbSpecies.DataSource = dt;
                    cmbSpecies.DisplayMember = "species";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading species: " + ex.Message);
                }
            }
        }

        private void LoadBreed() {
        
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT breed FROM pets", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbBreed.DataSource = dt;
                    cmbBreed.DisplayMember = "breed";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading breeds: " + ex.Message);
                }
            }
        }

        private void LoadGender() {
        
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT gender FROM pets", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbGender.DataSource = dt;
                    cmbGender.DisplayMember = "gender";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading genders: " + ex.Message);
                }
            }
        }

        private void LoadAge() {
           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT age FROM pets ORDER BY age ASC", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbAge.DataSource = dt;
                    cmbAge.DisplayMember = "age";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading ages: " + ex.Message);
                }
            }
        }

        private void LoadDiagnosis() {
         
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT CAST(diagnosis AS NVARCHAR(MAX)) AS diagnosis FROM medical_records\r\n", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbDiagnosis.DataSource = dt;
                    cmbDiagnosis.DisplayMember = "diagnosis";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading diagnosis: " + ex.Message);
                }
            }
        }

        private void LoadTreatment() {
          
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT CAST(treatment AS NVARCHAR(MAX)) AS treatment FROM medical_records\r\n", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbTreatment.DataSource = dt;
                    cmbTreatment.DisplayMember = "treatment";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading treatment: " + ex.Message);
                }
            }
        }

        private void LoadVet() {
        
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT vet_name FROM medical_records", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbVet.DataSource = dt;
                    cmbVet.DisplayMember = "vet_name";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading vet names: " + ex.Message);
                }
            }
        }


        private void LoadAppointmentType() {
      
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT type FROM appointments", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbAppType.DataSource = dt;
                    cmbAppType.DisplayMember = "type";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading appointment types: " + ex.Message);
                }
            }
        }

        private void RefreshOwners()
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT owner_id, name FROM owners", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cmbOwner.DataSource = dt;
            cmbOwner.DisplayMember = "name";
            cmbOwner.ValueMember = "owner_id";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading owners: " + ex.Message);
        }
    }
}

private void SaveOwner(string name, string address, string phone)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Owners (name, address, phone) VALUES (@name, @address, @phone)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving owner: " + ex.Message);
        }
    }
}

private void SavePet(string name, string species, string breed, string gender, string age)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Pets (name, species, breed, gender, age) VALUES (@name, @species, @breed, @gender, @age)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@species", species);
            cmd.Parameters.AddWithValue("@breed", breed);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving pet: " + ex.Message);
        }
    }
}

private void SaveAppointment(string type)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Appointments (type) VALUES (@type)", conn);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving appointment: " + ex.Message);
        }
    }
}

private void SaveMedicalRecord(string diagnosis, string treatment, string vet)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Medical_Records (diagnosis, treatment, vet_name) VALUES (@diagnosis, @treatment, @vet)", conn);
            cmd.Parameters.AddWithValue("@diagnosis", diagnosis);
            cmd.Parameters.AddWithValue("@treatment", treatment);
            cmd.Parameters.AddWithValue("@vet", vet);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving medical record: " + ex.Message);
        }
    }
}

    }
}
