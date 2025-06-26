using OptimaBank.Domain;
using OptimaBank.Services;
using OptimaBank.UI.Controllers;
using System.Diagnostics;
using System.Windows.Forms;

namespace OptimaBank.UI
{
    public partial class FrmIdioma : Form
    {
        private readonly IdiomaController _idiomaController;
        private readonly BitacoraController _bitacoraController;
        public FrmIdioma(IdiomaController idiomaController, BitacoraController bitacoraController)
        {
            _idiomaController = idiomaController;
            _bitacoraController = bitacoraController;
            InitializeComponent();
        }

        private void HabilitarControles(bool habilitar, bool alta)
        {
            txtIdIdioma.Enabled = alta && habilitar;
            chkbDefault.Enabled = alta && habilitar;
            if (alta)
            {
                txtIdIdioma.Enabled = false;
                chkbDefault.Enabled = false;
                LimpiarControles();
            }

            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            txtImagen.Enabled = habilitar;
            
        }

        private void LimpiarControles()
        {
            txtIdIdioma.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtImagen.Text = string.Empty;
            chkbDefault.Checked = false;
        }

        private void CargarIdiomas()
        {
            var idiomas = _idiomaController.ObtenerIdiomas();
            listBoxIdiomas.DataSource = idiomas;
            listBoxIdiomas.ValueMember = "Nombre";
            listBoxIdiomas.DisplayMember = "Descripcion";
            listBoxIdiomas.SelectedIndex = 0;

            var idiomasParaCombo = _idiomaController.ObtenerIdiomas();
            cmbIdiomas.DataSource = idiomasParaCombo;
            cmbIdiomas.ValueMember = "Nombre";
            cmbIdiomas.DisplayMember = "Descripcion";

            cmbIdiomas.SelectedIndex = SingletonSession.GetInstance.Idioma.Id - 1;
        }

        private void CargarSeleccionado()
        {
            if (listBoxIdiomas.SelectedItem != null)
            {
                txtIdIdioma.Text = ((Idioma)listBoxIdiomas.SelectedItem).Id.ToString();
                txtNombre.Text = ((Idioma)listBoxIdiomas.SelectedItem).Nombre;
                txtDescripcion.Text = ((Idioma)listBoxIdiomas.SelectedItem).Descripcion;
                txtImagen.Text = ((Idioma)listBoxIdiomas.SelectedItem).Imagen;
                chkbDefault.Checked = ((Idioma)listBoxIdiomas.SelectedItem).Is_Default;
            }
        }

        private void FrmIdioma_Load(object sender, EventArgs e)
        {
            HabilitarControles(false, false);
            CargarIdiomas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true, false);
            CargarSeleccionado();
            btnNuevo.BackColor = Color.Silver;
            btnNuevo.Enabled = false;

            btnModificar.BackColor = Color.MediumSeaGreen;
            btnModificar.Enabled = true;

            btnEliminar.BackColor = Color.Silver;
            btnEliminar.Enabled = true;

            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Enabled = true;

            btnCancelar.BackColor = Color.Goldenrod;

        }

        private void EstiloDefault()
        {
            btnNuevo.BackColor = Color.RoyalBlue;
            btnNuevo.Enabled = true;

            btnModificar.BackColor = Color.Crimson;
            btnModificar.Enabled = true;

            btnEliminar.BackColor = Color.DimGray;
            btnModificar.Enabled = true;

            btnGuardar.BackColor = Color.RoyalBlue;
            btnGuardar.Enabled = true;

            btnCancelar.BackColor = Color.Crimson;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles(true, true);
            LimpiarControles();
            btnNuevo.BackColor = Color.MediumSeaGreen;
            btnNuevo.Enabled = true;
            btnModificar.BackColor = Color.Silver;
            btnModificar.Enabled = false;
            btnCancelar.BackColor = Color.Goldenrod;
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Functions.EmptyFields(this.Controls, new List<string>() { "txtIdIdioma" }))
                return;
            //if (_idiomaController.Validar(txtIdIdioma.Text, txtNombre.Text, txtDescripcion.Text, txtImagen.Text, chkbDefault.Checked))
            //{


