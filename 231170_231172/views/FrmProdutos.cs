﻿using _231170_231172;
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
using Vendas.Models;

namespace _231170_231172.views
{
    public partial class FrmProdutos : Form
    {
        Produto p;
        public FrmProdutos()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtCodigo.Clear();
            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtValor.Clear();
            txtEstoque.Clear();
            picFoto.ImageLocation = "";

        }

        void carregarGrid(string pesquisa)
        {
            p = new Produto()
            {
                descricao = pesquisa
            };
            dgvProdutos.DataSource = p.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            {
                if (txtCodigo.Text == "") return;

                p = new Produto()
                {
                    id = int.Parse(txtCodigo.Text),
                    descricao = txtDescricao.Text,
                    valorVenda = double.Parse(txtValor.Text),
                    foto = picFoto.ImageLocation,
                    estoque = double.Parse(txtEstoque.Text)
                    };
                p.Incluir();
                limpaControles();
                carregarGrid("");
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text == "") return;

            p = new Produto()
            {
                id = int.Parse(txtCodigo.Text),
                descricao = txtDescricao.Text,
                idMarca = (char)cboMarca.SelectedValue,
                idCategoria = (char)cboMarca.SelectedValue,
                valorVenda = double.Parse(txtValor.Text),
                estoque = double.Parse(txtEstoque.Text),
                foto = picFoto.ImageLocation,
            };
            p.Alterar();

            limpaControles();
            carregarGrid("");

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "") return;

            if (MessageBox.Show("Deseja excluir o produto?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p = new Produto()
                {
                    id = int.Parse(txtCodigo.Text)
                };
                p.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }
    }


}
