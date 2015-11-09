using System.Collections.Generic;

public class Client : User
{ 
    public string DriverLicenseNumber { get; set; }

    public string PhoneNumber { get; set; }

    public string PassportNumber { get; set; }

    public List<Order> Orders { get; set; }

    public override object Clone()
    {
        return new Client
        {
            Id = this.Id,
            Name = this.Name,
            Login = this.Login,
            Password = this.Password,
            Email = this.Email,
            DateOfBirth = this.DateOfBirth,
            Surname = this.Surname,
            DriverLicenseNumber = this.DriverLicenseNumber,
            PhoneNumber=this.PhoneNumber,
            PassportNumber=this.PassportNumber,
            Orders=this.Orders
        };
    }

}
