using System.Text.Json;
using SuperModel;

namespace AsyncDemo;

public static class Util
{

    public static void GenerateData()
    {
        GenerateFilms();
        GenerateGenres();
        GenerateActors();
    }
    private static void GenerateActors()
    {
        List<Actor> actors = new List<Actor>();

        for (int i = 1; i <= 500; i++)
            actors.Add(new Actor($"Name {i}", 20 + (i % 25)));

        File.WriteAllText("../../../../SuperLibrary/Data/actors.json", JsonSerializer.Serialize(actors));
    }

    private static void GenerateFilms()
    {
        List<Film> films = new List<Film>();

        for (int i = 1; i <= 500; i++)
            films.Add(new Film($"Title {i}", $"Director {i}", 2000 + (i % 25)));

        File.WriteAllText("../../../../SuperLibrary/Data/films.json", JsonSerializer.Serialize(films));
    }

    private static void GenerateGenres()
    {
        List<Genre> genres = new List<Genre>();

        for (int i = 1; i <= 500; i++)
            genres.Add(new Genre($"Genre {i}", $"Descirption {i}"));

        File.WriteAllText("../../../../SuperLibrary/Data/genres.json", JsonSerializer.Serialize(genres));
    }
}
