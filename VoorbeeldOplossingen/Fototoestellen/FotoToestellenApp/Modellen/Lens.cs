using System.ComponentModel.DataAnnotations;
using FotoToestellen.Domein.Modellen;
using Microsoft.EntityFrameworkCore;

namespace FotoToestellenApp.Modellen;

[Index(nameof(MerkId), [nameof(Model)], IsUnique = true)]
public class Lens
{
    public int Id { get; set; }
    
    [MaxLength(30)]
    public required string Model { get; set; }
    [Range(0,10000)]
    public double AdviesPrijs { get; set; }
    [Range(0,2800000)]
    public double GewichtG { get; set; }
    public Mount Mount { get; set; }

    public int MerkId { get; set; }
    public Merk? Merk { get; set; }
    
    public List<FotoToestel> CompatibeleFotoToestellen { get; set; } = [];
}