using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Management
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            SetupUI();
        }
        private void SetupUI()
        {
            // Form properties
            this.Text = "Paws & Co - Login";
            this.Width = 400;
            this.Height = 300;
            this.BackColor = Color.White; // Clean background

            // Get the correct image path
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Resources", "pawprints_bg - Copy.jpg");

            if (System.IO.File.Exists(imagePath))
            {
                this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Tile;
            }
            else
            {
                MessageBox.Show("Background image not found! Ensure 'pawprints_bg.jpg' is in the Resources folder.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // "Hello!" Label
            Label lblHello = new Label();
            lblHello.Text = "Hello!";
            lblHello.Font = new Font("Comic Sans MS", 16, FontStyle.Bold);
            lblHello.AutoSize = true;
            lblHello.Location = new Point(160, 40); // Centered horizontally
            lblHello.ForeColor = Color.SaddleBrown;
            this.Controls.Add(lblHello);

            // "Welcome to Paws & Co" Label
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome to Paws & Co";
            lblWelcome.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(100, 80); // Below "Hello!"
            lblWelcome.ForeColor = Color.SaddleBrown;
            this.Controls.Add(lblWelcome);

            // Login Button
            Button btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Font = new Font("Arial", 10, FontStyle.Bold);
            btnLogin.BackColor = Color.SaddleBrown;
            btnLogin.ForeColor = Color.White;
            btnLogin.Width = 120;
            btnLogin.Height = 40;
            btnLogin.Location = new Point(140, 150);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0; // No border
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Brown; // Optional: Darker brown on hover
            btnLogin.FlatAppearance.MouseDownBackColor = Color.SaddleBrown; // Optional: Click effect
            btnLogin.Click += BtnLogin_Click;
            this.Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menu = new MenuForm();
            menu.Show();
        }
    }
}