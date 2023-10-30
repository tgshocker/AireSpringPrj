using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
	// Employee entity with the following attributes: EmployeeID, name, phone, zip, and hire date.
	public class mEmployee
	{
		// Unique identifier for the employee.
		public string EmployeeID { get; set; }

		// Last name of the employee.
		public string EmployeeLastName { get; set; }

		// First name of the employee.
		public string EmployeeFirstName { get; set; }

		// Phone number of the employee.
		public string EmployeePhone { get; set; }

		// ZIP code of the employee.
		public string EmployeeZip { get; set; }

		// Date of hire for the employee in MM/DD/YYYY format.
		public DateTime HireDate { get; set; }

		// Constructor to initialize the Employee object with values.
		public mEmployee(string id, string lastName, string firstName, string phone, string zip, DateTime hireDate)
		{
			EmployeeID = id;
			EmployeeLastName = lastName;
			EmployeeFirstName = firstName;
			EmployeePhone = phone;
			EmployeeZip = zip;
			HireDate = hireDate;
		}

		// Default constructor.
		public mEmployee()
		{
		}
	}
}