using System;

public interface User:BusinesObject
{
	public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string DateOfBirth { get; set; }
    public string Surname { get; set; }
    public bool IsAdmin { get; }
}
