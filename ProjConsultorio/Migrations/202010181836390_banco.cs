namespace ProjConsultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        IdConsulta = c.Int(nullable: false, identity: true),
                        IdPaciente = c.Int(nullable: false),
                        IdMedico = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Valor = c.Double(nullable: false),
                        Diagnostico = c.String(),
                        Exame = c.String(),
                    })
                .PrimaryKey(t => t.IdConsulta)
                .ForeignKey("dbo.Medicos", t => t.IdMedico, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.IdPaciente, cascadeDelete: true)
                .Index(t => t.IdPaciente)
                .Index(t => t.IdMedico);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        IdMedico = c.Int(nullable: false, identity: true),
                        IdEspecialidade = c.Int(nullable: false),
                        Nome = c.String(),
                        Endereco = c.String(),
                        Telefone = c.String(),
                        CPF = c.String(),
                    })
                .PrimaryKey(t => t.IdMedico)
                .ForeignKey("dbo.Especialidads", t => t.IdEspecialidade, cascadeDelete: true)
                .Index(t => t.IdEspecialidade);
            
            CreateTable(
                "dbo.Especialidads",
                c => new
                    {
                        IdEspecialidade = c.Int(nullable: false, identity: true),
                        Especialidade = c.String(),
                    })
                .PrimaryKey(t => t.IdEspecialidade);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        IdPaciente = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                        Telefone = c.String(),
                        CPF = c.String(),
                        Convenio = c.String(),
                        Plano = c.String(),
                        NumCartao = c.String(),
                    })
                .PrimaryKey(t => t.IdPaciente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "IdPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.Consultas", "IdMedico", "dbo.Medicos");
            DropForeignKey("dbo.Medicos", "IdEspecialidade", "dbo.Especialidads");
            DropIndex("dbo.Medicos", new[] { "IdEspecialidade" });
            DropIndex("dbo.Consultas", new[] { "IdMedico" });
            DropIndex("dbo.Consultas", new[] { "IdPaciente" });
            DropTable("dbo.Pacientes");
            DropTable("dbo.Especialidads");
            DropTable("dbo.Medicos");
            DropTable("dbo.Consultas");
        }
    }
}
