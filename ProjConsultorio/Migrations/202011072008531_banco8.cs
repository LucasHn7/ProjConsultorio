namespace ProjConsultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco8 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ManutUsers");
            AlterColumn("dbo.ManutUsers", "Usuario", c => c.String());
            AlterColumn("dbo.ManutUsers", "IdUsuario", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ManutUsers", "IdUsuario");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ManutUsers");
            AlterColumn("dbo.ManutUsers", "IdUsuario", c => c.Int(nullable: false));
            AlterColumn("dbo.ManutUsers", "Usuario", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ManutUsers", "Usuario");
        }
    }
}
