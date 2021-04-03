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
    public partial class Pago : Form
    {
        StringBuilder FacturaXML;
        StringBuilder FacturaCopia;
        int codigoCliente;
        int codigoEmpleado;
        StringBuilder PagoXML = new StringBuilder();
        int met;
        float totalPagar = 0;
        float restante = 0;
        float cant = 0;
        public Pago(StringBuilder xxml, float total, int codC, int codU)
        {
            InitializeComponent();
            FacturaXML = xxml;
            FacturaCopia = xxml;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            totalPagar = total;
            restante = total;
            codigoCliente = codC;
            codigoEmpleado = codU;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de generar factura?", "Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (checkBox2.Checked == true)
                {
                    PagoXML.Append("<Metodo>");
                    PagoXML.Append("<Efectivo>");
                    PagoXML.Append("<Monto>");
                    PagoXML.Append(Convert.ToInt32(textBox1.Text));
                    PagoXML.Append("</Monto>");
                    PagoXML.Append("</Efectivo>");
                    PagoXML.Append("</Metodo>");
                }
                if (checkBox3.Checked == true)
                {
                    PagoXML.Append("<Metodo>");
                    PagoXML.Append("<Tarjeta>");
                    PagoXML.Append("<Num>");
                    PagoXML.Append(Convert.ToInt32(textBox2.Text));
                    PagoXML.Append("</Num>");
                    PagoXML.Append("<Propietario>");
                    PagoXML.Append(textBox3.Text);
                    PagoXML.Append("</Propietario>");
                    PagoXML.Append("<FechaExp>");
                    PagoXML.Append(dateTimePicker1.Value.Date);
                    PagoXML.Append("</FechaExp>");
                    PagoXML.Append("<CVV>");
                    PagoXML.Append(Convert.ToInt32(textBox4.Text));
                    PagoXML.Append("</CVV>");
                    PagoXML.Append("<Monto>");
                    PagoXML.Append(Convert.ToInt32(textBox5.Text));
                    PagoXML.Append("</Monto>");
                    PagoXML.Append("</Tarjeta>");
                    PagoXML.Append("</Metodo>");
                }
                if (checkBox4.Checked == true)
                {
                    PagoXML.Append("<Metodo>");
                    PagoXML.Append("<Cheque>");
                    PagoXML.Append("<Banco>");
                    PagoXML.Append(textBox7.Text);
                    PagoXML.Append("</Banco>");
                    PagoXML.Append("<Monto>");
                    PagoXML.Append(Convert.ToInt32(textBox8.Text));
                    PagoXML.Append("</Monto>");
                    PagoXML.Append("</Cheque>");
                    PagoXML.Append("</Metodo>");
                }

                PagoXML.Append("</Pago>");

                //c2 efectivo
                //c3 tarjeta
                //c4 cheque

                if (checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false)
                    met = 2;
                else if (checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true)
                    met = 1;
                else if (checkBox2.Checked == false && checkBox3.Checked == true && checkBox4.Checked == false)
                    met = 3;
                else if (checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == true)
                    met = 4;
                else if (checkBox2.Checked == false && checkBox3.Checked == true && checkBox4.Checked == true)
                    met = 5;
                else if (checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == false)
                    met = 6;
                else if (checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true)
                    met = 7;



                BLL.ClassColores pago = new BLL.ClassColores();
                string respuesta = pago.CrearP(Convert.ToInt32(totalPagar), PagoXML, met);
                int cod = Convert.ToInt32(respuesta);
                BLL.ClassColores enviar = new BLL.ClassColores();
                string r = enviar.CrearFact(codigoCliente,codigoEmpleado, FacturaXML, cod);

                
                FormFactura fact = new FormFactura(Convert.ToInt32(r));
                fact.Show();

            }
        }

        private void Pago_Load(object sender, EventArgs e)
        {
            label3.Text = Convert.ToString(totalPagar);
            label7.Text = Convert.ToString(totalPagar);
            PagoXML.Append("<Pago>");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CambioEstado();
        }

        private void CambioEstado()
        {
            if(checkBox2.Checked == true)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

            if (checkBox3.Checked == true)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }

            if (checkBox4.Checked == true)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CambioEstado();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CambioEstado();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if(Convert.ToInt32(label7.Text) > 0)
            //{
              //  cant = Convert.ToInt32(textBox1.Text);
               // restante -= cant;
                //label7.Text = Convert.ToString(restante);
            //}
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           // if (Convert.ToInt32(label7.Text) > 0)
          //  {
            //    cant = Convert.ToInt32(textBox5.Text);
              //  restante -= cant;
               // label7.Text = Convert.ToString(restante);
           // }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
         //   if (Convert.ToInt32(label7.Text) > 0)
           // {
             //   cant = Convert.ToInt32(textBox8.Text);
               // restante -= cant;
                //label7.Text = Convert.ToString(restante);
            //}
        }
    }
}
