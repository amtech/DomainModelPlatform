using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMP.Infrastructure.ModelDesigner.Common
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
