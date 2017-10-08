using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DMP.Infrastructure.Model.Editer
{
    public class ListItemEditer : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                IWindowsFormsEditorService service = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
                ListItemEditerForm editForm = new ListItemEditerForm { Text = "To be implemented" };
                editForm.BindListItems(value);
                editForm.StartPosition = FormStartPosition.CenterScreen;
                if (service != null && service.ShowDialog(editForm) == DialogResult.OK)
                {
                    value = editForm.ReturnValue;
                }
            }
            return value;
        }
    }
}
