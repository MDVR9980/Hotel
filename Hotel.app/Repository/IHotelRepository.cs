using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.app
{
    internal interface IHotelRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int Ucode);
        DataTable Search(string Parameter);
        bool Insert(string Fname, string Lname, string Tel, string Mobile, string Address);
        bool Update(int Ucode, string Fname, string Lname, string Tel, string Mobile, string Address);
        bool Delete(int Ucode);
    }
}
