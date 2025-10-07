using System.Text.Json;
using SuperModel;

namespace SuperLibrary;

public class SuperFileIO
{
    public static List<Film> GetFilms()
    {
        string json = File.ReadAllText("../../../../SuperLibrary/Data/films.json");
        Thread.Sleep(1000); // Simulate a long calculation
        return JsonSerializer.Deserialize<List<Film>>(json) ?? [];
    }

    public static async Task<List<Film>> GetFilmsAsync()
    {
        var json = await File.ReadAllTextAsync("../../../../SuperLibrary/Data/films.json");
        await Task.Delay(1000); // Simulate a long async calculation
        return JsonSerializer.Deserialize<List<Film>>(json) ?? [];        
    }
}
