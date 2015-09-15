using CarRental.Model.BasicModel;

public class Trailer:Product
{
    public int CatalogTrailerID { get; set; }

    public bool RemovableBoard { get; set; }   //Съемные борта

    public int LoadCapacity { get; set; }    //Грузоподъемность

    public int Weight { get; set; }

    public int BoardHeight { get; set; }

    public int Length { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }


}
