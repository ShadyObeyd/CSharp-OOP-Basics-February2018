using System;

public abstract class Unit
{
    protected Unit(string id)
    {
        this.Id = id;
    }

    public string Id { get; protected set; }
}