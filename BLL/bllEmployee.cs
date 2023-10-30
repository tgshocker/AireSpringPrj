using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BLL
{
	public class bllEmployee
	{
		private sqlEmployee sqlEmployee = new sqlEmployee();

		// Retrieve a DataTable with all employees.
		public DataTable GetEmployees()
		{
			return sqlEmployee.GetEmployees();
		}

		// Inserts a new employee and return a message indicating success or an error. (To use in Pop-up)
		public string AddEmployee(mEmployee employeeData)
		{
			return sqlEmployee.InsertEmployee(employeeData);
		}

		// Update an existing employee and return a message indicating success or an error. (To use in Pop-up)
		public string UpdateEmployee(mEmployee employeeData)
		{
			return sqlEmployee.UpdateEmployee(employeeData);
		}

		// Delete an employee by their unique ID and return a message indicating success or an error. (To use in Pop-up)
		public string DeleteEmployee(string idEmployee)
		{
			return sqlEmployee.DeleteEmployee(idEmployee);
		}

		// Search for employees based on a search value (phone or last name) and return the results in a DataTable.
		public DataTable SearchEmployees(string valueSearch)
		{
			return sqlEmployee.SearchEmployees(valueSearch);
		}

		// Clean and format input by removing characters like '-', '(', ')', and spaces.
		public string CleanInput(string input)
		{
			return input.Trim().Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
		}

		// Convert a string to a DateTime object, returning today's date if parsing fails.
		public DateTime ConvertToDate(string date)
		{
			if (DateTime.TryParse(date, out DateTime parsedDate))
			{
				return parsedDate;
			}
			else
			{
				return DateTime.Today;
			}
		}
	}
}