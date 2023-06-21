using MeuProjeto;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ficha
{
    public partial class costura : Form
    {
        private Class1 minhaInstancia;
        private MySqlCommand command; // Adicione esta linha

        public costura()
        {
            InitializeComponent();
            minhaInstancia = new Class1();
        }

        private void costura_Load(object sender, EventArgs e)
        {
            CarregarDadosDoBanco();
            dataGridView1.CellClick += dataGridView1_CellClick;

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
                command = minhaInstancia.CriarComando(query);

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nomeColuna = dataGridView1.Columns[e.ColumnIndex].HeaderText;

                if (nomeColuna == "Ficha")
                {
                    string valorClicado = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    labelFS.Visible = true;
                    labelFicha.Visible = true;
                    labelObs.Visible = true;
                    textBoxObs.Visible = true;
                    labelFicha.Text = valorClicado;
                    

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ObsM = textBoxObs.Text;

            string obs = textBoxObs.Text;
            string ficha = labelFicha.Text;

            minhaInstancia.SalvarDadosCos(obs, ficha,ObsM);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
