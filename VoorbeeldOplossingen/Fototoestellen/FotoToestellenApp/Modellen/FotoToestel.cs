using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FotoToestellenApp.Modellen;

[Index(nameof(Model), IsUnique = true)]
public class FotoToestel
{
    public int Id { get; set; }
    
    [MaxLength(30)]
    public required string Model { get; set; }
    [Range(0,10000)]
    public double AdviesPrijs { get; set; }
    [Range(typeof(DateOnly), "1/1/1826", "1/1/2033")]
    public DateOnly BeschikbaarSinds { get; set; }

    public int MerkId { get; set; }
    public Merk? Merk { get; set; }

    public List<Lens> CompatibeleLenzen { get; set; } = [];
}