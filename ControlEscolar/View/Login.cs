using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlEscolar.Bussines;
using NLog;
using ControlEscolarCore.Utilities;


namespace ControlEscolar.View
{
    public partial class Login : Form
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.View.frmLogin");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            _logger.Info("Usuario accedio ha  inicio sesion");
            _logger.Info("Espacio en disco bajo");
            try
            {
                //aqui provocamos una primera excepcion 
                try
                {
                    int divisor = 0;
                    int resultado = 10 / divisor; //esto va a generar una divide


                }
                catch (DivideByZeroException ex)
                {
                    //capturamos la primera excepcion y la devolvemos en otra
                    throw new ApplicationException("Error al realizar el calculo en la aplicacion", ex);
                    throw;
                }
            }
            catch (Exception ex)
            {
                //aqui se puede manejar la excepcion que contiene inner exception
                _logger.Error(ex, "Se produjo un error en la operación");

                // 0 registrar especificamente 
                if (ex.InnerException != null)
                {
                    _logger.Fatal(ex, $"Error critico con detalle interno: {ex.InnerException.Message}");
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El campo de usuario no puede estar vacio.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacio.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!UsuarioNegocio.EsFormatoValido(txtUsuario.Text))
            {
                MessageBox.Show("El nombre del usuario no tiene el formato correcto", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // MessageBox.Show("Listo para iniciar sesion", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Estamos listos para inicar sesion 
            //this.Hide();
            //MDI_Cotrol_escolar mdi = new MDI_Cotrol_escolar();
            //mdi.Show();

           this.DialogResult = DialogResult.OK;
           this.Close();
            
        }
    }
}
