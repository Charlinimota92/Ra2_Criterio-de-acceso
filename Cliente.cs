using Cap_entidades;
using Cap_negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validacion_usuarios
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        #region "Variables"
        int esta_guardada = 0;
        int n_codigo = 0;
        #endregion
        #region "Mis metodos"


        private void principal_Load(object sender, EventArgs e)
        {
            this.Listar_Cliente("%");
            dgv_principal.Enabled = true;
        }

        private void btn_SALIR_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Desea salir de la aplicacion?", "Aviso del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(opcion== DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            esta_guardada = 2;
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_email.Text = "";
            txt_usuario.Text = "";
            txt_contraseña.Text = "";

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if(txt_nombre.Text== string.Empty||
                txt_apellido.Text== string.Empty ||
                txt_email.Text== string.Empty||
                    txt_usuario.Text== string.Empty||
                    txt_contraseña.Text== string.Empty)
            {
                MessageBox.Show("Este campo no puede estar vacio", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string respuesta = " ";
                E_cliente cliente = new E_cliente();
                cliente.Id_cliente = n_codigo;
                cliente.Nombre = txt_nombre.Text.Trim();
                cliente.Apellido = txt_apellido.Text.Trim();
                cliente.Email = txt_email.Text.Trim();
                cliente.Usuario = txt_usuario.Text.Trim();
                cliente.Contraseña = txt_contraseña.Text.Trim();
                respuesta = N_cliente.Guardar_Cliente(esta_guardada, cliente);

                if(respuesta == "Ok")
                {
                    MessageBox.Show("Datos guardados correctamente.", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Listar_Cliente("%");
                    esta_guardada = 0;
                    n_codigo = 0;
                    txt_nombre.Text = "";
                    txt_apellido.Text = "";
                    txt_email.Text = "";
                    txt_usuario.Text = "";
                    txt_contraseña.Text = "";
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

       
        private void Listar_Cliente(string valor)
        {
            try 
            {
                dgv_principal.DataSource = N_cliente.Listar_Cliente(valor);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            esta_guardada = 1;
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_email.Text = "";
            txt_usuario.Text = "";
            txt_contraseña.Text = "";

        }

        private void dgv_principal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n_codigo = Convert.ToInt32(dgv_principal.CurrentRow.Cells[0].Value);
            txt_nombre.Text= dgv_principal.CurrentRow.Cells[1].Value.ToString();
            txt_apellido.Text = dgv_principal.CurrentRow.Cells[2].Value.ToString();
            txt_email.Text = dgv_principal.CurrentRow.Cells[3].Value.ToString();
            txt_usuario.Text = dgv_principal.CurrentRow.Cells[4].Value.ToString();
            txt_contraseña.Text = dgv_principal.CurrentRow.Cells[5].Value.ToString();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea eliminar el registro?", "Aviso del sistema",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                string respuesta = "";
                respuesta = N_cliente.SP_ELIMINAR_Cliente(n_codigo);
                if (respuesta.Equals("Ok"))
                {
                    this.Listar_Cliente("%");
                    //this.Estado(false);
                    //esta_guardada = 0;
                    n_codigo = 0;
                    txt_nombre.Text = "";
                    txt_apellido.Text = "";
                    txt_email.Text = "";
                    txt_usuario.Text = "";
                    txt_contraseña.Text = "";
                    MessageBox.Show("Registro eliminado", "Aviso del sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso del sistema", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

        }
    }
}
#endregion