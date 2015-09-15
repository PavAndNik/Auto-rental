using CarRental.Model.BasicModel;
using System;


public class Client : User
{ 
    public string DriverLicenseNumber { get; set; }

    public string PhoneNumber { get; set; }

    public string PassportNumber { get; set; }

    public List<Product> Product { get; set; }

}
