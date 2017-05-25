namespace KursTRPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _555 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("TechProcProd.Operation", "RiggingId", "TechProcProd.Rigging");
            DropForeignKey("TechProcProd.TechnologicalProcesses", "OperationId", "TechProcProd.Operation");
            DropIndex("TechProcProd.Operation", new[] { "RiggingId" });
            DropIndex("TechProcProd.TechnologicalProcesses", new[] { "OperationId" });
            CreateTable(
                "dbo.RiggingOperations",
                c => new
                    {
                        Rigging_RiggingId = c.Int(nullable: false),
                        Operation_OperationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rigging_RiggingId, t.Operation_OperationId })
                .ForeignKey("TechProcProd.Rigging", t => t.Rigging_RiggingId, cascadeDelete: true)
                .ForeignKey("TechProcProd.Operation", t => t.Operation_OperationId, cascadeDelete: true)
                .Index(t => t.Rigging_RiggingId)
                .Index(t => t.Operation_OperationId);
            
            CreateTable(
                "dbo.TechnologicalProcessesOperations",
                c => new
                    {
                        TechnologicalProcesses_TechProcId = c.Int(nullable: false),
                        Operation_OperationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TechnologicalProcesses_TechProcId, t.Operation_OperationId })
                .ForeignKey("TechProcProd.TechnologicalProcesses", t => t.TechnologicalProcesses_TechProcId, cascadeDelete: true)
                .ForeignKey("TechProcProd.Operation", t => t.Operation_OperationId, cascadeDelete: true)
                .Index(t => t.TechnologicalProcesses_TechProcId)
                .Index(t => t.Operation_OperationId);
            
            DropColumn("TechProcProd.TechnologicalProcesses", "OperationId");
        }
        
        public override void Down()
        {
            AddColumn("TechProcProd.TechnologicalProcesses", "OperationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TechnologicalProcessesOperations", "Operation_OperationId", "TechProcProd.Operation");
            DropForeignKey("dbo.TechnologicalProcessesOperations", "TechnologicalProcesses_TechProcId", "TechProcProd.TechnologicalProcesses");
            DropForeignKey("dbo.RiggingOperations", "Operation_OperationId", "TechProcProd.Operation");
            DropForeignKey("dbo.RiggingOperations", "Rigging_RiggingId", "TechProcProd.Rigging");
            DropIndex("dbo.TechnologicalProcessesOperations", new[] { "Operation_OperationId" });
            DropIndex("dbo.TechnologicalProcessesOperations", new[] { "TechnologicalProcesses_TechProcId" });
            DropIndex("dbo.RiggingOperations", new[] { "Operation_OperationId" });
            DropIndex("dbo.RiggingOperations", new[] { "Rigging_RiggingId" });
            DropTable("dbo.TechnologicalProcessesOperations");
            DropTable("dbo.RiggingOperations");
            CreateIndex("TechProcProd.TechnologicalProcesses", "OperationId");
            CreateIndex("TechProcProd.Operation", "RiggingId");
            AddForeignKey("TechProcProd.TechnologicalProcesses", "OperationId", "TechProcProd.Operation", "OperationId", cascadeDelete: true);
            AddForeignKey("TechProcProd.Operation", "RiggingId", "TechProcProd.Rigging", "RiggingId", cascadeDelete: true);
        }
    }
}
