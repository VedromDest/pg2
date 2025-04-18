namespace FotoToestellenApp.CUI;

public static class AppConsole
{
    
    private static void Schrijf(string tekst = "", ConsoleColor color = ConsoleColor.Black)
    {
        Console.ForegroundColor = color;
        Console.Write(tekst);
        Console.ResetColor();
    }
    private static void SchrijfLijn(string tekst = "", ConsoleColor color = ConsoleColor.Black)
    {
        Schrijf(tekst, color);
        Console.WriteLine();
    }
    
    public static void SchrijfLog(string tekst)
    {
        SchrijfLijn(tekst, ConsoleColor.Gray);
    }
    
    public static void SchrijfLijst(string titel, List<string> lijst)
    {
        if(lijst.Count == 0)
            lijst.Add("(lijst is leeg)");
        
        SchrijfLijn();
        SchrijfLijn(titel);
        
        var breedte = Math.Max(titel.Length, lijst.MaxBy(l => l.Length)?.Length ?? 0);
        SchrijfLijn(new string('-', breedte));
        
        foreach (var tekst in lijst)
        {
            SchrijfLijn(tekst);
        }
    }
    
    public static string LeesString(string naam)
    {
        string? gelezenString;
        do
        {
            Schrijf($"Geef een waarde voor {naam}: ", ConsoleColor.Green);
            gelezenString = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(gelezenString));

        return gelezenString;
    }
    
    public static int LeesInt(string boodschap)
    {
        string? waarde;
        int gelezenInt;
        do
        {
            Schrijf($"Geef een waarde voor {boodschap}: ", ConsoleColor.Green);
            waarde = Console.ReadLine() ?? string.Empty;
        } while (!int.TryParse(waarde, out gelezenInt));

        return gelezenInt;
    }    
    
    public static double LeesDouble(string boodschap)
    {
        string? waarde;
        double gelezenDouble;
        do
        {
            Schrijf($"Geef een waarde voor {boodschap}: ", ConsoleColor.Green);
            waarde = Console.ReadLine() ?? string.Empty;
        } while (!double.TryParse(waarde, out gelezenDouble));

        return gelezenDouble;
    }    
    
    public static DateOnly LeesDateOnly(string boodschap)
    {
        string? waarde;
        DateOnly gelezenDateOnly;
        do
        {
            Schrijf($"Geef een waarde voor {boodschap}: ", ConsoleColor.Green);
            waarde = Console.ReadLine() ?? string.Empty;
        } while (!DateOnly.TryParse(waarde, out gelezenDateOnly));

        return gelezenDateOnly;
    }     
    
    
    public static int LeesEnum<T>() where T : Enum
    {
        var validValues = Enum.GetValues(typeof(T)).Cast<int>().ToList();
        var boodschap = string.Join(",", validValues.Select(k => $"({k}) {Enum.GetName(typeof(T), k)}"));
        
        int waarde;
        
        do
        {
            waarde = LeesInt(boodschap);
        } while (!validValues.Contains(waarde));

        return waarde;
    }     
}