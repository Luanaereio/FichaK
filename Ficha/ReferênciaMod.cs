using MeuProjeto;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ficha
{
    public partial class ReferênciaMod : Form
    {
        private Class1 minhaInstancia;
        private MySqlCommand command;

        public ReferênciaMod()
        {
            InitializeComponent();
            minhaInstancia = new Class1();
            command = new MySqlCommand();
        }

        private void ReferênciaMod_Load(object sender, EventArgs e)
        {
            minhaInstancia.AbrirConexao();
            CarregarDadosDoBanco();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void CarregarDadosDoBanco()
        {
            try
            {
                minhaInstancia.AbrirConexao();

                // Consulta os dados do banco de dados
                string query = "SELECT * FROM estilista1";
                command = new MySqlCommand(query, minhaInstancia.Conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);

                // Define o DataTable como a fonte de dados do DataGridView
                dataGridView1.DataSource = dataTable;

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
                labelObs.Visible = true;
                labelRef.Visible = true;
                textBoxCod.Visible = true;
                textBoxObs.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label2.Text = "Ficha Selecionada";
                label3.Text = valor;


            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
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
                    string valorRetornado = dataTable.Rows[0]["CodRef"].ToString();
                    // Atribua o valor retornado a um label ou qualquer outro controle
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string ficha = label3.Text;
            string codRef = textBoxCod.Text;
            string obs = textBoxObs.Text;
            string ObsM = textBoxObs.Text;

            minhaInstancia.SalvarDadosM(ficha, codRef, obs,ObsM);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

   
}
