namespace ProjConsultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManutUsers",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
            DropTable("dbo.ManuteUsers");
        }
        
        public override void Down()
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
            
            DropTable("dbo.ManutUsers");
        }
    }
}
