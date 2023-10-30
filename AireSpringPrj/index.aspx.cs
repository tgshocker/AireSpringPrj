using DAL;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace AireSpringPrj
{
	public partial class index : System.Web.UI.Page
	{
		private bllEmployee bllEmp = new bllEmployee();

		// This function is called when the page loads.
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LoadData();
			}
		}

		// This function cleans the search input and triggers data loading.
		protected void btnSearch_Click(object sender, EventArgs e) 
		{
			string searchValue = bllEmp.CleanInput(txtSearch.Text);
			txtSearch.Text = "";

			LoadData(searchValue);
		}

		// This function is called when the "Create Employee" button is clicked.
		protected void btnCreateEmployee_Click(object sender, EventArgs e)
		{
			FillAndDo();
		}

		// This function is called when the "Edit" text is clicked. Fills the TextBoxes, blocks the ID and forces the Index so it doesn't affect the table itself.
		protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
		{
			int indexUpdate = e.NewEditIndex;

			hAction.Value = "UPDATE";

			txtID.Text = gvEmployees.Rows[indexUpdate].Cells[0].Text;
			txtLastName.Text = gvEmployees.Rows[indexUpdate].Cells[1].Text;
			txtFirstName.Text = gvEmployees.Rows[indexUpdate].Cells[2].Text;
			txtPhone.Text = bllEmp.CleanInput(gvEmployees.Rows[indexUpdate].Cells[3].Text);
			txtZip.Text = gvEmployees.Rows[indexUpdate].Cells[4].Text;
			txtHireDate.Text = gvEmployees.Rows[indexUpdate].Cells[5].Text;

			txtID.Enabled = false;
			btnCreateEmployee.Text = "Update Employee";

			gvEmployees.EditIndex = -1;
			LoadData();
		}

		// This function is called when the "Delete" text is clicked, obtains the row index to delete it.
		protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			hAction.Value = "DELETE";
			
			string employeeID = gvEmployees.Rows[e.RowIndex].Cells[0].Text;

			FillAndDo(employeeID);
		}

		// This function loads data into the GridView based on the search criteria. If it has any value, does a specific search.
		private void LoadData(string value = "")
		{
			DataTable dt = new DataTable();

			if (string.IsNullOrEmpty(value))
			{
				dt = bllEmp.GetEmployees();
			}
			else
			{
				dt = bllEmp.SearchEmployees(value);
			}

			gvEmployees.DataSource = dt;
			gvEmployees.DataBind();
		}

		// This function determines the action (insert, update, or delete) and performs the corresponding operation.
		private void FillAndDo(string value = "")
		{
			string action = hAction.Value;

			if (action == "INSERT" || action == "UPDATE")
			{
				mEmployee employeeData = GetEmployeeDataTB();

				if (action == "INSERT")
				{
					bllEmp.AddEmployee(employeeData);
				}
				else if (action == "UPDATE")
				{
					bllEmp.UpdateEmployee(employeeData);
				}
			}
			else if (action == "DELETE")
			{
				string employeeID = value;
				bllEmp.DeleteEmployee(employeeID);
			}

			Response.Redirect(Request.Url.AbsolutePath);
		}

		// This function extracts employee data from the UI controls.
		private mEmployee GetEmployeeDataTB()
		{
			mEmployee employeeData = new mEmployee
			{
				EmployeeID = txtID.Text,
				EmployeeLastName = txtLastName.Text,
				EmployeeFirstName = txtFirstName.Text,
				EmployeePhone = bllEmp.CleanInput(txtPhone.Text),
				EmployeeZip = txtZip.Text,
				HireDate = bllEmp.ConvertToDate(txtHireDate.Text)
			};

			return employeeData;
		}
	}
}