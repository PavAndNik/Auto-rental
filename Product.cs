using System;

public interface Product : BusinesObject
{
    public DateTime DateOfCreation {get;set;}
    public int Cost { get; set; }
    public string Type { get; set; }
    public string Producer { get; set; }
    public int Discount { get; set; }
    public int CountPrise() { }
}
