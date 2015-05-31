using Northwind.Business;
using Northwind.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }
        BaseBusiness<Category> categoryBusiness = new BaseBusiness<Category>(); 
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowCategory();
        }

        private void ShowCategory()
        {
            dataGridView1.DataSource = categoryBusiness.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();

            category.CategoryName = txtCategoryName.Text;
            category.Description = txtDescription.Text;

            categoryBusiness.Add(category);
            ShowCategory();
            Clear();
        }

        private void Clear()
        {
            txtDescription.Clear();
            txtCategoryName.Clear();
            lblCategoryID.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblCategoryID.Text);

           Category guncellenecekKategori = categoryBusiness.GetById(id);

            guncellenecekKategori.CategoryName = txtCategoryName.Text.Trim();
            guncellenecekKategori.Description = txtDescription.Text.Trim();
           
            categoryBusiness.Update(guncellenecekKategori);

            ShowCategory();
            Clear();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            string id = dataGridView1.SelectedRows[0].Cells["CategoryID"].Value.ToString();
            string ad = dataGridView1.SelectedRows[0].Cells["CategoryName"].Value.ToString();
            string aciklama = dataGridView1.SelectedRows[0].Cells["Description"].Value.ToString();


            txtCategoryName.Text = ad;
            txtDescription.Text = aciklama;
            lblCategoryID.Text = id;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblCategoryID.Text);

            Category silinecekKategori = categoryBusiness.GetById(id);

            silinecekKategori.CategoryID = Convert.ToInt32(lblCategoryID.Text);
            silinecekKategori.CategoryName = txtCategoryName.Text;
            silinecekKategori.Description = txtDescription.Text;

            categoryBusiness.Remove(silinecekKategori);
            ShowCategory();
            Clear();
        }

       
      
    }
}
