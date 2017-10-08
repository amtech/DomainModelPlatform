
namespace Domain.ModelDesigner.Common
{
    public class EnumValue
    {

        public enum ProjectState
        {
            New,
            Editing,
            Saved
        }

        public enum EditState
        {
            UnSave,
            Saved
        }

        public enum ModelType
        {
            Business,
            Report
        }

    }
}
