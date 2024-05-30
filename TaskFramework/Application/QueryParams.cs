namespace TaskFramework.Application;

public class QueryParams
{
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
    public bool OrderDesc { get; set; } = true;
    public bool Expunged { get; set; } = false;   
}