using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.AplicationController;

namespace UI.Desktop.Forms
{
    public partial class ViewActualizarCliente : Form
    {
        private ClienteController ClienteC = new ClienteController();
        public ViewActualizarCliente()
        {
            InitializeComponent();
        }

        private void ViewActualizarCliente_Load(object sender, EventArgs e)
        {

        }
        private void mtd_ActualizarCliente() 
        {
            bool value = ClienteC.ActualizarCliente();
        }
        private void mtd_Cancelar() 
        {
            Application.Exit();
        }
    }
}
