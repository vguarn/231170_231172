using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _231170_231172.models;
using Org.BouncyCastle.Asn1.Cmp;

namespace _231170_231172.views
{
    public partial class FrmCidades : Form
    {
        Cidade c;
        public FrmCidades()
        {
            InitializeComponent();
        }

        void LimpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Cidade()
            {
                nome = pesquisa
            };
            dgvCidades.DataSource = c.Consultar();

        }

        private void frmCidades_load(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidades form = new FrmCidades();
            form.Show();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            c = new Cidade()
            {
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Incluir();

            LimpaControles();
            carregarGrid("");
        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {

        }

        private void DgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.Rows.Count > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["Nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["UF"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Cidade()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Alterar();

            LimpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Cidade()
                {
                    id = int.Parse(txtID.Text)
                };
                c.Excluir();

                LimpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaControles();
            carregarGrid("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
