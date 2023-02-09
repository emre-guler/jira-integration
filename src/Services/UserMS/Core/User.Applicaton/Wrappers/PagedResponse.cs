namespace User.Applicaton.Wrappers;

public class PagedResponse<T> : ServiceResponse<T>
{
    public PagedResponse(string message) : base(message)
    {
        
    }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}