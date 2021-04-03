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
    public partial class FormVenta : Form
    {
        int empl;
        int codigoCliente = 0;
        string cliente;
        int totalPagar = 0;
        protected StringBuilder FacturaXML = new StringBuilder();
        public FormVenta(string codCliente, int codEmpleado)
        {
            InitializeComponent();
            cliente = codCliente;
            empl = codEmpleado;
            codigoCliente = Convert.ToInt32(codCliente);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label14.Text = Convert.ToString(totalPagar);
            for (int a = 0; a < Convert.ToInt32(textBox1.Text); a++)
            {
                BLL.ClassColores productos = new BLL.ClassColores();
                
                ClassColores Logica = new ClassColores();
                MODELS.Producto claseProd = new MODELS.Producto();

               claseProd.ProductoId = Convert.ToInt32(this.dataGridView1.Rows[0].Cells[0].Value.ToString());
               claseProd.Estado = false;
               string resp = Logica.BorrarProducto(claseProd);
               this.dataGridView1.Refresh();

                FacturaXML.Append("<Detalle>");
                FacturaXML.Append("<Producto>");
                FacturaXML.Append(this.dataGridView1.Rows[0].Cells[0].Value.ToString());
                FacturaXML.Append("</Producto>");
                FacturaXML.Append("<Cantidad>");
                FacturaXML.Append(1);
                FacturaXML.Append("</Cantidad>");
                FacturaXML.Append("<Precio>");
                FacturaXML.Append("</Precio>");
                FacturaXML.Append("<Descuento>");
                FacturaXML.Append("</Descuento>");
                FacturaXML.Append("<Subtotal>");
                FacturaXML.Append("</Subtotal>");
                FacturaXML.Append("</Detalle>");
                
            }
            listBox1.Items.Add("");
            listBox1.Refresh();
        }

        private void FormVenta_Load(object sender, EventArgs e)
        {
            BLL.ClassColores productos = new BLL.ClassColores();
            textBox1.Text = "0";


            productos = new ClassColores();
            this.dataGridView3.DataSource = productos.MostrarClienteNIT(cliente);
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Text = this.dataGridView3.Rows[0].Cells[1].Value.ToString();
            textBox5.Text = this.dataGridView3.Rows[0].Cells[5].Value.ToString();
            textBox6.Text = Convert.ToString(empl);
            textBox7.Text = Convert.ToString(DateTime.Now);
            productos = new ClassColores();
            this.dataGridView1.DataSource = productos.MostrarIdCliente(textBox5.Text);
            textBox3.Text = (this.dataGridView1.Rows[0].Cells[0].Value.ToString());
            


            //XML
            if (FacturaXML.Length <= 0)
            { 
                FacturaXML.Append("<Factura>");
                FacturaXML.Append("<Encabezado>");
                FacturaXML.Append("<Cliente>");
                FacturaXML.Append(Convert.ToInt32(textBox3.Text));
                FacturaXML.Append("</Cliente>");
                FacturaXML.Append("<Usuario>");
                FacturaXML.Append(Convert.ToInt32(textBox6.Text));
                FacturaXML.Append("</Usuario>");
                FacturaXML.Append("<Pago>");
                FacturaXML.Append("</Pago>");
                FacturaXML.Append("<Fecha>");
                FacturaXML.Append(textBox7.Text);
                FacturaXML.Append("</Fecha>");
                FacturaXML.Append("</Encabezado>");
                FacturaXML.Append("<Cuerpo>");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BLL.ClassColores datos = new BLL.ClassColores();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FacturaXML.Append("</Cuerpo>");
            FacturaXML.Append("</Factura>");
            string final = FacturaXML.ToString();
            MessageBox.Show(final);
            Pago p = new Pago(FacturaXML,totalPagar,Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox6.Text));
            p.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FacturaXML.Clear();
            listBox1.Items.Clear();
            if (FacturaXML.Length <= 0)
            {
                FacturaXML.Append("<Factura>");
                FacturaXML.Append("<Encabezado>");
                FacturaXML.Append("<Cliente>");
                FacturaXML.Append(Convert.ToInt32(textBox3.Text));
                FacturaXML.Append("</Cliente>");
                FacturaXML.Append("<Usuario>");
                FacturaXML.Append(Convert.ToInt32(textBox6.Text));
                FacturaXML.Append("</Usuario>");
                FacturaXML.Append("<Pago>");
                FacturaXML.Append("</Pago>");
                FacturaXML.Append("<Fecha>");
                FacturaXML.Append(textBox7.Text);
                FacturaXML.Append("</Fecha>");
                FacturaXML.Append("</Encabezado>");
                FacturaXML.Append("<Cuerpo>");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BLL.ClassColores existencia = new ClassColores();
            if (existencia.ExisteProd(Convert.ToInt32(textBox2.Text)) == true)
            {
                ///
                BLL.ClassColores prod = new ClassColores();
                this.dataGridView4.DataSource = prod.MostrarProductoE(Convert.ToInt32(textBox2.Text));
                this.dataGridView4.Refresh();

                if (dataGridView1.Rows.Count > 0)
                {
                    FacturaXML.Append("<Detalle>");
                    FacturaXML.Append("<Producto>");
                    FacturaXML.Append(Convert.ToInt32(this.dataGridView4.Rows[0].Cells[0].Value.ToString()));
                    FacturaXML.Append("</Producto>");
                    FacturaXML.Append("<Cantidad>");
                    FacturaXML.Append(1);
                    FacturaXML.Append("</Cantidad>");
                    FacturaXML.Append("<Precio>");
                    FacturaXML.Append(Convert.ToInt32(this.dataGridView4.Rows[0].Cells[2].Value.ToString()));
                    FacturaXML.Append("</Precio>");
                    FacturaXML.Append("<Descuento>");
                    FacturaXML.Append(Convert.ToInt32(textBox1.Text));
                    FacturaXML.Append("</Descuento>");
                    FacturaXML.Append("<Subtotal>");
                    FacturaXML.Append(this.dataGridView4.Rows[0].Cells[2].Value.ToString());
                    FacturaXML.Append("</Subtotal>");
                    FacturaXML.Append("</Detalle>");
                    totalPagar += Convert.ToInt32(this.dataGridView4.Rows[0].Cells[2].Value.ToString());
                    label14.Text = Convert.ToString(totalPagar);

                    listBox1.Items.Add(this.dataGridView4.Rows[0].Cells[0].Value.ToString() + " - " + this.dataGridView4.Rows[0].Cells[1].Value.ToString() + "-" + this.dataGridView4.Rows[0].Cells[3].Value.ToString() + "-" + this.dataGridView4.Rows[0].Cells[4].Value.ToString() + "-" + this.dataGridView4.Rows[0].Cells[5].Value.ToString());
                    textBox2.Text = "";

                    //Actualizar y eliminar producto
                    ClassColores Logica = new ClassColores();
                    MODELS.Producto claseProd = new MODELS.Producto();
                    claseProd.ProductoId = Convert.ToInt32(this.dataGridView4.Rows[0].Cells[0].Value);
                    claseProd.Estado = false;
                    claseProd.TipoProductoId = Convert.ToInt32(this.dataGridView4.Rows[0].Cells[6].Value);
                    string resp = Logica.ActualizarProd(claseProd);
                    MessageBox.Show(resp);
                }
                else
                {
                    MessageBox.Show("El producto no existe");
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("El producto no existe");
                textBox2.Text = "";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string m = FacturaXML.ToString();
            MessageBox.Show(m);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
