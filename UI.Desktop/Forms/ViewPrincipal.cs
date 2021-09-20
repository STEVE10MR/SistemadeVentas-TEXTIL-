using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Forms
{
    public partial class ViewPrincipal : Form
    {
        public ViewPrincipal()
        {
            InitializeComponent();
        }

        private void ViewPrincipal_Load(object sender, EventArgs e)
        {

        }
        private Form ActiveForm = null;
        private void ShowForn(Form ChildrenForm)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            ActiveForm = ChildrenForm;
            ChildrenForm.TopLevel = false;
            ChildrenForm.FormBorderStyle = FormBorderStyle.None;
            ChildrenForm.Dock = DockStyle.Fill;
            ViewPrincipal.Controls.Add(ChildrenForm);
            ViewPrincipal.Tag = ChildrenForm;
            ChildrenForm.BringToFront();
            ChildrenForm.Show();
        }
    }
}
