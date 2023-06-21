using System;
using System.Windows.Forms;
using MeuProjeto;
using MySql.Data.MySqlClient;

namespace Ficha
{
    public partial class gridRefA : Form
    {
        private Class1 minhaInstancia;

        public gridRefA()
        {
            InitializeComponent();
            minhaInstancia = new Class1();
        }

        private void gridRefA_Load(object sender, EventArgs e)
        {
           
            CarregarDadosDoBanco();
        }

        public void CarregarDadosDoBanco()
        {
            try
            {
                minhaInstancia.AbrirConexao();

                // Consulta os dados do banco de dados
                string query = "SELECT r.*, e.Estilista, e.Colecao, e.Tecido, e.Fornecedor, e.Data, e.Img " +
                               "FROM refmodelista r " +
                               "INNER JOIN estilista1 e ON r.Ficha = e.Ficha";
                MySqlCommand command = minhaInstancia.CriarComando(query);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
