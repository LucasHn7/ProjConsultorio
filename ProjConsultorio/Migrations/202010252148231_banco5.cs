namespace ProjConsultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicos", "CEP", c => c.String());
            AddColumn("dbo.Medicos", "Rua", c => c.String());
            AddColumn("dbo.Medicos", "Bairro", c => c.String());
            AddColumn("dbo.Medicos", "Cidade", c => c.String());
            AddColumn("dbo.Medicos", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicos", "Estado");
            DropColumn("dbo.Medicos", "Cidade");
            DropColumn("dbo.Medicos", "Bairro");
            DropColumn("dbo.Medicos", "Rua");
            DropColumn("dbo.Medicos", "CEP");
        }
    }
}
