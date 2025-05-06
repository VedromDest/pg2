using System;

namespace SuperModel;

public class Actor
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Actor(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name}, {Age} years old";
    }
}