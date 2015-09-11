using System;
using CarRental.Interfaces;

public class CatalogTrailers:BusinesObject
{
    public List<Trailer> TrailersList { get; set; }

    public CatalogTrailers()
    {
        this.TrailersList = new List<Trailer>();
    }
}
