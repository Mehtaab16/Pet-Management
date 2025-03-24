using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pet_Management;

namespace Pet_Management
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            SetupUI(); // Call method to create UI
        }

        private void SetupUI()
        {
            this.Text = "Paws & Co - Menu";
            this.Width = 400;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set Background Image
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Resources", "menu_bg.png");
            if (System.IO.File.Exists(imagePath))
            {
                this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch; // Cover full form
            }
            else
            {
                MessageBox.Show("Menu background image not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Menu options
            string[] options = { "Create Record", "View Record", "Search Record", "Sort Record", "Delete Record" };

            for (int i = 0; i < options.Length; i++)
            {
                Button btnOption = new Button();
                btnOption.Text = options[i];
                btnOption.Width = 200;
                btnOption.Height = 40;
                btnOption.Font = new Font("Arial", 10, FontStyle.Bold);
                btnOption.Location = new Point(100, 60 + (i * 60));

                // Brown Theme
                btnOption.BackColor = Color.SaddleBrown;
                btnOption.ForeColor = Color.White;
                btnOption.FlatStyle = FlatStyle.Flat;
                btnOption.FlatAppearance.BorderSize = 0;
                btnOption.FlatAppearance.MouseOverBackColor = Color.Peru; // Hover Effect
                btnOption.FlatAppearance.MouseDownBackColor = Color.Sienna; // Click Effect

                btnOption.Tag = options[i];  // Store text as tag
                btnOption.Click += BtnOption_Click;
                this.Controls.Add(btnOption);
            }
        }

        private void BtnOption_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string action = clickedButton.Tag.ToString();

            switch (action)
            {
                case "Create Record":
                    new CreateForm().ShowDialog();
                    break;
                case "View Record":
                    new ViewForm().ShowDialog();
                    break;
                case "Search Record":
                    new SearchForm().ShowDialog();
                    break;
                case "Sort Record":
                    new SortForm().ShowDialog();
                    break;
                case "Delete Record":
                    new DeleteForm().ShowDialog();
                    break;
            }
        }

    }
}


