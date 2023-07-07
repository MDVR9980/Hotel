using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.app.Repository
{
    internal interface IMarketingRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int Pcode);
        DataTable Search(string Parameter);
        bool Insert(string Name, int Snumber, string Edate, int Price, int Pcount, int CompCode);
        bool Update(int Pcode, string Name, int Snumber, string Edate, int Price, int Pcount, int CompCode);
        bool Delete(int Pcode);
    }
}
