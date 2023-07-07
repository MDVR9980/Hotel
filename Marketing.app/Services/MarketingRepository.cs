using Marketing.app.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace Marketing.app
{
    internal class MarketingRepository : IMarketingRepository
    {
        private string connectionString = "data Source=.;Initial Catalog=MarketingWebsite;Integrated Security=true";
        public bool Delete(int Pcode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete From Products Where ProductCode = @pcode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pcode", Pcode);
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Insert(string Name, int Snumber, string Edate, int Price, int Pcount, int CompCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Insert Into Products (ProductName,SerialNumber,ExpirationDate,ProductPrice,ProductCount,CompanyCode) values (@name,@snumber,@edate,@price,@pcount,@compcode)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@snumber", Snumber);
                cmd.Parameters.AddWithValue("@edate", Edate);
                cmd.Parameters.AddWithValue("@price", Price);
                cmd.Parameters.AddWithValue("@pcount", Pcount);
                cmd.Parameters.AddWithValue("@compcode", CompCode);
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool Update(int Pcode, string Name, int Snumber, string Edate, int Price, int Pcount, int CompCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Update Products Set ProductName=@name,SerialNumber=@snumber,ExpirationDate=@edate,ProductPrice=@price,ProductCount=@pcount,CompanyCode=@compcode Where ProductCode=@pcode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pcode", Pcode);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@snumber", Snumber);
                cmd.Parameters.AddWithValue("@edate", Edate);
                cmd.Parameters.AddWithValue("@price", Price);
                cmd.Parameters.AddWithValue("@pcount", Pcount);
                cmd.Parameters.AddWithValue("@compcode", CompCode);
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    public DataTable Search(string Parameter)
        {
            string query = "Select * From Products Where ProductName like @parameter";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + Parameter + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From Products";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int Pcode)
        {
            string query = "Select * From Products Where ProductCode = " + Pcode;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
