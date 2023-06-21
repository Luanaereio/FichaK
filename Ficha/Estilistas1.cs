using MeuProjeto;
using System;
using System.Windows.Forms;

namespace Ficha
{
    public partial class Estilistas1 : Form
    {
        private Class1 minhaInstancia;

        public Estilistas1()
        {
            InitializeComponent();
            minhaInstancia = new Class1();
            minhaInstancia.AbrirConexao();
        }

        private void Estilistas1_Load(object sender, EventArgs e)
        {
            comboBoxColecao.Items.Add("Verão");
            comboBoxColecao.Items.Add("Primavera");
            comboBoxColecao.Items.Add("Inverno");
            comboBoxColecao.Items.Add("Outono");

            comBoxFicha.Items.Add("1");
            comBoxFicha.Items.Add("2");
            comBoxFicha.Items.Add("3");
            comBoxFicha.Items.Add("4");
        }
                                         
        private void button1_Click(object sender, EventArgs e)
        {
                string ficha = label1.Text;
                string estilista = textBoxEstilista.Text;
                string colecao = comboBoxColecao.SelectedItem?.ToString();
                string tecido = textBoxTecido.Text;
                string fornecedor = textBoxFornecedor.Text;
                DateTime data = dateTimePickerData.Value;
                string img = textBoxImg.Text;

            minhaInstancia.SalvarDadosE(ficha, estilista, colecao, tecido, fornecedor, data, img);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void comBoxFicha_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                string valorSelecionado = comBoxFicha.SelectedItem.ToString();
                label9.Text = "Ficha selecionada ";
                label1.Visible = true;
                label1.Text = valorSelecionado;

        }

       
        

        private void buttonExibir_Click(object sender, EventArgs e)
        {
        }

        private void textBoxImg_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
