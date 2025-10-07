using System;

namespace SuperModel;

public class Genre
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Genre(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Name}: {Description}";
    }
}
