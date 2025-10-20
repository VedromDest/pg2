namespace FotoToestellenApp.CUI;

public partial class App
{
    private void InterageerMetGebruiker()
    {
        Dictionary<int, (string tekst, Action methode)> keuzesEnMethoden = new()
        {
            { 0, ("Applicatie Afsluiten", lifetime.StopApplication) },
            { 1, ("Lijst Merken", appActies.LijstMerken) },
            { 2, ("Lijst Fototoestellen", appActies.LijstFotoToestellen) },
            { 3, ("Lijst Lenzen", appActies.LijstLenzen) },
            { 10, ("Voeg Merk Toe", appActies.VoegMerkToe) },
            { 11, ("Voeg Fototoestel Toe", appActies.VoegFotoToestelToe) },
            { 12, ("Voeg Lens Toe", appActies.VoegLensToe) },
            { 20, ("Registreer Compatibiliteit", appActies.RegistreerCompatibiliteit)},
            { 31, ("Lijst Compatibele Lenzen", appActies.LijstCompatibeleLenzen)},
            { 32, ("Lijst Compatibele FotoToestellen", appActies.LijstCompatibeleFotoToestellen)}
        };

        do
        {
            MaakKeuzeEnVoerUit();
        } while (!lifetime.ApplicationStopping.IsCancellationRequested);

        return;

        void MaakKeuzeEnVoerUit()
        {
            AppConsole.SchrijfLijst("Maak een keuze", 
                keuzesEnMethoden
                    .Select(keuzeKv => $"[{keuzeKv.Key}] {keuzeKv.Value.tekst}")
                    .ToList());

            int keuze;
            do
            {
                keuze = AppConsole.LeesInt("Menu Keuze");
            } while (!keuzesEnMethoden.ContainsKey(keuze));
            Console.WriteLine();

            keuzesEnMethoden[keuze].methode(); 
        }
    }    
}