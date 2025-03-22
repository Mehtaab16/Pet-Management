using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Management
{
    public partial class MainPage : Form
    {
        private Label lblWelcome;
        private Button btnCreateRecord;
        private Button btnViewRecord;

        public MainPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Main Page";
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Welcome Label
            lblWelcome = new Label();
            lblWelcome.Text = "Welcome to Pet Management";
            lblWelcome.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(80, 30);

            // Create Record Button
            btnCreateRecord = new Button();
            btnCreateRecord.Text = "Create Record";
            btnCreateRecord.Font = new Font("Arial", 12F);
            btnCreateRecord.Size = new Size(150, 60);
            btnCreateRecord.Location = new Point(125, 80);
            btnCreateRecord.Click += new EventHandler(this.btnCreateRecord_Click);

            // View Record Button
            btnViewRecord = new Button();
            btnViewRecord.Text = "View Records";
            btnViewRecord.Font = new Font("Arial", 12F);
            btnViewRecord.Size = new Size(150, 60);
            btnViewRecord.Location = new Point(125, 160);
            btnViewRecord.Click += new EventHandler(this.btnViewRecord_Click);

            // Add Controls
            this.Controls.Add(lblWelcome);
            this.Controls.Add(btnCreateRecord);
            this.Controls.Add(btnViewRecord);
        }

        private void btnCreateRecord_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Create Record Clicked! (Navigate to Create Page)");
        }

        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View Record Clicked! (Navigate to View Page)");
        }
    }
}
