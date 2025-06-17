using OptimaBank.Domain;
using OptimaBank.UI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimaBank.UI
{
    public partial class FrmRegistrarse : Form
    {
        private readonly UsuarioController _usuarioController;
        public FrmRegistrarse()
        {
                
        }
        public FrmRegistrarse(UsuarioController usuarioController)
        {
            _usuarioController = usuarioController;
            InitializeComponent();
            LoadControls();
        }

        private void LoadControls()
        {
            cmbSexo.Items.Add("Seleccionar");
            cmbSexo.Items.Add("Femenino");
            cmbSexo.Items.Add("Masculino");
            cmbSexo.Items.Add("Otro");
            cmbSexo.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!Functions.EmptyFields(gbRegistrarse.Controls, new List<string>() { "txtRepite" }))
                return;

            if (_usuarioController.Validar(txtUsuario.Text, txtContraseña.Text, txtRepite.Text, cmbSexo.SelectedItem.ToString(), dtpNacimiento.Value, txtEmail.Text))
                if(_usuarioController.Nuevo(
                    new Usuario(txtUsuario.Text, txtContraseña.Text) 
                    { 
                        Activo = true, FechaCreacion = DateTime.Now, Email = txtEmail.Text 
                    }))
                    this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
