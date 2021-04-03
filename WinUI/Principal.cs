using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using InputKey;
using BLL;

namespace WinUI
{
    public partial class Principal : Form
    {
        const int WM_SYSCOMMAND = 0x112;
        const int MOUSE_MOVE = 0xF012;
        int usercode = 0;

        // Declaraciones del API 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        // 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        // 
        // función privada usada para mover el formulario actual 
        public Principal(int cod)
        {
            InitializeComponent();
            usercode = cod;
          
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Principal_MouseDown(object sender, MouseEventArgs e)
        {
 

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Principal_MouseMove);

        }

        private void mover()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);

        }

        private void Principal_MouseMove(object sender, MouseEventArgs e)
        {
            mover();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void InsertarFormHija(object formH)
        {
            if (this.panel4.Controls.Count > 0)
                this.panel4.Controls.RemoveAt(0);
            Form fh = formH as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(fh);
            fh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertarFormHija(new Marcas());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            InsertarFormHija(new Categorias());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertarFormHija(new InfProductos());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertarFormHija(new Productos());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            string nit = InputDialog.mostrar("Introduzca el nit del usuario.");
            BLL.ClassColores ob = new ClassColores();
            bool existe = ob.ExisteNit(nit);
            if(existe == true)
            {
                MessageBox.Show("Usuario existe");
                InsertarFormHija(new FormVenta(nit,usercode)); 
            }
            else if(existe == false)
            {
                MessageBox.Show("Usuario no existe");
                InsertarFormHija(new NuevoCliente());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.Show();
        }
    }
}
