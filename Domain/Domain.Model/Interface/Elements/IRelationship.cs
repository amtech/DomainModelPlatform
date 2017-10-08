using System.Collections.Generic;

namespace DMP.Infrastructure.Model.Interface.Elements
{
    public interface IRelationship
    { 
        int SourceTag { set; get; } 
        int DocumentType { set; get; } 
        string Name { set; get; } 
        string DisplayName { set; get; } 
        List<IRelationColumn> RelationColumns { get; set; }
    }

    public interface IRelationColumn
    {

    }

}