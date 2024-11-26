using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _231170_231172.models
{
    internal class Produto
    {
        
    }

    public void Incluir()
    {
        try
        {
            Banco.Conexao.Open();
            Banco.Comando = new MySqlCommand
                ("INSERT INTO Produto (codigo, descricao, categoria, marca, valor, estoque, foto) " +
                "VALUES (@codigo, @descricao, @categoria, @marca, @valor, @estoque, @foto)", Banco.Conexao);
            Banco.Comando.Parameters.AddWithValue("@codigo", codigo);
            Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
            Banco.Comando.Parameters.AddWithValue("@categoria", categoria);
            Banco.Comando.Parameters.AddWithValue("@marca", marca);
            Banco.Comando.Parameters.AddWithValue("@valor", valor);
            Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
            Banco.Comando.Parameters.AddWithValue("@foto", foto);
            Banco.Comando.ExecuteNonQuery();
            Banco.Conexao.Close();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void Alterar()
    {
        try
        {
            Banco.Conexao.Open();
            Banco.Comando = new MySqlCommand
                ("UPDATE clientes SET codigo = @codigo, descricao = @descricao, categoria = @categoria, " +
                "marca = @marca, valor  = @valor, estoque = @estoque, foto = @foto where id = @id)", Banco.Conexao);
            Banco.Comando.Parameters.AddWithValue("@codigo", codigo);
            Banco.Comando.Parameters.AddWithValue("@descricao", descricao);
            Banco.Comando.Parameters.AddWithValue("@categoria", categoria);
            Banco.Comando.Parameters.AddWithValue("@marca", marca);
            Banco.Comando.Parameters.AddWithValue("@valor", valor);
            Banco.Comando.Parameters.AddWithValue("@estoque", estoque);
            Banco.Comando.Parameters.AddWithValue("@foto", foto);
            Banco.Comando.ExecuteNonQuery();
            Banco.Conexao.Close();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void Excluir()
    {
        try
        {
            Banco.Conexao.Open();
            Banco.Comando = new MySqlCommand("delete from produtos where codigo = @codigo", Banco.Conexao);
            Banco.Comando.Parameters.AddWithValue("@codigo", codigo);
            Banco.Comando.ExecuteNonQuery();
            Banco.Conexao.Close();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public DataTable Consultar()
    {
        try
        {
            Banco.Comando = new MySqlCommand("SELECT p.*, m.marca, c.categoria FROM " +
                "Produtos p inner join Marcas m on (m.id = p.idMarca) " +
                "inner join CAtegorias c on (c.id = p.idCategoria) " +
                "where p.descricao like @descricao order by p.descricao", Banco.Conexao);

            Banco.Comando.Parameters.AddWithValue("@descricao", descricao + "%");
            Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
            Banco.datTabela = new DataTable();
            Banco.Adaptador.Fill(Banco.datTabela);
            return Banco.datTabela;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return null;
        }
    }
}
