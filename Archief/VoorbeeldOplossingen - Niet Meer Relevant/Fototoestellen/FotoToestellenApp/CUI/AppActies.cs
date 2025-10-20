using FotoToestellen.Domein.Modellen;
using FotoToestellenApp.Services;

namespace FotoToestellenApp.CUI;

public class AppActies(IFotoToestellenService service)
{
    public void LijstMerken()
    {
        AppConsole.SchrijfLijst(
            "Merken In Systeem", 
            service.GeefMerken()
                .Select(merk => 
                    $"({merk.id}) {merk.merk} (aantal toestellen: {merk.aantalToestellen})")
                .ToList()); 
    }
    
    public void LijstFotoToestellen()
    {
        AppConsole.SchrijfLijst(
            "Fototoestellen In Systeem", 
            service.GeefFotoToestellen()
                .Select(toestel => 
                    $"({toestel.id}) {toestel.toestel} ({toestel.merk})")
                .ToList()); 
    }
    
    public void LijstLenzen()
    {
        AppConsole.SchrijfLijst(
            "Lenzen In Systeem", 
            service.GeefLenzen()
                .Select(lens => 
                    $"({lens.id}) {lens.lens} ({lens.merk})")
                .ToList()); 
    }
    
    public void VoegMerkToe()
    {
        var naam = AppConsole.LeesString("Naam");
        var site = AppConsole.LeesString("Website");
        service.VoegMerkToe(naam, site);
    }
    
    public void VoegFotoToestelToe()
    {
        var merkId = AppConsole.LeesInt("Merk Id");
        var model = AppConsole.LeesString("Model");
        var prijs = AppConsole.LeesDouble("Prijs");
        var sinds = AppConsole.LeesDateOnly("Beschikbaar Sinds (YYYY/MM/DD)");
        service.VoegFotoToestelToe(merkId, model, prijs, sinds);
    }
    
    public void VoegLensToe()
    {
        var merkId = AppConsole.LeesInt("Merk Id");
        var model = AppConsole.LeesString("Model");
        var prijs = AppConsole.LeesDouble("Prijs");
        var gewicht = AppConsole.LeesDouble("Gewicht in gram");
        var mount = (Mount)AppConsole.LeesEnum<Mount>();
        service.VoegLensToe(merkId, model, prijs, gewicht, mount);
    }
    
    public void RegistreerCompatibiliteit()
    {
        var lensId = AppConsole.LeesInt("Lens Id");
        var toestelId = AppConsole.LeesInt("FotoToestel Id");
        service.RegistreerCompatibiliteit(lensId, toestelId);
    }
    
    public void LijstCompatibeleLenzen()
    {
        var toestelId = AppConsole.LeesInt("FotoToestel Id");
        AppConsole.SchrijfLijst($"Compatibele Lenzen (toestel {toestelId})",
            service.GeefCompatibeleLenzen(toestelId)
                .Select(lens => $"({lens.id}) {lens.lens}")
                .ToList());
    }
    
    public void LijstCompatibeleFotoToestellen()
    {
        var lensId = AppConsole.LeesInt("Lens Id");
        AppConsole.SchrijfLijst($"Compatibele FotoToestellen (lens {lensId})",
            service.GeefCompatibeleToestellen(lensId)
                .Select(toestel => $"({toestel.id}) {toestel.toestel}")
                .ToList());        
    }
}