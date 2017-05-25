namespace KursTRPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usstring2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("TechProcProd.RouteCar", "Developer", c => c.String());
            AlterColumn("TechProcProd.RouteCar", "Checked", c => c.String());
            AlterColumn("TechProcProd.RouteCar", "Agreed", c => c.String());
            AlterColumn("TechProcProd.RouteCar", "Approved", c => c.String());
            AlterColumn("TechProcProd.RouteCar", "NormСontroller", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("TechProcProd.RouteCar", "NormСontroller", c => c.Int(nullable: false));
            AlterColumn("TechProcProd.RouteCar", "Approved", c => c.Int(nullable: false));
            AlterColumn("TechProcProd.RouteCar", "Agreed", c => c.Int(nullable: false));
            AlterColumn("TechProcProd.RouteCar", "Checked", c => c.Int(nullable: false));
            AlterColumn("TechProcProd.RouteCar", "Developer", c => c.Int(nullable: false));
        }
    }
}
