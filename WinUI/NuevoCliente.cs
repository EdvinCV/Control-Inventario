using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace WinUI
{
    public partial class NuevoCliente : Form
    {
        public NuevoCliente()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de ingresar?", "Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ClassColores Logica = new ClassColores();
                string resultado = Logica.NuevoCliente(textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
                MessageBox.Show(resultado);
                this.Close();
            }
            
        }
    }
}
