namespace DMP.Infrastructure.Model.Interface
{
    public interface IModelBase
    {
        int SourceTag { set; get; } 
        int DocumentType { set; get; } 
        string Name { set; get; } 
        string DisplayName { set; get; }
    }
}