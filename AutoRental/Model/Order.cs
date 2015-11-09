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
        throw new NotImplementedException();
    }
}
