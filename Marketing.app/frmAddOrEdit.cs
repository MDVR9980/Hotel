using Marketing.app.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.app
{
    public partial class frmAddOrEdit : Form
    {
        IMarketingRepository marketingRepository;
        public int Pcode = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
            marketingRepository = new MarketingRepository();
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (Pcode == 0)
            {
                this.Text = "افزودن کالای جدید";
            }
            else
            {
                this.Text = "ویرایش کالا";
                DataTable dt = marketingRepository.SelectRow(Pcode);
                txtName.Text = dt.Rows[0][1].ToString();
                txtSnumber.Text = dt.Rows[0][2].ToString();
                txtEdate.Text = dt.Rows[0][3].ToString();
                txtPrice.Text = dt.Rows[0][4].ToString();
                txtPcount.Text = dt.Rows[0][5].ToString();
                txtComp.Text = dt.Rows[0][6].ToString();
                btnSubmit.Text = "ویرایش";
            }
        }
        bool ValidateInput()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام کالا را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPrice.Text == "")
            {
                MessageBox.Show("لطفا قیمت کالا را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPcount.Text == "")
            {
                MessageBox.Show("لطفا تعداد کالا را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtComp.Text == "")
            {
                MessageBox.Show("لطفا کد شرکت تولید کننده را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                bool isSucccess;
                if (Pcode == 0)
                {
                    isSucccess = marketingRepository.Insert(txtName.Text, Convert.ToInt32(txtSnumber.Text), txtEdate.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtPcount.Text), Convert.ToInt32(txtComp.Text));
                }
                else
                {
                    isSucccess = marketingRepository.Update(Pcode, txtName.Text, Convert.ToInt32(txtSnumber.Text), txtEdate.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtPcount.Text), Convert.ToInt32(txtComp.Text));
                }
                if (isSucccess == true)
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
