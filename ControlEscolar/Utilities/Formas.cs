using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ControlEscolar.Utilities
{
    internal class Formas
    {
        internal static void InicializaForma (Form form_child, Form formparent)
        {
            //propiedades basicas

            form_child.MdiParent = formparent; //asigna el padre MDI
            form_child.FormBorderStyle = FormBorderStyle.Sizable; //permite redimensionar
            form_child.MaximizeBox = true; //permite maximizar
            form_child.MinimizeBox = true; //permite minimizar 
            form_child.WindowState = FormWindowState.Normal; //Estado inicial de la ventana 

            //propiedades de control
            form_child.ControlBox = true; //muestra los botones de control (miniza, maximiza
            form_child.ShowIcon = true;//muestra el icono de la barra de titulo
            form_child.ShowInTaskbar = false; //no muestra la barra de tareas

            //propiedades de tamaño
            form_child.AutoScaleMode = AutoScaleMode.Font; // Modo de escalado 
            form_child.ClientSize = new Size(860, 600); // Tamaño inicial 
            form_child.MinimumSize = new Size(400, 300); // Tamaño minimo permitido 
            form_child.MaximumSize = new Size(3440, 1440); // Tamaño máximo permitido 

            //Propiedades de inicio 
            form_child.StartPosition = FormStartPosition.CenterScreen; // Posición inicial 

            //Propiedades de comportamiento 
            form_child.AutoScroll = true; // Permitir scroll si el contenido es mayor que la ventana 
            form_child.KeyPreview = true; // Permitir que el formulario reciba eventos de teclado
        }
    }
}
