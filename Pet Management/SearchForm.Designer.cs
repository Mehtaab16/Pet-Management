

namespace Pet_Management
{
    partial class SearchForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResults;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Size = new System.Drawing.Size(200, 20);

            // cmbFilter
            this.cmbFilter.Location = new System.Drawing.Point(240, 20);
            this.cmbFilter.Size = new System.Drawing.Size(150, 20);
            this.cmbFilter.Items.AddRange(new string[] { "Pet Name", "Owner Name", "Appointment Type", "Diagnosis" });
            this.cmbFilter.SelectedIndex = 0; // Default selection

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(410, 20);
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.Text = "Search";
            // DO NOT define the event handler here in the Designer file

            // dgvResults
            this.dgvResults.Location = new System.Drawing.Point(20, 60);
            this.dgvResults.Size = new System.Drawing.Size(500, 300);
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // SearchForm
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvResults);
            this.Text = "Search Form";

            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
