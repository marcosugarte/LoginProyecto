using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace LoginProyecto
{
    public partial class Form1 : Form
    {
        MySqlConnection conexion = new MySqlConnection("Server = localhost; Uid = root ; Password = juan316 ; Database = login; Port = 3306" );
        MySqlCommand ejecutar = new MySqlCommand();

        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
           

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            ejecutar.Connection = conexion;

            try
            {
                ejecutar.CommandText = "select count(*) from usuarios where nombre='"+ textBox1.Text +"' and clave ='"+ textBox2.Text+"' ";
                int bandera = int.Parse(ejecutar.ExecuteScalar().ToString());

                if (bandera == 1)
                {
                    label4.Text = "Bienvenido al sistema";
                    Form2 ventana = new Form2();
                    ventana.Show();
                    //this.Hide();
                }
                else
                {
                    label4.Text = "No has podido ingresar al sistema";
                }
            }
            catch (Exception mal)
            {

                label4.Text = " Se ha producido el siguiente error " + mal;
            }
            conexion.Close();                                                                  
        }
    }
}
