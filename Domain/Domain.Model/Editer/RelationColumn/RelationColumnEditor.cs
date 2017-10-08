using System;
using System.ComponentModel;
using System.Drawing.Design; 
using System.Windows.Forms.Design;

namespace DMP.Infrastructure.Model.Editer.RelationColumn
{
    public class RelationColumnEditer : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            RelationColumnEditerForm editForm = new RelationColumnEditerForm { Text = "To be implemented" };
            /*
            editForm.BindListItems(value);
            if (service.ShowDialog(editForm) == DialogResult.OK)
            {
                value = editForm.ReturnValue;
            }
            */
            return value;
        }
    }
}
