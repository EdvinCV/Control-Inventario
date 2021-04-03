using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void MostrarDatos()
        {
            BLL.ClassColores tipos = new BLL.ClassColores();
            this.dataGridView1.DataSource = tipos.MostrarTipo();
            this.dataGridView1.Refresh();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label14.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label5.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            label6.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label12.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de ingresar el producto?", "Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int i = Convert.ToInt32(textBox1.Text);
                for(int a = 0; a < i; a++)
                { 
                    BLL.ClassColores prod = new BLL.ClassColores();
                    prod.IngresarProducto(Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                }
                MessageBox.Show("Producto ingresado correctamente");
            }
        }
    }
}
