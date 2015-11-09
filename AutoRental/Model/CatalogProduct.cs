using System;
using System.Collections.Generic;

public class CatalogProduct:BusinesObject
{
    public List<Product> AutoList { get; set; }
    public CatalogProduct()
    {
        this.AutoList = new List<Product>();
    }

    public override object Clone()
    {
        return new CatalogProduct
        {
            Id=this.Id,
            Name=this.Name,
            AutoList=this.AutoList
        };
    }
}
