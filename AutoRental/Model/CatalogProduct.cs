using System.Collections.Generic;

public class CatalogProduct:BusinesObject
{
    public List<Product> AutoList { get; set; }
    public CatalogProduct()
    {
        this.AutoList = new List<Product>();
    }
}
