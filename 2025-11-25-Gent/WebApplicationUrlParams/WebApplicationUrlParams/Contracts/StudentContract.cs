namespace WebApplicationUrlParams.Contracts;

public class StudentContract
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public DateTime GeboorteDatum { get; set; }
    public bool IsGeslaagd { get; set; }
}