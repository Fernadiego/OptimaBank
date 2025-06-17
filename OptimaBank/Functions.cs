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
    }
}
