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
    public partial class Marcas : Form
    {
        public Marcas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de ingresar?", "Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                {
                    ClassColores Logica = new ClassColores();
                    string resultado = Logica.NuevaMarca(textBox2.Text);
                    MessageBox.Show(resultado);
                    MostrarDatos();
                }
            }
        }

        void MostrarDatos()
        {
            ClassColores Datos = new ClassColores();
            this.dataGridView2.DataSource = Datos.MostrarMarca();
            this.dataGridView2.Refresh();

            Datos = new ClassColores();
            this.dataGridView1.DataSource = Datos.MostrarMarca();
            this.dataGridView1.Refresh();


        }

        private void Marcas_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
