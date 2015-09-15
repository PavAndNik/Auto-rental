using System;
using CarRental.Model.BasicModel;

public class CatalogTrailers:BusinesObject
{
    public List<Trailer> TrailersList { get; set; }

    public CatalogTrailers()
    {
        this.TrailersList = new List<Trailer>();
    }
}
