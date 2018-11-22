using ConsoleApp.Entity;
using FluentNHibernate.Mapping;

namespace ConsoleApp.Map
{
    /*
    CREATE TABLE [dbo].[PerfilFidelidade] (
	    [Cliente_Cpf]	BIGINT	NOT NULL
	    , [Pontuacao]	INTEGER	NOT NULL
	    , [Nivel]		TINYINT	NOT NULL
	    , CONSTRAINT [PK_PerfilFideliddade]
		    PRIMARY KEY ([Cliente_Cpf])
	    , CONSTRAINT [FK_PerfilFideliddade_Cliente]
		    FOREIGN KEY ([Cliente_Cpf])
		    REFERENCES [dbo].[Cliente] ([Cpf])
    )
    GO
     */
    internal class PerfilFidelidadeMap : ClassMap<PerfilFidelidade>
    {
        public PerfilFidelidadeMap()
        {
            Schema("dbo");
            Table("PerfilFidelidade");

            Id(p => p.Cliente.Cpf, "Cliente_Cpf")
                .GeneratedBy.Foreign("Cliente"); //informa que é gerada por outra tabela 

            Map(p => p.Pontuacao, "Pontuacao")
                .Not.Nullable();

            Map(p => p.Nivel, "Nivel")
                .Not.Nullable()
                .CustomType<short>(); //Fala o custom type do Enum

            HasOne(p => p.Cliente);
        }
    }
}
