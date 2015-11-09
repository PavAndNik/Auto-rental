using System;

public class User:BusinesObject
{
	public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Surname { get; set; }
    public bool IsAdmin { get; }
    public Role UserRole { get; }
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
            Surname = this.Surname
        };
    }
}
