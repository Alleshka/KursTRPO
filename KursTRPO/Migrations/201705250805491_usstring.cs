namespace KursTRPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("TechProcProd.Route", "NameOfDeveloper", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("TechProcProd.Route", "NameOfDeveloper", c => c.Int(nullable: false));
        }
    }
}
