using System;

public abstract class User:BusinesObject
{
	public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Surname { get; set; }
    public bool IsAdmin { get; }
    public Role UserRole { get; }
}
