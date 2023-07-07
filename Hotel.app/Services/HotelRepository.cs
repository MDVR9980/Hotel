using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hotel.app
{
    internal class HotelRepository : IHotelRepository
    {
        private string connectionString = "data Source=.;Initial Catalog=Hotel;Integrated Security=true";
        public bool Delete(int Ucode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete From Users Where UserCode = @ucode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ucode", Ucode);
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

        public bool Insert(string Fname, string Lname, string Tel, string Mobile, string Address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Insert Into Users (UserName,UserLname,UserTel,UserMobile,UserAddress) values (@fname,@lname,@tel,@mobile,@address)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@fname", Fname);
                cmd.Parameters.AddWithValue("@lname", Lname);
                cmd.Parameters.AddWithValue("@tel", Tel);
                cmd.Parameters.AddWithValue("@mobile", Mobile);
                cmd.Parameters.AddWithValue("@address", Address);
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
            string query = "Select * From Users Where UserName like @parameter or UserLname like @parameter";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + Parameter + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From Users";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int Ucode)
        {
            string query = "Select * From Users Where UserCode = " + Ucode;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int Ucode, string Fname, string Lname, string Tel, string Mobile, string Address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Update Users Set UserName=@fname,UserLname=@lname,UserTel=@tel,UserMobile=@mobile,UserAddress=@address Where UserCode=@ucode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ucode", Ucode);
                cmd.Parameters.AddWithValue("@fname", Fname);
                cmd.Parameters.AddWithValue("@lname", Lname);
                cmd.Parameters.AddWithValue("@tel", Tel);
                cmd.Parameters.AddWithValue("@mobile", Mobile);
                cmd.Parameters.AddWithValue("@address", Address);
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
    }
}
