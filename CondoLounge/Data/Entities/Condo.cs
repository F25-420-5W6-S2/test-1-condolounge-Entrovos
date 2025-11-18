namespace CondoLounge.Data.Entities
{
    public class Condo
    {
        public int Id { get; set; }

        public int CondoNumber { get; set; }
        
        public string Location { get; set; }

        public Building Building { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
