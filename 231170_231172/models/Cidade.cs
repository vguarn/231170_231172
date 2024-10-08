using _231170_231172;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;


namespace _231170_231172.models
{
    public class Cidade
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string uf { get; set; }


        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("INSERT INTO cidades (nome, uf) VALUES (@nome, @uf)", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@uf", uf);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
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
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("Update cidades set nome = @nome, uf = @uf where id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@uf", uf);
                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
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
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("Delete from cidades where id = @id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {

            {
                try
                {
                    Banco.AbrirConexao();
                    Banco.Comando = new MySqlCommand("SELECT * FROM Cidades where nome like @Nome " + "order by nome", Banco.Conexao);

                    Banco.Comando.Parameters.AddWithValue("@Nome", nome + "%");
                    Banco.Adaptar = new MySqlDataAdapter(Banco.Comando);
                    Banco.datTabela = new DataTable();
                    Banco.Adaptar.Fill(Banco.datTabela);
                    Banco.FecharConexao();
                    return Banco.datTabela;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}
