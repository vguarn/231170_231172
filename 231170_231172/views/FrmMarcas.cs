using _231170_231172.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _231170_231172.views
{
    public partial class FrmMarcas : Form
    {
        Marca m;
        public FrmMarcas()
        {
            InitializeComponent();
        }
        void LimpaControles()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtPesquisar.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            m = new Marca()
            {
                marca = pesquisa
            };
            dgvMarca.DataSource  = m.Consultar();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }
    
    private void frmMarcas_load(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarcas form = new FrmMarcas();
            form.Show();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;

            m = new Marca()
            {
                marca = txtMarca.Text,
            };
            m.Incluir();

            LimpaControles();
            carregarGrid("");
        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {

        }

        private void DgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarca.Rows.Count > 0)
            {
                txtID.Text = dgvMarca.CurrentRow.Cells["id"].Value.ToString();
                txtMarca.Text = dgvMarca.CurrentRow.Cells["Nome"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            m = new Marca()
            {
                id = int.Parse(txtID.Text),
                marca = txtMarca.Text
            };
            m.Alterar();

            LimpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m = new Marca()
                {
                    id = int.Parse(txtID.Text)
                };
                m.Excluir();

                LimpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }     

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisar.Text);
        }
    }

}

