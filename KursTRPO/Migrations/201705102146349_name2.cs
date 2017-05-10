namespace KursTRPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TechProcProd.Equipment",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false, identity: true),
                        DetailNumber = c.Int(nullable: false),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.EquipmentId);
            
            CreateTable(
                "TechProcProd.Operation",
                c => new
                    {
                        OperationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        TransitionId = c.Int(nullable: false),
                        TransitionName = c.String(),
                        EquipmentId = c.Int(nullable: false),
                        RiggingId = c.Int(nullable: false),
                        DepartmentNumber = c.Int(nullable: false),
                        SiteNumber = c.Int(nullable: false),
                        WorkplaceNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OperationId)
                .ForeignKey("TechProcProd.Equipment", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("TechProcProd.Rigging", t => t.RiggingId, cascadeDelete: true)
                .ForeignKey("TechProcProd.Transition", t => t.TransitionId, cascadeDelete: true)
                .Index(t => t.TransitionId)
                .Index(t => t.EquipmentId)
                .Index(t => t.RiggingId);
            
            CreateTable(
                "TechProcProd.Rigging",
                c => new
                    {
                        RiggingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeOfTool = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RiggingId);
            
            CreateTable(
                "TechProcProd.TechnologicalProcesses",
                c => new
                    {
                        TechProcId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OperationId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        TypeByExecution = c.String(),
                        ActNumber = c.Int(nullable: false),
                        DateStartTechProc = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.TechProcId)
                .ForeignKey("TechProcProd.Material", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("TechProcProd.Operation", t => t.OperationId, cascadeDelete: true)
                .Index(t => t.OperationId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "TechProcProd.Material",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Assortment = c.String(),
                        Name = c.String(),
                        Stamp = c.String(),
                        DesignOfStandard = c.String(),
                    })
                .PrimaryKey(t => t.MaterialId);
            
            CreateTable(
                "TechProcProd.Route",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        TechProcId = c.Int(nullable: false),
                        NameTechProc = c.String(),
                        NameOfDeveloper = c.Int(nullable: false),
                        DetailsDesignation = c.String(),
                        DetailsName = c.String(),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("TechProcProd.TechnologicalProcesses", t => t.TechProcId, cascadeDelete: true)
                .Index(t => t.TechProcId);
            
            CreateTable(
                "TechProcProd.RouteCar",
                c => new
                    {
                        RouteCarId = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Developer = c.Int(nullable: false),
                        Checked = c.Int(nullable: false),
                        Agreed = c.Int(nullable: false),
                        Approved = c.Int(nullable: false),
                        NormСontroller = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteCarId)
                .ForeignKey("TechProcProd.Route", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId);
            
            CreateTable(
                "TechProcProd.Transition",
                c => new
                    {
                        TransitionId = c.Int(nullable: false, identity: true),
                        TransitionNumber = c.Int(nullable: false),
                        Keyword = c.String(),
                        TransitionType = c.String(),
                    })
                .PrimaryKey(t => t.TransitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("TechProcProd.Operation", "TransitionId", "TechProcProd.Transition");
            DropForeignKey("TechProcProd.Route", "TechProcId", "TechProcProd.TechnologicalProcesses");
            DropForeignKey("TechProcProd.RouteCar", "RouteId", "TechProcProd.Route");
            DropForeignKey("TechProcProd.TechnologicalProcesses", "OperationId", "TechProcProd.Operation");
            DropForeignKey("TechProcProd.TechnologicalProcesses", "MaterialId", "TechProcProd.Material");
            DropForeignKey("TechProcProd.Operation", "RiggingId", "TechProcProd.Rigging");
            DropForeignKey("TechProcProd.Operation", "EquipmentId", "TechProcProd.Equipment");
            DropIndex("TechProcProd.RouteCar", new[] { "RouteId" });
            DropIndex("TechProcProd.Route", new[] { "TechProcId" });
            DropIndex("TechProcProd.TechnologicalProcesses", new[] { "MaterialId" });
            DropIndex("TechProcProd.TechnologicalProcesses", new[] { "OperationId" });
            DropIndex("TechProcProd.Operation", new[] { "RiggingId" });
            DropIndex("TechProcProd.Operation", new[] { "EquipmentId" });
            DropIndex("TechProcProd.Operation", new[] { "TransitionId" });
            DropTable("TechProcProd.Transition");
            DropTable("TechProcProd.RouteCar");
            DropTable("TechProcProd.Route");
            DropTable("TechProcProd.Material");
            DropTable("TechProcProd.TechnologicalProcesses");
            DropTable("TechProcProd.Rigging");
            DropTable("TechProcProd.Operation");
            DropTable("TechProcProd.Equipment");
        }
    }
}
