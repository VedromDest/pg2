namespace Patisserie;

public class Pistolet
{
    private const int BakTijdMs = 20;

    public void Bak()
    {
        Thread.Sleep(BakTijdMs);
        //Console.WriteLine("Ik ben krokant gebakken.");
    }
}