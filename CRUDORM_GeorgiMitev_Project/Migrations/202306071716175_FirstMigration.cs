namespace CRUDORM_GeorgiMitev_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        AnimalType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalType_Id)
                .Index(t => t.AnimalType_Id);
            
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "AnimalType_Id", "dbo.AnimalTypes");
            DropIndex("dbo.Animals", new[] { "AnimalType_Id" });
            DropTable("dbo.AnimalTypes");
            DropTable("dbo.Animals");
        }
    }
}
