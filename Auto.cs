using CarRental.Interfaces;
using System;




public class Auto : Product
{
    enum TransmissionType { Automatic, Manual};
    enum EngineType { Benzine,Diesel,Gas,Electro};

    public int CatalogID { get; set; }

    public int ClientID { get; set; }

    public int EngineCapacity { get; set; } //Объем двигателя
    
    public int Mileage { get; set; } //Пробег

    public int FuelConsumption { get; set; }  //Расход топлива

    public TransmissionType Transmission { get; set; }

    public EngineType Engine { get; set; }


}
