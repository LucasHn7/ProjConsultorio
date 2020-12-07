namespace ProjConsultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ManutUsers", "Nome", c => c.String());
            AddColumn("dbo.ManutUsers", "SegundoNome", c => c.String());
            AddColumn("dbo.ManutUsers", "Sobrenome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ManutUsers", "Sobrenome");
            DropColumn("dbo.ManutUsers", "SegundoNome");
            DropColumn("dbo.ManutUsers", "Nome");
        }
    }
}
