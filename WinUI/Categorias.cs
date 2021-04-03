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
    public partial class Categorias : Form
    {
        public Categorias()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de ingresar?", "Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                {
                    ClassColores Logica = new ClassColores();
                    string resultado = Logica.NuevaCategoria(textBox1.Text);
                    MessageBox.Show(resultado);
                    MostrarDatos();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de modificar?", "Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                {
                    ClassColores Logica = new ClassColores();
                    MODELS.Categoria claseCategoria = new MODELS.Categoria();

                    int codigo = 0;
                    claseCategoria.CategoriaId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    claseCategoria.Nombre = textBox4.Text;
                    string resp = Logica.ActualizarCategoria(claseCategoria);
                    MessageBox.Show(resp);
                    MostrarDatos();
                }
            }
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            BLL.ClassColores Datos = new BLL.ClassColores();
            this.dataGridView2.DataSource = Datos.MostrarCategoria();
            this.dataGridView2.Refresh();
            Datos = new BLL.ClassColores();
            this.dataGridView1.DataSource = Datos.MostrarCategoria();
            this.dataGridView1.Refresh();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
