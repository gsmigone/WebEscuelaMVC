namespace WebEscuelaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aulas",
                c => new
                    {
                        AulaId = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AulaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Aulas");
        }
    }
}