            if (!string.IsNullOrEmpty(txtIdIdioma.Text))
            {
                var actualizado = ActualizarIdioma();
                if (actualizado != null)
                {
                    Registro_Notificacion("Idioma actualizado correctamente", (byte)Tipo.Informacion, (byte)Categoria.Sistema);
                    GrabarSuceso("Idioma actualizado: " + actualizado.Nombre, (byte)Tipo.Informacion, (byte)Categoria.Sistema);
                    HabilitarControles(false, false);
                    CargarIdiomas();
                }
                //}
            }
            else
            {
                var creado = CrearIdioma();
                if (creado != null)
                {
                    Registro_Notificacion("Idioma creado correctamente", (byte)Tipo.Informacion, (byte)Categoria.Sistema);
                    GrabarSuceso("Idioma creado: " + creado.Nombre, (byte)Tipo.Informacion, (byte)Categoria.Sistema);
                    HabilitarControles(false, false);
                    CargarIdiomas();
                }
            }
            EstiloDefault();
        }

        private void listBoxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSeleccionado();
        }

        private void cmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //btnNuevo.BackColor = Color.RoyalBlue;
            //btnNuevo.Enabled = true;
            //btnModificar.BackColor = Color.Crimson;
            //btnModificar.Enabled = true;
            //btnGuardar.BackColor = Color.RoyalBlue;
            //btnGuardar.Enabled = true;
            //btnCancelar.BackColor = Color.Crimson;

            EstiloDefault();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnNuevo.BackColor = Color.RoyalBlue;
            btnNuevo.Enabled = false;

            btnModificar.BackColor = Color.Crimson;
            btnModificar.Enabled = true;

            btnEliminar.BackColor = Color.MediumSeaGreen;
            btnEliminar.Enabled = true;

            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Enabled = true;

            btnCancelar.BackColor = Color.Goldenrod;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            int indexDefault = _idiomaController.SetDefault((Idioma)cmbIdiomas.SelectedItem);
            cmbIdiomas.SelectedIndex = indexDefault - 1;
            Registro_Notificacion("Idioma cambiado correctamente a: " + cmbIdiomas.Text, (byte)Tipo.Informacion, (byte)Categoria.Sistema);
            GrabarSuceso("Idioma cambiado correctamente a: " + cmbIdiomas.Text, (byte)Tipo.Informacion, (byte)Categoria.Sistema);
            HabilitarControles(false, false);
            CargarIdiomas();
        }

        private Idioma CrearIdioma()
        {
            return _idiomaController.Insertar(new Idioma(int.Parse(txtIdIdioma.Text),
                                txtNombre.Text, txtDescripcion.Text,
                                txtImagen.Text, chkbDefault.Checked));
        }

        private Idioma ActualizarIdioma()
        {
            return _idiomaController.Actualizar(new Idioma(int.Parse(txtIdIdioma.Text),
                                txtNombre.Text, txtDescripcion.Text,
                                txtImagen.Text, chkbDefault.Checked));
        }

        private void Consola(string mensaje)
        {
            FrmMain main = (FrmMain)this.MdiParent;
            main.EscribirConsola(mensaje);
        }

        private void GrabarSuceso(string mensaje, byte tipo, byte categoria)
        {
            _bitacoraController.RegistrarSuceso(new Bitacora
            {
                FechaSuceso = DateTime.Now,
                NombreUsuario = SingletonSession.GetInstance.Usuario.NombreUsuario,
                Mensaje = mensaje,
                Modulo = $"{this.ToString()}, {new StackTrace().GetFrame(1).GetMethod().Name}",
                Tipo = tipo,
                Categoria = categoria
            });
        }

        private void Registro_Notificacion(string mensaje, byte tipo, byte categoria)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Consola(mensaje);
        }
    }
}
