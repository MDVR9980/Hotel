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
    public partial class ProductsForm : Form
    {
        IMarketingRepository marketingRepository;
        public ProductsForm()
        {
            InitializeComponent();
            marketingRepository = new MarketingRepository();
        }
        private void ProductsForm_Load(object sender, EventArgs e)
        {
            dgProducts.AutoGenerateColumns = false;
            dgProducts.DataSource = marketingRepository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgProducts.AutoGenerateColumns = false;
            dgProducts.DataSource = marketingRepository.SelectAll();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dgProducts.AutoGenerateColumns = false;
                dgProducts.DataSource = marketingRepository.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgProducts.CurrentRow != null)
            {
                string ProductName = dgProducts.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show($"آیا از حذف {ProductName} کالا مطمئن هستید؟ ", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int Pcode = int.Parse(dgProducts.CurrentRow.Cells[0].Value.ToString());
                    marketingRepository.Delete(Pcode);
                    dgProducts.AutoGenerateColumns = false;
                    dgProducts.DataSource = marketingRepository.SelectAll();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgProducts.CurrentRow != null)
            {
                int Pcode = int.Parse(dgProducts.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEdit frm = new frmAddOrEdit();
                frm.Pcode = Pcode;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgProducts.AutoGenerateColumns = false;
                    dgProducts.DataSource = marketingRepository.SelectAll();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgProducts.DataSource = marketingRepository.Search(txtSearch.Text);
        }
    }
}
