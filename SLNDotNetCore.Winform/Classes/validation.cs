using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.Winform.Classes
{
    internal class Validation
    {
        public static bool IsValueValid(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                if (subControl is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool AllTextBoxesHaveData(Control panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void MoveToNextControlOnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (sender is Control currentControl)
                {
                    Control parent = currentControl.Parent;
                    if (parent != null)
                    {
                        var controls = parent.Controls.Cast<Control>().Where(c => c.TabStop).OrderBy(c => c.TabIndex).ToList();
                        int currentIndex = controls.IndexOf(currentControl);
                        int nextIndex = currentIndex + 1;

                        if (nextIndex < controls.Count)
                        {
                            Control nextControl = controls[nextIndex];
                            if (nextControl != null)
                            {
                                if (nextControl is TextBox)
                                {
                                    nextControl.Focus();
                                    ((TextBox)nextControl).SelectionStart = ((TextBox)nextControl).Text.Length;
                                }
                                else if (nextControl is Button)
                                {
                                    ((Button)nextControl).PerformClick();
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
