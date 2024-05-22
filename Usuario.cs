using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cap_entidades;
using Cap_negocio;
using Cap_datos;

namespace Validacion_usuarios

{
    public partial class Usuario : Form
    {

        E_user objeuser = new E_user();
        N_user objnuser = new N_user();
        Cliente registro = new Cliente();

        public static string Nombre;
        public static string Contrasena;

        public void SP_inicio()
        {
            DataTable dt = new DataTable();
            objeuser.Usuario= txt_usuario.Text;
            objeuser.Contraseña = txt_contraseña.Text;
            dt = objnuser.N_users(objeuser);
            if (dt.Rows.Count > 0 )
            {
     
                    MessageBox.Show("Los datos han sido correctamente ingresados." + "Bienvenido" + dt.Rows[0][0].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Nombre = dt.Rows[0][2].ToString();
                    Contrasena = dt.Rows[0][3].ToString();

                    registro.ShowDialog();
                    Usuario login = new Usuario();
                   login.ShowDialog();
                 if (login.DialogResult == DialogResult.OK)
                     Application.Run(new Cliente());

                 txt_usuario.Clear();
                txt_contraseña.Clear();


                  

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos " , "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }


        public Usuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_iniciar_secion_Click_1(object sender, EventArgs e)
        {

            SP_inicio();
        }

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

 