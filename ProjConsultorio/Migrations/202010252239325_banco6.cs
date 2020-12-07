namespace ProjConsultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicos", "Endereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicos", "Endereco", c => c.String());
        }
    }
}
