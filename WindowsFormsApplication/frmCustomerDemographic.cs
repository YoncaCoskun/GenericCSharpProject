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
    public partial class frmCustomerDemographic : Form
    {
        public frmCustomerDemographic()
        {
            InitializeComponent();
        }

        BaseBusiness<CustomerDemographic> customerDemographicBusiness = new BaseBusiness<CustomerDemographic>();
        private void frmCustomerDemographic_Load(object sender, EventArgs e)
        {
            ShowCustomerDemographic();
        }

        private void ShowCustomerDemographic()
        {
            dataGridView1.DataSource = customerDemographicBusiness.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerDemographic customerDemo = new CustomerDemographic();

            customerDemo.Desc = txtDesc.Text;

            customerDemographicBusiness.Add(customerDemo);

            ShowCustomerDemographic();
            Clear();
        }

        private void Clear()
        {
            txtDesc.Clear();
            lblCustomerTypeID.Text = "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            string id = dataGridView1.SelectedRows[0].Cells["CustomerTypeID"].Value.ToString();
            string aciklama = dataGridView1.SelectedRows[0].Cells["Desc"].Value.ToString();



            txtDesc.Text = aciklama;
            lblCustomerTypeID.Text = id;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblCustomerTypeID.Text);

            CustomerDemographic guncellenecekMusteriDemo = customerDemographicBusiness.GetById(id);

           
            guncellenecekMusteriDemo.Desc = txtDesc.Text.Trim();

            customerDemographicBusiness.Update(guncellenecekMusteriDemo);

            ShowCustomerDemographic();
            Clear();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblCustomerTypeID.Text);

            CustomerDemographic silinecekMusteriDemo = customerDemographicBusiness.GetById(id);

            silinecekMusteriDemo.CustomerTypeID = Convert.ToInt32(lblCustomerTypeID.Text);
            silinecekMusteriDemo.Desc = txtDesc.Text;

            customerDemographicBusiness.Remove(silinecekMusteriDemo);
            ShowCustomerDemographic();
            Clear();
        }
    }
}
