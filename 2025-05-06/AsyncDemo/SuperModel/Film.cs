using System;

namespace SuperModel;

public class Film
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }

    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title} ({Year}), directed by {Director}";
    }
}