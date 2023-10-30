using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using Model;
using System.Net.NetworkInformation;

namespace DAL
{
	public class sqlEmployee
	{
		string connString = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ConnectionString; //Variable in the web.config file

		// Insert a new employee into the database using a stored procedure and returns a message.
		public string InsertEmployee(mEmployee employeeData)
		{
			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand("spr_insertEmployee", connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@EmployeeID", employeeData.EmployeeID);
					command.Parameters.AddWithValue("@LastName", employeeData.EmployeeLastName);
					command.Parameters.AddWithValue("@FirstName", employeeData.EmployeeFirstName);
					command.Parameters.AddWithValue("@EmployeePhone", employeeData.EmployeePhone);
					command.Parameters.AddWithValue("@EmployeeZip", employeeData.EmployeeZip);
					command.Parameters.AddWithValue("@HireDate", employeeData.HireDate);

					string message = command.ExecuteScalar().ToString();

					return message;
				}
			}
		}

		// Update an existing employee in the database using a stored procedure and returns a message.
		public string UpdateEmployee(mEmployee employeeData)
		{
			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand("spr_updateEmployee", connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@EmployeeID", employeeData.EmployeeID);
					command.Parameters.AddWithValue("@LastName", employeeData.EmployeeLastName);
					command.Parameters.AddWithValue("@FirstName", employeeData.EmployeeFirstName);
					command.Parameters.AddWithValue("@EmployeePhone", employeeData.EmployeePhone);
					command.Parameters.AddWithValue("@EmployeeZip", employeeData.EmployeeZip);
					command.Parameters.AddWithValue("@HireDate", employeeData.HireDate);

					string message = command.ExecuteScalar().ToString();
					
					return message;
				}
			}
		}

		// Delete an employee from the database by their unique ID using a stored procedure and returns a message.
		public string DeleteEmployee(string employeeID)
		{
			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand("spr_deleteEmployee", connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@EmployeeID", employeeID);

					string message = command.ExecuteScalar().ToString();

					return message;
				}
			}
		}

		// Retrieve a DataTable containing all employees from the database using a stored procedure.
		public DataTable GetEmployees()
		{
			DataTable employees = new DataTable();

			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand("spr_getEmployees", connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					using (SqlDataAdapter adapter = new SqlDataAdapter(command))
					{
						adapter.Fill(employees);
					}
				}
			}

			return employees;
		}

		// Search for employees based on a search value (phone or last name) and return the results in a DataTable using a stored procedure.
		public DataTable SearchEmployees(string valueSearch)
		{
			DataTable dt = new DataTable();

			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand("spr_SearchEmployees", connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@searchValue", valueSearch);

					using (SqlDataAdapter adapter = new SqlDataAdapter(command))
					{
						adapter.Fill(dt);
					}
				}
			}

			return dt;
		}

	}
}