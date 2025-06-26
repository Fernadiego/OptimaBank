using OptimaBank.UI.Controllers;

namespace OptimaBank.UI
{
    public partial class FrmEtiquetasTraducciones : Form
    {
        private readonly IdiomaController _idiomaController;
        public FrmEtiquetasTraducciones(IdiomaController idiomaController)
        {
            _idiomaController = idiomaController;
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewTraducciones.Columns.Clear();
            dataGridViewTraducciones.Columns.Add("Id", "ID");
            dataGridViewTraducciones.Columns.Add("Idioma", "Idioma");
            dataGridViewTraducciones.Columns.Add("Texto", "Texto");
            dataGridViewTraducciones.Columns.Add("Activo", "Activo");

            dataGridViewTraducciones.Columns["Id"].Visible = false;
            dataGridViewTraducciones.Columns["Idioma"].Width = 100;
            dataGridViewTraducciones.Columns["Texto"].Width = 200;
            dataGridViewTraducciones.Columns["Activo"].Width = 60;
        }

        private void CargarEtiquetas()
        {

            //var etiquetas = _idiomaController.TraerEtiquetasDisponibles();
            // Luego, puedes llenar el DataGridView con las etiquetas
            // dataGridViewEtiquetas.DataSource = _etiquetas;
        }

        private void CargarTraduccionesEtiqueta()
        {
            //if (_etiquetaSeleccionada != null)
            //{
            //    dataGridViewTraducciones.Rows.Clear();
            //    var traduccionesEtiqueta = _traducciones.Where(t => t.EtiquetaId == _etiquetaSeleccionada.Id).ToList();

            //    foreach (var traduccion in traduccionesEtiqueta)
            //    {
            //        var idioma = _idiomas.FirstOrDefault(i => i.Id == traduccion.IdiomaId);
            //        var idiomaNombre = idioma?.Codigo ?? "N/A";

            //        dataGridViewTraducciones.Rows.Add(
            //            traduccion.Id,
            //            idiomaNombre,
            //            traduccion.Texto,
            //            traduccion.Activo ? "Sí" : "No"
            //        );
            //    }
            //}
        }
    }
}
