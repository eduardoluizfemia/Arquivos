using ConsoleApp.Entity;
using FluentNHibernate.Mapping;

namespace ConsoleApp.Map
{
    /*
    CREATE TABLE [dbo].[Email] (
	    [Codigo]		INTEGER			IDENTITY(1, 1)
	    , [Cliente_Cpf]	BIGINT			NOT NULL
	    , [Endereco]	VARCHAR (255)	NOT NULL
	    , CONSTRAINT [PK_Email]
		    PRIMARY KEY ([Codigo])
	    , CONSTRAINT [FK_Email_Cliente]
		    FOREIGN KEY ([Cliente_Cpf])
		    REFERENCES [dbo].[Cliente] ([Cpf])
    )
    GO
     */
    internal class EmailMap : ClassMap<Email>
    {
        public EmailMap()
        {
            Schema("dbo");
            Table("Email");

            Id(e => e.Codigo, "Codigo")
                .GeneratedBy.Identity();

            Map(e => e.Endereco, "Endereco")
                .Not.Nullable()
                .Length(255);

            References(e => e.Cliente, "Cliente_Cpf")
                .Not.Nullable();
        }
    }
}
