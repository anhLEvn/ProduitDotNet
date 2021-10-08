namespace CodeFirstFrameworkAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomSeason = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Produits", "SeasonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produits", "SeasonId");
            AddForeignKey("dbo.Produits", "SeasonId", "dbo.Seasons", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produits", "SeasonId", "dbo.Seasons");
            DropIndex("dbo.Produits", new[] { "SeasonId" });
            DropColumn("dbo.Produits", "SeasonId");
            DropTable("dbo.Seasons");
        }
    }
}
