namespace EF_Core_Pagination.Api;

public class ProductRespons
{
    public List<Product> Products { get; set; } = new List<Product>();
    public int Pages { get; set; }
    public int CurrentPage { get; set; }
}
