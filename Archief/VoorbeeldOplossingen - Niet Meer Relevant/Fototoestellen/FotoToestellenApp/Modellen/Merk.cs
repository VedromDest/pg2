using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FotoToestellenApp.Modellen;

[Index(nameof(Naam), IsUnique = true)]
public class Merk
{
    public int Id { get; set; }
    
    [MaxLength(60)]
    public required string Naam { get; set; }
    [Url]
    public required string WebsiteUrl { get; set; }

    public List<FotoToestel> FotoToestellen { get; set; } = [];
    public List<Lens> Lenzen { get; set; } = [];
}