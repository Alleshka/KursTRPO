namespace KursTRPO.Models
{
    using System.Data.Entity;

    public class TppContext : DbContext
    {
        public TppContext()
            : base("name=TppContext")
        {
        }

        public DbSet<RouteCar> RouteCars { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<TechnologicalProcesses> TechnologicalProcesseses { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Transition> Transitions { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Rigging> Riggings { get; set; }    
    }
}