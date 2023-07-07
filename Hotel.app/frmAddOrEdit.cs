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
    public partial class frmAddOrEdit : Form
    {
        IHotelRepository hotelRepository;
        public int Ucode = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
            hotelRepository = new HotelRepository();
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if(Ucode == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                DataTable dt = hotelRepository.SelectRow(Ucode);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtTel.Text = dt.Rows[0][3].ToString();
                txtMobile.Text = dt.Rows[0][4].ToString();
                txtAddress.Text = dt.Rows[0][5].ToString();
                btnSubmit.Text = "ویرایش";
            }
        }
        bool ValidateInput()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTel.Text == "")
            {
                MessageBox.Show("لطفا آیدی تلگرام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا شماره تلفن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                bool isSucccess;
                if(Ucode == 0)
                {
                    isSucccess = hotelRepository.Insert(txtName.Text, txtFamily.Text, txtTel.Text, txtMobile.Text, txtAddress.Text);
                }
                else
                {
                    isSucccess = hotelRepository.Update(Ucode, txtName.Text, txtFamily.Text, txtTel.Text, txtMobile.Text, txtAddress.Text);
                }
                if(isSucccess == true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
