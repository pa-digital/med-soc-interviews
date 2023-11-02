namespace HealthView.Domain.Entities;

public class Pager<T>
{
    public int TotalPages { get; set; }
    
    public int CurrentPage { get; set; }
    
    public int PageSize { get; set; }
    
    public IEnumerable<T>? PageItems { get; set; }
}