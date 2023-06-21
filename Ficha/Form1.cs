using System;

using System.Windows.Forms;

namespace Ficha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
                    }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void códigoDeReferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferênciaMod referencia = new ReferênciaMod();

            referencia.Show();
        }

        private void fichasNãoAceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void criaçãoDeFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aviamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void referênciaModelistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridRefA gridRA = new gridRefA();
            
            gridRA.Show();
        }

        private void referenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estilistas1 fichaE = new Estilistas1();

            fichaE.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void costuraEAviamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            costura costuraAdd = new costura();

            costuraAdd.Show();
        }

        private void adicionarConsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consumo consumo = new Consumo();

            consumo.Show();
        }
    }
}
