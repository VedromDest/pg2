namespace WebShoppie.Persistence
{
    // Ik ben een partial class en zal bij compilatie samengevoegd worden met
    // andere partial klassen met zelfde naam én namespace tot één geheel.

    // EF Core scaffolding genereert entities als partial klassen. Op die
    // manier kan je ze uitbreiden zonder jouw toevoegingen verloren gaan bij
    // het hergenereren van de entities door EF Core scaffolding.
    public partial class Product
    {
        public bool MijnSuperMethode()
        {
            return false;
        }
    }
}
