namespace CRUDORM_GeorgiMitev_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
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
                    AnimalTypeId = c.Int(nullable: false),

                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalTypeId, cascadeDelete: true)
                .Index(t => t.AnimalTypeId);

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
            DropForeignKey("dbo.Animals", "AnimalTypeId", "dbo.AnimalTypes");
            DropIndex("dbo.Animals", new[] { "AnimalTypeId" });
            DropTable("dbo.AnimalTypes");
            DropTable("dbo.Animals");
        }
    }
}
