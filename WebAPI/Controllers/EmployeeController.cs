using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController

    {
        public HttpResponseMessage Get()
        {   
            DataTable table = new DataTable();

            string query = @"select EmployeeID,EmployeeName,Department,MailID,CONVERT(varchar(10),DOJ,120) as DOJ from dbo.Employees";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(Employees emp)
        {
            try
            {
                DataTable table = new DataTable();

                string doj = emp.DOJ.ToString().Split(' ')[0];

                string query = @"insert into dbo.Employees (EmployeeName,Department,MailID,DOJ) values (
            '" + emp.EmployeeName + @"',
            '" + emp.Department + @"',
            '" + emp.MailId+ @"',
            '" + emp.DOJ+ @"'

            )";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added succesfully";
            }
            catch (Exception ex)
            {

                return "Failed to add";
            }

        }
        public string Put(Employees emp)
        {
            try
            {
                DataTable table = new DataTable();


                string query = @"update  dbo.Employees set 
            EmployeeName= '" + emp.EmployeeName + @"',
            Department= '" + emp.Department + @"',
            MailID='" + emp.MailId + @"',
            DOJ='" + emp.DOJ + @"'
        where EmployeeId="+emp.EmployeeID+@"

            ";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Update succesfully";
            }
            catch (Exception ex)
            {

                return "Failed to add";
            }

        }
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();


                string query = @"delete from  dbo.Employees where EmployeeId= " + id;


                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Delete succesfully";
            }
            catch (Exception ex)
            {

                return "Failed to add";
            }

        }

    }
}
