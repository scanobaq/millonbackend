namespace Application.DTOs.Property;

public class PropertyFilterDto
{
    public string SearchTerm { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; }
    public bool IsDescending { get; set; }
}