namespace DapperDemo.Model
{
    internal class Pet
    {
        public int PetId { get; set; }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public Owner Owner { get; set; }
    }
}
