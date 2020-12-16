using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pos.App.Desktop.Abstracts
{
    public static class ViewClearExtension
    {
        private static readonly Dictionary<Type, Action<Control>> ControlDefaults = new Dictionary<Type, Action<Control>>
        {
                {typeof(TextBox), c => ((TextBox)c).Clear()},
                {typeof(MetroTextBox), c => ((MetroTextBox)c).Clear()},
                {typeof(MetroComboBox), c => ((MetroComboBox)c).SelectedIndex=-1},
                {typeof(MetroGrid), c => ((MetroGrid)c).DataSource=null},
                {typeof(CheckBox), c => ((CheckBox)c).Checked = false},
                {typeof(ListBox), c => ((ListBox)c).Items.Clear()},
                {typeof(RadioButton), c => ((RadioButton)c).Checked = false},
                {typeof(GroupBox), c => ((GroupBox)c).Controls.ClearControls()},
                {typeof(Panel), c => ((Panel)c).Controls.ClearControls()}
        };

        private static void FindAndInvoke(Type type, Control control)
        {
            if (ControlDefaults.ContainsKey(type))
            {
                ControlDefaults[type].Invoke(control);
            }
        }

        public static void ClearControls(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                FindAndInvoke(control.GetType(), control);
            }
        }

        public static void ClearControls<T>(this Control.ControlCollection controls) where T : class
        {
            if (!ControlDefaults.ContainsKey(typeof(T))) return;

            foreach (Control control in controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control panelControl in panel.Controls)
                    {
                        if (panelControl.GetType() == typeof(T))
                        {
                            FindAndInvoke(typeof(T), panelControl);
                        }
                    }
                }
                if (control.GetType() == typeof(T))
                {
                    FindAndInvoke(typeof(T), control);
                }
            }

        }

        public static Control FindControl<T>(this Control.ControlCollection controls) where T : class
        {
            foreach (Control control in controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control panelControl in panel.Controls)
                    {
                        if (panelControl.GetType() == typeof(T))
                        {
                            return panelControl;
                        }
                    }
                }
                if (control.GetType() == typeof(T))
                {
                    return control;
                }
            }

            return null;
        }

    }
}
