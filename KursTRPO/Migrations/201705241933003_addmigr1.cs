namespace KursTRPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigr1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("TechProcProd.Operation", "RiggingId");
        }
        
        public override void Down()
        {
            AddColumn("TechProcProd.Operation", "RiggingId", c => c.Int(nullable: false));
        }
    }
}
