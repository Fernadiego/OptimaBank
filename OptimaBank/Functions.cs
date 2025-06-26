using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaBank.UI
{
    public static class Functions
    {
        public static bool EmptyFields(Control.ControlCollection controles, List<string> controlesExcluidos)
        {
            var controlesOrderByTabIndex = controles.Cast<Control>()
                .OrderBy(c => c.TabIndex)
                .Where(c => c is TextBox || c is ComboBox || c is DateTimePicker || c is MaskedTextBox)
                .ToList();

            foreach (Control control in controlesOrderByTabIndex)
            {
                if (control is TextBox textbox)
                {
                    if (controlesExcluidos is null || (controlesExcluidos is not null && !controlesExcluidos.Contains(textbox.Name)))
                    {
                        if (string.IsNullOrWhiteSpace(textbox.Text))
                        {
                            MessageBox.Show($"Por favor, complete el campo {textbox.Name.Replace("txt", "")}.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                else if (control is ComboBox combobox)
                {
                    if (combobox.SelectedIndex == -1)
                    {
                        MessageBox.Show($"Por favor, seleccione una opción en el campo {combobox.Name.Replace("cmb", "")}.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else if (control is MaskedTextBox maskedTextBox)
                {
                    if (string.IsNullOrWhiteSpace(maskedTextBox.Text))
                    {
                        MessageBox.Show($"Por favor, complete el campo {maskedTextBox.Name.Replace("mtb", "")}.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        public static Dictionary<string, string> GetTraduccionByLabels(Dictionary<string, string> traducciones, List<string> labels)
        {
            return traducciones
                .Where(x => labels.Contains(x.Key))
                .ToDictionary<string, string>();
        }

        public static void InicializarHeader(Dictionary<string, string> traducciones, Form form)
        {
            traducciones.TryGetValue(form.Tag.ToString(), out string traduccion);
            form.Text = !string.IsNullOrEmpty(traduccion)
                ? traduccion
                : "Optima Bank - Form(E)";
        }

        public static void AplicarTraduction(Control.ControlCollection controles, Dictionary<string, string> traducciones)
        {
            var controlesOrderByTabIndex = controles.Cast<Control>()
              .OrderBy(c => c.TabIndex)
              .Where(c => c is Panel || c is Button || c is Label || c is TextBox || c is ComboBox || c is DateTimePicker || c is MaskedTextBox)
              .ToList();

            foreach (Control control in controlesOrderByTabIndex)
            {

                if (control is Panel panel)
                {
                    foreach (Control childControl in panel.Controls)
                    {
                        if (childControl.Tag != null && childControl.Tag is string etiqueta1)
                        {
                            if (traducciones.ContainsKey(etiqueta1))
                            {
                                childControl.Text = traducciones[etiqueta1];
                            }
                            else
                            {
                                childControl.Text = etiqueta1;
                            }
                        }
                    }
                }

                if (control.Tag != null && control.Tag is string etiqueta)
                {
                    if (traducciones.ContainsKey(etiqueta))
                    {
                        control.Text = traducciones[etiqueta];
                    }
                    else
                    {
                        control.Text = etiqueta;
                    }
                }
                //if (control is TextBox textbox)
                //{

                //}
                //else if (control is ComboBox combobox)
                //{

                //}
                //else if (control is MaskedTextBox maskedTextBox)
                //{

                //}
                //else if(control is Label)
                //{
                //    if (control.Tag != null && control.Tag is string etiqueta)
                //    {
                //        if (traducciones.ContainsKey(etiqueta))
                //        {
                //            control.Text = traducciones[etiqueta];
                //        }
                //        else
                //        {
                //            control.Text = etiqueta;
                //        }
                //    }
                //}
            }
        }
    }
}
