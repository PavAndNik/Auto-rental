using System.Collections.Generic;

public class Client : User
{ 
    public string DriverLicenseNumber { get; set; }

    public string PhoneNumber { get; set; }

    public string PassportNumber { get; set; }

    public List<Order> Orders { get; set; }

}
