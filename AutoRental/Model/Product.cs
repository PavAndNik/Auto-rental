﻿using System;

public class Product : BusinesObject
{
    enum ProductType { Auto,Trailer};
 
    public DateTime DateOfCreation {get;set;}
    public int Cost { get; set; }
    public string Type { get; set; }
    public string Producer { get; set; }
    public int Discount { get; set; }
    public Decimal Price { get; set; }
}