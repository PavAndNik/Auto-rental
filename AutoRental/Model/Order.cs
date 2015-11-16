using System;
using System.Collections.Generic;

public class Order: BusinesObject
{
    public List<Product> ListOfProducts { get; set; }
    public Decimal FullPrice { get; set; }
    public Client Buyer { get; set; }
    public DateTime DateOfOrder { get; set; }
    public Order()
	{ 
        ListOfProducts = new List<Product>();
	}

    public override object Clone()
    {
        return new Order
        {
            Id = this.Id,
            Name = this.Name,
            ListOfProducts = this.ListOfProducts,
            FullPrice = this.FullPrice,
            Buyer = this.Buyer,
            DateOfOrder = this.DateOfOrder
        };
    }
}
