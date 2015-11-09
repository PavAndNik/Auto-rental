using System;

public abstract class BusinesObject
{
    public int Id { get; set; }
    public string Name { get; set;}
    public abstract object Clone();
}
