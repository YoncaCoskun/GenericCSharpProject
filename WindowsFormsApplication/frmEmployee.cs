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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        BaseBusiness<Employee> employeeBusiness = new BaseBusiness<Employee>(); 

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            ShowEmployee();
        }

        private void ShowEmployee()
        {
            dataGridView1.DataSource = employeeBusiness.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();

            employee.LastName = txtLastName.Text;
            employee.FirstName = txtFirstName.Text;
            employee.Title = txtTitle.Text;
            employee.TitleOfCourtesy = txtTitleOfCourtesy.Text;
            employee.BirthDate = dtpBirthDate.Value;
            employee.HireDate = dtpHireDate.Value;
            employee.Address = txtAddress.Text;
            employee.City = txtCity.Text;
            employee.Region = txtRegion.Text;
            employee.PostalCode = txtPostalCode.Text;
            employee.Country = txtCountry.Text;
            employee.HomePhone = txtHomePhone.Text;
            employee.Extension = txtExtension.Text;
            employee.Notes = txtNotes.Text;
            employee.PhotoPath = txtPhotoPath.Text;

            employeeBusiness.Add(employee);
            ShowEmployee();
            Clear();
        }

        private void Clear()
        {
            txtLastName.Clear();
            txtFirstName.Clear();
            txtTitle.Clear();
            txtTitleOfCourtesy.Clear();
            dtpBirthDate.Value = DateTime.Now;
            dtpHireDate.Value = DateTime.Now;
            txtAddress.Clear();
            txtCity.Clear();
            txtRegion.Clear();
            txtPostalCode.Clear();
            txtCountry.Clear();
            txtHomePhone.Clear();
            txtExtension.Clear();
            txtNotes.Clear();
            txtPhotoPath.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblEmployeeID.Text);

           Employee guncellenecekCalisan= employeeBusiness.GetById(id);

           guncellenecekCalisan.LastName = txtLastName.Text;
           guncellenecekCalisan.FirstName = txtFirstName.Text;
           guncellenecekCalisan.Title = txtTitle.Text;
           guncellenecekCalisan.TitleOfCourtesy = txtTitleOfCourtesy.Text;
           guncellenecekCalisan.BirthDate = dtpBirthDate.Value;
           guncellenecekCalisan.HireDate = dtpHireDate.Value;
           guncellenecekCalisan.Address = txtAddress.Text;
           guncellenecekCalisan.City = txtCity.Text;
           guncellenecekCalisan.PostalCode = txtPostalCode.Text;
           guncellenecekCalisan.Country = txtCountry.Text;
           guncellenecekCalisan.HomePhone = txtHomePhone.Text;
           guncellenecekCalisan.Extension = txtExtension.Text;
           guncellenecekCalisan.Notes = txtNotes.Text;
           guncellenecekCalisan.PhotoPath = txtPhotoPath.Text;



          
           employeeBusiness.Update(guncellenecekCalisan);

            ShowEmployee();
            Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            string id = dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value.ToString();
            string lastname = dataGridView1.SelectedRows[0].Cells["LastName"].Value.ToString();
            string firstname= dataGridView1.SelectedRows[0].Cells["FirstName"].Value.ToString();
            string title = dataGridView1.SelectedRows[0].Cells["Title"].Value.ToString();
            string titleofcourtesy = dataGridView1.SelectedRows[0].Cells["TitleOfCourtesy"].Value.ToString();
            string birthdate = dataGridView1.SelectedRows[0].Cells["BirthDate"].Value.ToString();
            string hiredate = dataGridView1.SelectedRows[0].Cells["HireDate"].Value.ToString();
            string address = dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString();
            string city = dataGridView1.SelectedRows[0].Cells["City"].Value.ToString();
            string region= dataGridView1.SelectedRows[0].Cells["Region"].Value.ToString();
            string postalcode = dataGridView1.SelectedRows[0].Cells["PostalCode"].Value.ToString();
            string country= dataGridView1.SelectedRows[0].Cells["Country"].Value.ToString();
            string homephone= dataGridView1.SelectedRows[0].Cells["HomePhone"].Value.ToString();
            string extension = dataGridView1.SelectedRows[0].Cells["Extension"].Value.ToString();
            string notes = dataGridView1.SelectedRows[0].Cells["Notes"].Value.ToString();
            string photopath = dataGridView1.SelectedRows[0].Cells["PhotoPath"].Value.ToString();


            lblEmployeeID.Text = id;
            txtLastName.Text = lastname;
            txtFirstName.Text = firstname;
            txtTitle.Text = title;
            txtTitleOfCourtesy.Text = titleofcourtesy;
            dtpBirthDate.Text = birthdate;
            dtpHireDate.Text = hiredate;
            txtAddress.Text = address;
            txtCity.Text = city;
            txtRegion.Text = region;
            txtPostalCode.Text = postalcode;
            txtCountry.Text = country;
            txtHomePhone.Text = homephone;
            txtExtension.Text = extension;
            txtNotes.Text = notes;
            txtPhotoPath.Text = photopath;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblEmployeeID.Text);

            Employee silinecekCalisan= employeeBusiness.GetById(id);

            silinecekCalisan.EmployeeID= Convert.ToInt32(lblEmployeeID.Text);
            silinecekCalisan.LastName = txtLastName.Text;
           silinecekCalisan.FirstName = txtFirstName.Text;
           silinecekCalisan.Title = txtTitle.Text;
           silinecekCalisan.TitleOfCourtesy = txtTitleOfCourtesy.Text;
           silinecekCalisan.BirthDate = dtpBirthDate.Value;
           silinecekCalisan.HireDate = dtpHireDate.Value;
           silinecekCalisan.Address = txtAddress.Text;
           silinecekCalisan.City = txtCity.Text;
           silinecekCalisan.PostalCode = txtPostalCode.Text;
           silinecekCalisan.Country = txtCountry.Text;
           silinecekCalisan.HomePhone = txtHomePhone.Text;
           silinecekCalisan.Extension = txtExtension.Text;
           silinecekCalisan.Notes = txtNotes.Text;
           silinecekCalisan.PhotoPath = txtPhotoPath.Text;
            

            employeeBusiness.Remove(silinecekCalisan);
            ShowEmployee();
            Clear();
        }
    }
}
