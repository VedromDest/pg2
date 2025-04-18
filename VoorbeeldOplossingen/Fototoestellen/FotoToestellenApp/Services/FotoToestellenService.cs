using FotoToestellen.Domein.Modellen;
using FotoToestellenApp.Modellen;
using FotoToestellenApp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FotoToestellenApp.Services;

public interface IFotoToestellenService
{
    void VoegMerkToe(string naam, string site);
    void VoegFotoToestelToe(int merkId, string model, double prijs, DateOnly beschikbaarSinds);
    void VoegLensToe(int merkId, string model, double prijs, double gewichtG, Mount mount);

    void RegistreerCompatibiliteit(int toestelId, int lensId);
    
    IEnumerable<(int id, string merk, int aantalToestellen)> GeefMerken();
    IEnumerable<(int id, string toestel, string merk)> GeefFotoToestellen();
    IEnumerable<(int id, string lens, string merk)> GeefLenzen();
    
    IEnumerable<(int id, string lens)> GeefCompatibeleLenzen(int toestelId);
    IEnumerable<(int id, string toestel)> GeefCompatibeleToestellen(int lensId);
    
}

public class FotoToestellenService(FotoToestellenDbContext dbContext) : IFotoToestellenService
{
    
    public void VoegMerkToe(string naam, string site)
    {
        var nieuwMerk = new Merk
        {
            Naam = naam, 
            WebsiteUrl = site
        };
        dbContext.Merken.Add(nieuwMerk);
        dbContext.SaveChanges();
    }

    public void VoegFotoToestelToe(int merkId, string model, double prijs, DateOnly beschikbaarSinds)
    {
        var nieuwToestel = new FotoToestel
        {
            AdviesPrijs = prijs, 
            Model = model, 
            BeschikbaarSinds = beschikbaarSinds,
            MerkId = merkId
        };
        dbContext.FotoToestellen.Add(nieuwToestel);
        dbContext.SaveChanges();
    }

    public void VoegLensToe(int merkId, string model, double prijs, double gewichtG, Mount mount)
    {
        var nieuweLens = new Lens
        {
            MerkId = merkId,
            AdviesPrijs = prijs, 
            Model = model,
            GewichtG = gewichtG,
            Mount = mount
        };
        dbContext.Lenzen.Add(nieuweLens);
        dbContext.SaveChanges();
    }

    public void RegistreerCompatibiliteit(int toestelId, int lensId)
    {
        var toestel = dbContext.FotoToestellen
            .Include(ft => ft.CompatibeleLenzen)
            .SingleOrDefault(ft => ft.Id == toestelId);

        if (toestel is null)
            throw new Exception($"Toestel {toestelId} niet gevonden.");
        
        var lens = dbContext.Lenzen.Find(lensId);
        
        if (lens is null)
            throw new Exception($"Lens {lensId} niet gevonden.");        
        
        toestel.CompatibeleLenzen.Add(lens);
        dbContext.SaveChanges();
    }

    public IEnumerable<(int id, string merk, int aantalToestellen)> GeefMerken()
    {
        return dbContext.Merken
            .Include(merk => merk.FotoToestellen)
            .ToList()
            .Select(m => (m.Id, m.Naam, m.FotoToestellen.Count));
    }    
    
    public IEnumerable<(int id, string toestel, string merk)> GeefFotoToestellen()
    {
        return dbContext.FotoToestellen
            .Include(f => f.Merk)
            .ToList()
            .Select(ft => (ft.Id, ft.Model, ft.Merk!.Naam));
    }

    public IEnumerable<(int id, string lens, string merk)> GeefLenzen()
    {
        return dbContext.Lenzen.
            Include(l => l.Merk)
            .ToList()
            .Select(l => (l.Id, $"{l.Model} ({l.Mount.ToString()})" , l.Merk!.Naam));
    }

    public IEnumerable<(int id, string lens)> GeefCompatibeleLenzen(int toestelId)
    {
        return dbContext.FotoToestellen
            .Include(ft => ft.CompatibeleLenzen)
            .ThenInclude(l => l.Merk)
            .SingleOrDefault(ft => ft.Id == toestelId)
            ?.CompatibeleLenzen.ToList().Select(l => (l.Id, $"{l.Model} ({l.Merk!.Naam})" )) ?? Array.Empty<(int Id, string Model)>();
    }
    
    public IEnumerable<(int id, string toestel)> GeefCompatibeleToestellen(int lensId)
    {
        return dbContext.Lenzen
            .Include(l => l.CompatibeleFotoToestellen)
            .ThenInclude(f => f.Merk)
            .SingleOrDefault(l => l.Id == lensId)
            ?.CompatibeleFotoToestellen.ToList().Select(f => (f.Id, $"{f.Model} ({f.Merk!.Naam})")) ?? Array.Empty<(int Id, string Model)>();    }
}