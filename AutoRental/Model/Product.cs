using AutoRental.Model;
using System;
using System.Collections.Generic;

public class Product : BusinesObject
{
    enum ProductType { Auto,Trailer};
 
    public DateTime DateOfCreation {get;set;}
    public int Cost { get; set; }
    public string Type { get; set; }
    public string Producer { get; set; }
    public int Discount { get; set; }
    public Decimal Price { get; set; }
    public List<ProductCharacteristic> Characteristics {get; set; }

    public override object Clone()
    {
        return new Product
        {
            Id = this.Id,
            Name = this.Name,
          DateOfCreation=this.DateOfCreation,
          Characteristics=this.Characteristics,
          Cost=this.Cost,
          Discount=this.Discount,
          Price=this.Price,
          Producer=this.Producer,
          Type=this.Type
        };
    }
}
