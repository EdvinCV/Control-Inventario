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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            DataTable tabla1 = new DataTable();
            ClassColores log = new ClassColores();
            this.dataGridView1.DataSource = log.MostrarLogin(txtUsuario.Text, txtPassword.Text);
            this.dataGridView1.Refresh();


            log = new ClassColores();
            this.dataGridView2.DataSource = log.MostrarPermisos(Convert.ToInt32(this.dataGridView1.Rows[0].Cells[2].Value));
            this.dataGridView2.Refresh();

            int codigoUsuario = Convert.ToInt32(this.dataGridView1.Rows[0].Cells[3].Value.ToString());

            Administrador d = new Administrador();
            Principal p = new Principal(codigoUsuario);
            p.button1.Visible = false;
            p.button2.Visible = false;
            p.button3.Visible = false;
            p.button6.Visible = false;
            if (dataGridView1.Rows != null)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "1")
                    {
                        p.button1.Visible = true;
                    }
                    else if(dataGridView2.Rows[i].Cells[0].Value.ToString() == "2")
                    {
                        p.button2.Visible = true;
                    }
                    else if(dataGridView2.Rows[i].Cells[0].Value.ToString() == "3")
                    {
                        p.button3.Visible = true;
                    }
                    else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "4")
                    {
                    }
                    else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "5")
                    {
                    }
                    else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "6")
                    {
                        p.button6.Visible = true;
                    }
                    else if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "7")
                    {
                        p.button4.Visible = true;
                    }


                }
                //d.Show();
                p.Show();
            }



        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
