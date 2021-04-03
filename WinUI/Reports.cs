using BLL;
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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport2 reporte = new CrystalReport2();
            reporte.SetParameterValue("@fechaInicio",dateTimePicker1.Value.Date);
            reporte.SetParameterValue("@fechaFin", dateTimePicker2.Value.Date);
            crystalReportViewer1.ReportSource = reporte;
            //crystalReportViewer1.ReportSource = reporte;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrystalReport3 reporte = new CrystalReport3();
            reporte.SetParameterValue("@fechaInicio", dateTimePicker4.Value.Date);
            reporte.SetParameterValue("@fechaFin", dateTimePicker3.Value.Date);
            crystalReportViewer2.ReportSource = reporte;
            //crystalReportViewer1.ReportSource = reporte;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CrystalReport4 reporte = new CrystalReport4();
            reporte.SetParameterValue("@fechaInicio", dateTimePicker6.Value.Date);
            reporte.SetParameterValue("@fechaFin", dateTimePicker5.Value.Date);
            crystalReportViewer3.ReportSource = reporte;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CrystalReport5 reporte = new CrystalReport5();
            reporte.SetParameterValue("@numFactura", Convert.ToInt32(textBox1.Text));
            reporte.SetParameterValue("@fact", Convert.ToInt32(textBox1.Text));
            crystalReportViewer4.ReportSource = reporte;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BLL.ClassColores producto = new BLL.ClassColores();
            this.dataGridView1.DataSource = producto.MostrarProductoFactura(Convert.ToInt32(textBox2.Text));
            if(dataGridView1.Rows.Count > 0)
            { 
                MessageBox.Show(Convert.ToString(this.dataGridView1.Rows.Count));
                ActProductos();
                BLL.ClassColores a = new BLL.ClassColores();
                this.dataGridView2.DataSource = a.Factura(Convert.ToInt32(textBox2.Text));
            }
            else
            {
                MessageBox.Show("El número de factura es incorrecto");
            }

        }


        public void ActProductos()
        {
            for(int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                ClassColores Logica = new ClassColores();
                MODELS.Producto claseProducto = new MODELS.Producto();
                claseProducto.ProductoId = Convert.ToInt32(this.dataGridView1.Rows[a].Cells[0].Value.ToString());
                claseProducto.Estado = true;
                claseProducto.TipoProductoId = Convert.ToInt32(this.dataGridView1.Rows[a].Cells[4].Value.ToString());
                string resp = Logica.ActualizarProd(claseProducto);
            }
        }
    }
}
