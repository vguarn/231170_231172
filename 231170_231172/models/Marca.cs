using System;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace _231170_231172.models
{
    
        public class Marca
        {
            public int id { get; set; }

            public string marca { get; set; }

            
            public void Incluir()
            {
                try
                {
                    Banco.AbrirConexao();

                    Banco.Comando = new MySqlCommand("INSERT INTO marcas (marcas) VALUES (@marca)", Banco.Conexao);

                    Banco.Comando.Parameters.AddWithValue("@marca", marca);

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

                    Banco.Comando = new MySqlCommand("Update cidades set marca = @marca where id = @id", Banco.Conexao);

                    Banco.Comando.Parameters.AddWithValue("@marca", marca);
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

                    Banco.Comando = new MySqlCommand("Delete from marcas where id = @id", Banco.Conexao);

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
                        Banco.Comando = new MySqlCommand("SELECT * FROM marcas where marca like @marca " + "order by marca", Banco.Conexao);

                        Banco.Comando.Parameters.AddWithValue("@marca", marca + "%");
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
