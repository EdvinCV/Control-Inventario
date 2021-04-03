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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
            tabPage1.Parent = null;
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            tabPage4.Parent = null;
            tabPage5.Parent = null;
            tabPage6.Parent = null;
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

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

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de ingresar?", "Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (textBox5.Text == "" | textBox6.Text == "" | textBox7.Text == "" | textBox8.Text == "" | textBox9.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                {
                    ClassColores Logica = new ClassColores();
                    string resultado = Logica.NuevoCliente(textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
                    MessageBox.Show(resultado);
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    MostrarDatos();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de modificar?", "Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if(textBox3.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                { 
                    ClassColores Logica = new ClassColores();
                    MODELS.Categoria claseCategoria = new MODELS.Categoria();

                    int codigo = 0;
                    claseCategoria.CategoriaId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    claseCategoria.Nombre = textBox3.Text;
                    string resp = Logica.ActualizarCategoria(claseCategoria);
                    MessageBox.Show(resp);
                    MostrarDatos();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
                    MODELS.Marca claseMarca = new MODELS.Marca();

                    claseMarca.MarcaId = Convert.ToInt32(this.dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    claseMarca.NombreMarca = textBox4.Text;
                    string resp = Logica.ActualizarMarca(claseMarca);
                    MessageBox.Show(resp);
                    MostrarDatos();
                }
            }
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        void MostrarDatos()
        {
            ClassColores Datos = new ClassColores();
            this.dataGridView1.DataSource = Datos.MostrarCategoria();
            this.dataGridView1.Refresh();

            Datos = new ClassColores();
            this.dataGridView2.DataSource = Datos.MostrarMarca();
            this.dataGridView2.Refresh();

            Datos = new ClassColores();
            this.dataGridView3.DataSource = Datos.MostrarCliente();
            this.dataGridView3.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de modificar?", "Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (textBox10.Text == "" | textBox11.Text == "" | textBox12.Text == "" | textBox13.Text == "" | textBox14.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                {
                    ClassColores Logica = new ClassColores();
                    MODELS.Cliente claseCliente = new MODELS.Cliente();

                    
                    claseCliente.ClienteId = Convert.ToInt32(this.dataGridView3.CurrentRow.Cells[0].Value.ToString()); ;
                    claseCliente.Nombre = textBox10.Text;
                    claseCliente.Apellido = textBox11.Text;
                    claseCliente.NIT = textBox12.Text;
                    claseCliente.DPI = textBox13.Text;
                    claseCliente.Telefono = textBox14.Text;
                    string resp = Logica.ActualizarCliente(claseCliente);
                    MessageBox.Show(resp);
                    MostrarDatos();
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";

                }

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox11.Text = this.dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox12.Text = this.dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox13.Text = this.dataGridView3.CurrentRow.Cells[4].Value.ToString();
            textBox14.Text = this.dataGridView3.CurrentRow.Cells[5].Value.ToString();

        }
    }
}
