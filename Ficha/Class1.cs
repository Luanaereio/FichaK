using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MeuProjeto
{
    public class Class1
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;

        public MySqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

        public string ObsM { get; set; }

        public Class1()
        {
            Conn = conn;

            server = "127.0.0.1";
            database = "Ficha";
            uid = "root";
            password = "";
            string connString = $"Server={server};Database={database};Uid={uid};Pwd={password};";
            conn = new MySqlConnection(connString);
        }

        public void AbrirConexao()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            Console.WriteLine("Conexão aberta com sucesso!");
        }

        public void FecharConexao()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public MySqlCommand CriarComando(string query)
        {
            return new MySqlCommand(query, conn);
        }

        public void SalvarDadosConsumo(string texto)
        {
            try
            {
                AbrirConexao();
                string query = "INSERT INTO consumo (Ficha, Consumo) VALUES (@Ficha, @Consumo)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@Ficha", texto);
                command.ExecuteNonQuery();
                FecharConexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }
        }

        public void SalvarDados(string texto)
        {
            try
            {
                AbrirConexao();
                string query = "INSERT INTO fichamodelagem (codRef) VALUES (@codRef)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@codRef", texto);
                command.ExecuteNonQuery();
                FecharConexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }

            try
            {
                AbrirConexao();
                string query = "INSERT INTO resumo (CodRefM, ObsM) VALUES (@CodRefM, @ObsM)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@CodRefM", texto);
                command.Parameters.AddWithValue("@ObsM", ObsM);

                command.ExecuteNonQuery();
                FecharConexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }
        }


        public void SalvarDadosCos(string obs, string ficha, string ObsM)
        {
            try
            {
                AbrirConexao();
                string query = "INSERT INTO costura (Obs, Ficha) VALUES (@Obs, @Ficha)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@Obs", obs);
                command.Parameters.AddWithValue("@Ficha", ficha);

                command.ExecuteNonQuery();
                FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }

            try
            {
                AbrirConexao();
                string query = "INSERT INTO resumo (ObsM, Ficha) VALUES (@ObsM, @Ficha)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@ObsM", obs);
                command.Parameters.AddWithValue("@Ficha", ficha);

                command.ExecuteNonQuery();
                FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }
        }


        public void SalvarDadosE(string ficha, string estilista, string colecao, string tecido, string fornecedor, DateTime data, string img)
        {
            try
            {
                AbrirConexao();
                string query = "INSERT INTO estilista1 (Ficha, Estilista, Colecao, Tecido, Fornecedor, Data,Img) VALUES (@Ficha,@Estilista, @Colecao, @Tecido, @Fornecedor, @Data, @Img)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@Ficha", ficha);
                command.Parameters.AddWithValue("@Estilista", estilista);
                command.Parameters.AddWithValue("@Colecao", colecao);
                command.Parameters.AddWithValue("@Tecido", tecido);
                command.Parameters.AddWithValue("@Fornecedor", fornecedor);
                command.Parameters.AddWithValue("@Data", data);
                command.Parameters.AddWithValue("@Img", img);

                command.ExecuteNonQuery();
                FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }

            try
            {
                AbrirConexao();
                string query = "INSERT INTO resumo (Ficha, Estilista, Colecao, Tecido, Fornecedor, Data,Img) VALUES (@Ficha,@Estilista, @Colecao, @Tecido, @Fornecedor, @Data, @Img)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@Ficha", ficha);
                command.Parameters.AddWithValue("@Estilista", estilista);
                command.Parameters.AddWithValue("@Colecao", colecao);
                command.Parameters.AddWithValue("@Tecido", tecido);
                command.Parameters.AddWithValue("@Fornecedor", fornecedor);
                command.Parameters.AddWithValue("@Data", data);
                command.Parameters.AddWithValue("@Img", img);

                command.ExecuteNonQuery();
                FecharConexao(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }
        }

        public void SalvarDadosM(string ficha, string codRef, string obs, string ObsM)
        {
            try
            {
                AbrirConexao();
                string query = "INSERT INTO refmodelista (Ficha, CodRef, Obs) VALUES (@Ficha,@CodRef, @Obs)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@Ficha", ficha);
                command.Parameters.AddWithValue("@CodRef", codRef);
                command.Parameters.AddWithValue("@Obs", obs);

                command.ExecuteNonQuery();
                FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }

            try 
            {
                AbrirConexao();
                string query = "INSERT INTO resumo (CodRefM,ObsM,Ficha) VALUES (@CodRefM,@ObsM,@Ficha)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@CodRefM", codRef);
                command.Parameters.AddWithValue("@ObsM", ObsM);
                command.Parameters.AddWithValue("@Ficha", ficha);

                command.ExecuteNonQuery();
                FecharConexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados: " + ex.Message);
            }
        }
    }
}
