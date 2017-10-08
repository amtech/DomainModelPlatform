namespace DMP.Infrastructure.Model.Interface.Elements
{
    public interface IListItem
    {
        string Text { get; set; } 
        string Value { get; set; } 
        bool IsDefault { get; set; }
    }
}