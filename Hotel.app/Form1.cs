using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.app
{
    public partial class UsersForm : Form
    {
        IHotelRepository hotelRepository;
        public UsersForm()
        {
            InitializeComponent();
            hotelRepository = new HotelRepository();
        }
        
        private void UsersForm_Load(object sender, EventArgs e)
        {
            dgUsers.AutoGenerateColumns = false;
            dgUsers.DataSource = hotelRepository.SelectAll();
        }
      
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgUsers.AutoGenerateColumns = false;
            dgUsers.DataSource = hotelRepository.SelectAll();
        }

        private void btnNewUser_Click_1(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dgUsers.AutoGenerateColumns = false;
                dgUsers.DataSource = hotelRepository.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgUsers.CurrentRow != null)
            {
                string name = dgUsers.CurrentRow.Cells[1].Value.ToString();
                string family = dgUsers.CurrentRow.Cells[2].Value.ToString();
                string fullName = name + " " + family;
                if (MessageBox.Show($"آیا از حذف {fullName} شخص مطمئن هستید؟ ","توجه",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int Ucode = int.Parse(dgUsers.CurrentRow.Cells[0  ].Value.ToString());
                    hotelRepository.Delete(Ucode);
                    dgUsers.AutoGenerateColumns = false;
                    dgUsers.DataSource = hotelRepository.SelectAll();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgUsers.CurrentRow != null)
            {
                int Ucode = int.Parse(dgUsers.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEdit frm = new frmAddOrEdit();
                frm.Ucode = Ucode;
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    dgUsers.AutoGenerateColumns = false;
                    dgUsers.DataSource = hotelRepository.SelectAll();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgUsers.DataSource = hotelRepository.Search(txtSearch.Text);
        }
    }
}
