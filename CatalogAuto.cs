using CarRental.Model.BasicModel;

public class CatalogAuto:BusinesObject
{
    public List<Auto> AutoList { get; set; }

    public CatalogAuto()
    {
        this.AutoList = new List<Auto>();
    }
}
