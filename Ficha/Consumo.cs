using MeuProjeto;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Ficha
{
    public partial class Consumo : Form
    {
        private Class1 minhaInstancia;
        private MySqlCommand command; // Declaração da variável command

        public Consumo()
        {
            InitializeComponent();
            minhaInstancia = new Class1();
        }

        private void Consumo_Load(object sender, EventArgs e)
        {
            CarregarDadosPorFicha();  
        }

        private void  CarregarDadosPorFicha()
        {
            try
            {
                minhaInstancia.AbrirConexao();
                string query = @"SELECT rm.Ficha, GROUP_CONCAT(rm.CodRef) AS CodRef, GROUP_CONCAT(rm.Obs) AS Obs, GROUP_CONCAT(e.Estilista) AS Estilista, GROUP_CONCAT(e.Colecao) AS Colecao, GROUP_CONCAT(e.Tecido) AS Tecido, GROUP_CONCAT(c.Obs) AS ObsCos
            FROM refmodelista rm
            JOIN estilista1 e ON rm.Ficha = e.Ficha
            JOIN costura c ON rm.Ficha = c.Ficha
            GROUP BY rm.Ficha";

                command = new MySqlCommand(query, minhaInstancia.Conn); // Atribuição da variável command

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);

                // Define o DataTable como a fonte de dados do DataGridView
                dataGridView1.DataSource = dataTable;

                // Consulta para obter os valores da coluna Ficha
                string queryFicha = "SELECT Ficha FROM refmodelista";
                MySqlCommand commandFicha = new MySqlCommand(queryFicha, minhaInstancia.Conn);

                MySqlDataAdapter adapterFicha = new MySqlDataAdapter(commandFicha);
                System.Data.DataTable dataTableFicha = new System.Data.DataTable();
                adapterFicha.Fill(dataTableFicha);

                // Limpa os itens existentes no ComboBox comboFichas
                comboFichas.Items.Clear();

                // Adiciona os valores da coluna Ficha ao ComboBox comboFichas
                foreach (DataRow row in dataTableFicha.Rows)
                {
                    string ficha = row["Ficha"].ToString();
                    comboFichas.Items.Add(ficha);
                }

                minhaInstancia.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do banco: " + ex.Message);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Verifica se uma célula válida foi clicada
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string valor = cell.Value.ToString();

                // Atribui o valor ao Text do Label
                label3.Text = valor;

                // Define a visibilidade dos controles
                label3.Visible = true;
                label4.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                button1.Visible = true;

                string valorClicado = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string nomeColuna = dataGridView1.Columns[e.ColumnIndex].HeaderText;

                // Consulta os dados do banco de dados com base no valor e na coluna clicados
                string query = $"SELECT * FROM refmodelista WHERE {nomeColuna} = @Ficha";
                command = new MySqlCommand(query, minhaInstancia.Conn);
                command.Parameters.AddWithValue("@Ficha", valorClicado);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);

                // Verifica se algum resultado foi retornado
                if (dataTable.Rows.Count > 0)
                {
                    // Aqui você pode acessar os dados retornados e fazer o que desejar
                    string valorRetornado = dataTable.Rows[0]["Ficha"].ToString();
                    // Atribua o valor retornado a um label ou qualquer outro controle
                }
            }
        }

        private void comboFichas_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;

            string valorSelecionado = comboFichas.SelectedItem.ToString();
            label4.Text = valorSelecionado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                // Obter os valores do label4 e textBox1
                string ficha = label4.Text;
                string consumo = textBox1.Text;

                // Executar a consulta SQL para inserir os valores na tabela consumo
                try
                {
                    minhaInstancia.AbrirConexao();

                    string query = "INSERT INTO consumo (ficha, consumo) VALUES (@Ficha, @Consumo)";
                    command = new MySqlCommand(query, minhaInstancia.Conn);
                    command.Parameters.AddWithValue("@Ficha", ficha);
                    command.Parameters.AddWithValue("@Consumo", consumo);

                    // Executar o comando SQL
                    command.ExecuteNonQuery();

                    minhaInstancia.FecharConexao();

                    // Exibir uma mensagem de sucesso
                    MessageBox.Show("Valores salvos com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar os valores no banco de dados: " + ex.Message);
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();

            menu.Show();
        }
    }
    }

