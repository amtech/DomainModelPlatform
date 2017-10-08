using Domain.Bll.Interface;
using Domain.Model;
using System.Collections.Generic;

namespace DMP.Ui.Web.Common
{
    public class StaticValue
    {
        public static Dictionary<string, BusinessModel> BusinessModels;

        public static Dictionary<string, ReportModel> ReportModels;

        public static Dictionary<int, IBll> Blls;
    }
}