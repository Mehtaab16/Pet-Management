using System;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Pet_Management
{
    public partial class LoginForm : Form
    {
        private Label lblHello;
        private Button btnLogin;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblHello = new Label();
            this.btnLogin = new Button();
            this.SuspendLayout();

            // "Hello" Label
            this.lblHello.AutoSize = true;
            this.lblHello.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblHello.Location = new System.Drawing.Point(110, 50);
            this.lblHello.Text = "Hello";

            // Login Button
            this.btnLogin.Font = new System.Drawing.Font("Arial", 12F);
            this.btnLogin.Location = new System.Drawing.Point(90, 100);
            this.btnLogin.Size = new System.Drawing.Size(120, 40);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.btnLogin);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage(); // Create an instance of MainPage
            mainPage.Show(); // Show the main page
            this.Hide(); // Hide the login form
        }

    }
}


