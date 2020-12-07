namespace ProjConsultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManuteUsers",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
        }
        
        public override void Down()
        { 
            DropTable("dbo.ManuteUsers");
        }
    }
}
