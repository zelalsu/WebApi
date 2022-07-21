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
    public class DepartmentController : ApiController
    {
        //benimm projeymmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public HttpResponseMessage Get()
        { 
        DataTable table = new DataTable();
        string query = @"select DepartmentID,DepartmentName from dbo.Department";
        var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDb"].ConnectionString);

        var command = new SqlCommand(query, con);//hangi sorguyu çektiğimiz ve hangi database den aldığımız 
        using (var da=new SqlDataAdapter(command))//içeride bir hata varsa direkt fırlatır. Güvenlik için
        {
                command.CommandType = CommandType.Text;
                //dataadapter le table ı doldurulur
                da.Fill(table);//2 ye 2 lik tablo dolmuş olarak geliyor
        }
            return Request.CreateResponse(HttpStatusCode.OK, table);//api den açğırıdğında karşı tarafa aktarılmış oluyor 
    }
        public string Post(Department dep)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.Department values('"+dep.DepartmentName+@"')";
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDb"].ConnectionString);

                var command = new SqlCommand(query, con);//hangi sorguyu çektiğimiz ve hangi database den aldığımız 
                using (var da = new SqlDataAdapter(command))//içeride bir hata varsa direkt fırlatır. Güvenlik için
                {
                    command.CommandType = CommandType.Text;
                    //dataadapter le table ı doldurulur
                    da.Fill(table);//2 ye 2 lik tablo dolmuş olarak geliyor
                }
                return "Eklendiii";
               
            }
            catch (Exception ex)
            {

                return "Failed to add";
                throw;
            }
        }
        public string Put(Department dep)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update dbo.Department set DepartmentName='" + dep.DepartmentName +
                    @"' where  DepartmentID=" + dep.DepartmentId + @"
                    ";
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDb"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "updated succesfully";
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
                string query = @"delete from dbo.Department where DepartmentID = " + id;

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDb"].ConnectionString);
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

    }
}