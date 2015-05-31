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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        BaseBusiness<Customer> customerBusiness = new BaseBusiness<Customer>(); 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

            customer.CompanyName = txtCompanyName.Text;
            customer.ContactName = txtContactName.Text;
            customer.ContactTitle = txtContactTitle.Text;
            customer.Country = txtCountry.Text;
            customer.City = txtCity.Text;
            customer.Address = txtAddress.Text;
            customer.Fax = txtFax.Text;
            customer.Phone = txtPhone.Text;
            customer.PostalCode = txtPostalCode.Text;
            customer.Region = txtRegion.Text;
            

            customerBusiness.Add(customer);
            ShowCustomer();
            Clear();
        }

        private void Clear()
        {
            lblCustomerID.Text = "";
            txtCompanyName.Clear();
            txtContactName.Clear();
            txtCountry.Clear();
            txtFax.Clear();
            txtPhone.Clear();
            txtPostalCode.Clear();
            txtRegion.Clear();
            txtCity.Clear();
            txtAddress.Clear();
            txtContactTitle.Clear();
        }

        private void ShowCustomer()
        {
            dataGridView1.DataSource = customerBusiness.GetAll();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            ShowCustomer();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblCustomerID.Text);

            Customer guncellenecekMusteri= customerBusiness.GetById(id);

            guncellenecekMusteri.CompanyName = txtCompanyName.Text;
            guncellenecekMusteri.ContactName = txtContactName.Text;
            guncellenecekMusteri.ContactTitle = txtContactTitle.Text;
            guncellenecekMusteri.Country = txtCountry.Text;
            guncellenecekMusteri.City = txtCity.Text;
            guncellenecekMusteri.Address = txtAddress.Text;
            guncellenecekMusteri.Fax= txtFax.Text;
            guncellenecekMusteri.Phone = txtPhone.Text;
            guncellenecekMusteri.PostalCode = txtPostalCode.Text;
            guncellenecekMusteri.Region= txtRegion.Text;

            customerBusiness.Update(guncellenecekMusteri);

            ShowCustomer();
            Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblCustomerID.Text);

            Customer silinecekMusteri = customerBusiness.GetById(id);

            silinecekMusteri.CustomerId= Convert.ToInt32(lblCustomerID.Text);
            silinecekMusteri.CompanyName = txtCompanyName.Text;
            silinecekMusteri.ContactName = txtContactName.Text;
            silinecekMusteri.ContactTitle = txtContactTitle.Text;
            silinecekMusteri.Country = txtCountry.Text;
            silinecekMusteri.City = txtCity.Text;
            silinecekMusteri.Address = txtAddress.Text;
            silinecekMusteri.Fax = txtFax.Text;
            silinecekMusteri.Phone = txtPhone.Text;
            silinecekMusteri.PostalCode = txtPostalCode.Text;
            silinecekMusteri.Region = txtRegion.Text;

            customerBusiness.Remove(silinecekMusteri);
            ShowCustomer();
            Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            string id = dataGridView1.SelectedRows[0].Cells["CustomerID"].Value.ToString();
            string companyName = dataGridView1.SelectedRows[0].Cells["CompanyName"].Value.ToString();
            string contactName = dataGridView1.SelectedRows[0].Cells["ContactName"].Value.ToString();
            string contactTitle = dataGridView1.SelectedRows[0].Cells["ContactTitle"].Value.ToString();
            string address = dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString();
            string city = dataGridView1.SelectedRows[0].Cells["City"].Value.ToString();
            string region = dataGridView1.SelectedRows[0].Cells["Region"].Value.ToString();
            string postalCode = dataGridView1.SelectedRows[0].Cells["PostalCode"].Value.ToString();
            string country = dataGridView1.SelectedRows[0].Cells["Country"].Value.ToString();
            string phone = dataGridView1.SelectedRows[0].Cells["Phone"].Value.ToString();
            string fax = dataGridView1.SelectedRows[0].Cells["Fax"].Value.ToString();



            lblCustomerID.Text = id;
            txtCompanyName.Text = companyName;
            txtContactName.Text = contactName;
            txtContactTitle.Text = contactTitle;
            txtAddress.Text = address;
            txtCity.Text = city;
            txtRegion.Text = region;
            txtPostalCode.Text = postalCode;
            txtCountry.Text = country;
            txtPhone.Text = phone;
            txtFax.Text = fax;
        }
    }
}
