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
    public partial class InfProductos : Form
    {
        public InfProductos()
        {
            InitializeComponent();
        }

        private void MostrarDatos()
        {
            BLL.ClassColores datos = new ClassColores();

            this.dataGridView1.DataSource = datos.MostrarCategoria();
            this.dataGridView1.Refresh();

            datos = new ClassColores();
            this.dataGridView2.DataSource = datos.MostrarMedida();
            this.dataGridView2.Refresh();

            datos = new ClassColores();
            this.dataGridView3.DataSource = datos.MostrarMarca();
            this.dataGridView3.Refresh();

            datos = new ClassColores();
            this.comboBox1.DataSource = datos.MostrarCategoria();
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.ValueMember = "Codigo_Categoria";
            this.comboBox1.Refresh();

            datos = new ClassColores();
            this.comboBox2.DataSource = datos.MostrarMedida();
            this.comboBox2.DisplayMember = "Medida";
            this.comboBox2.ValueMember = "Codigo_Medida";
            this.comboBox2.Refresh();

            datos = new ClassColores();
            this.comboBox3.DataSource = datos.MostrarMarca();
            this.comboBox3.DisplayMember = "NombreMarca";
            this.comboBox3.ValueMember = "Codigo_Marca";
            this.comboBox3.Refresh();

            datos = new ClassColores();
            this.dataGridView4.DataSource = datos.MostrarTipo();
            this.dataGridView4.Refresh();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnIngresarCat.Visible = false;
            btnModCat.Visible = true;
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
                    textBox1.Text = "";
                    MostrarDatos();
                }
            }
        }

        private void btnModCat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de modificar?", "Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                {
                    ClassColores Logica = new ClassColores();
                    MODELS.Categoria claseCategoria = new MODELS.Categoria();

                    int codigo = 0;
                    claseCategoria.CategoriaId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    claseCategoria.Nombre = textBox1.Text;
                    string resp = Logica.ActualizarCategoria(claseCategoria);
                    MessageBox.Show(resp);
                    textBox1.Text = "";
                    MostrarDatos();
                    btnModCat.Visible = false;
                    btnIngresarCat.Visible = true;
                }
            }
        }

        private void InfProductos_Load(object sender, EventArgs e)
        {
            btnModCat.Visible = false;
            btnModMed.Visible = false;
            btnModMar.Visible = false;
            button2.Visible = false;
            MostrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    string resultado = Logica.NuevaMedida(textBox2.Text);
                    MessageBox.Show(resultado);
                    textBox2.Text = "";
                    MostrarDatos();
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnIngresarMed.Visible = false;
            btnModMed.Visible = true;
            textBox2.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnModMed_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de modificar?", "Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                {
                    ClassColores Logica = new ClassColores();
                    MODELS.Medida claseMedida = new MODELS.Medida();

                    int codigo = 0;
                    claseMedida.MedidaId = Convert.ToInt32(this.dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    claseMedida.NombreMedida = textBox2.Text;
                    string resp = Logica.ActualizarMedida(claseMedida);
                    MessageBox.Show(resp);
                    textBox2.Text = "";
                    MostrarDatos();
                    btnModMed.Visible = false;
                    btnIngresarMed.Visible = true;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de ingresar?", "Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                {
                    ClassColores Logica = new ClassColores();
                    string resultado = Logica.NuevaMarca(textBox3.Text);
                    MessageBox.Show(resultado);
                    textBox3.Text = "";
                    MostrarDatos();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de modificar?", "Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion correctamente");
                }
                else
                {
                    ClassColores Logica = new ClassColores();
                    MODELS.Marca claseMarca = new MODELS.Marca();

                    claseMarca.MarcaId = Convert.ToInt32(this.dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    claseMarca.NombreMarca = textBox3.Text;
                    string resp = Logica.ActualizarMarca(claseMarca);
                    textBox3.Text = "";
                    MessageBox.Show(resp);
                    MostrarDatos();
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
            btnIngresarMar.Visible = false;
            btnModMar.Visible = true;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de ingresar?", "Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                BLL.ClassColores tipo = new ClassColores();
                tipo.NuevoTipoProducto(textBox4.Text, Convert.ToInt32(textBox5.Text), textBox6.Text, Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue));
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                MostrarDatos();

            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = this.dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = this.dataGridView4.CurrentRow.Cells[3].Value.ToString();
            button1.Visible = false;
            button2.Visible = true;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de modificar?", "Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ClassColores Logica = new ClassColores();
                MODELS.TipoProducto claseTipo = new MODELS.TipoProducto();

                claseTipo.TipoProductoId = Convert.ToInt32(this.dataGridView4.CurrentRow.Cells[0].Value.ToString());
                claseTipo.Nombre = textBox4.Text;
                claseTipo.Color = textBox6.Text;
                claseTipo.Precio = Convert.ToInt32(textBox5.Text);
                claseTipo.CategoriaId = Convert.ToInt32(comboBox1.SelectedValue);
                claseTipo.MedidaId = Convert.ToInt32(comboBox2.SelectedValue);
                claseTipo.MarcaId = Convert.ToInt32(comboBox3.SelectedValue);
                string resp = Logica.ActualizarTipo(claseTipo);
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                button1.Visible = true;
                MessageBox.Show(resp);
                MostrarDatos();

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
