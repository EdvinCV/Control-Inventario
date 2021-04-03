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
    public partial class FormFactura : Form
    {
        public FormFactura(int codFactura)
        {
            InitializeComponent();
            CrystalReport1 factura = new CrystalReport1();
            factura.SetParameterValue("@factura", codFactura);
            crystalReportViewer1.ReportSource = factura;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {

        }
    }
}
