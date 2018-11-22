using ConsoleApp.Entity;
using FluentNHibernate.Mapping;

namespace ConsoleApp.Map
{
    /*
    CREATE TABLE [dbo].[Cliente] (
	    [Cpf]			BIGINT			NOT NULL
	    , [Nome]		VARCHAR (100)	NOT NULL
	    , [Sobrenome]	VARCHAR (100)	NOT NULL
	    , [Nascimento]	DATE			NOT NULL
	    , [Idade]		AS (
						    DATEDIFF(YEAR, [Nascimento], GETDATE())
						     - CASE
							    WHEN DATEPART(DAYOFYEAR, GETDATE()) < DATEPART(DAYOFYEAR, [Nascimento])
								    THEN 1
								    ELSE 0
						    END)
	    , CONSTRAINT [PK_Cliente]
		    PRIMARY KEY ([Cpf])
    )
    GO

    CREATE TABLE [dbo].[Telefone] (
	    [Cliente_Cpf]	BIGINT			NOT NULL
	    , [Indice]		INTEGER			NOT NULL
	    , [Numero]		VARCHAR (20)	NOT NULL
	    , CONSTRAINT [PK_Telefone]
		    PRIMARY KEY ([Cliente_Cpf], [Indice])
	    , CONSTRAINT [FK_Telefone_Cliente]
		    FOREIGN KEY ([Cliente_Cpf])
		    REFERENCES [dbo].[Cliente] ([Cpf])
    )
    GO
     */
    internal class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Schema("dbo");
            Table("Cliente");

            Id(c => c.Cpf, "Cpf")
                .GeneratedBy.Assigned(); //Aplicação que cria a chave

            Map(c => c.Nome, "Nome")
                .Not.Nullable()
                .Length(100);

            Map(c => c.Sobrenome, "Sobrenome")
                .Not.Nullable()
                .Length(100);

            Map(c => c.Nascimento, "Nascimento")
                .Not.Nullable()
                .CustomSqlType("DATE"); //Para não mapear como datetime

            Map(c => c.Idade, "Idade")
                .Generated.Always()
                .ReadOnly();//Coluna computada o sql irá gerar assim o Nhibernate deve ignorar

            HasMany(c => c.Emails)
                .AsSet()
                .Cascade.SaveUpdate(); //Mostrar o funcionamento do email

            
            HasMany(c => c.Telefones)
                .Table("Telefone")
                .KeyColumn("Cliente_Cpf") //chave para cliente
                .Element("Numero") //a string que está na lista
                .AsList(x => x.Column("Indice")) //quem é o indice na minha lista 
                .Not.LazyLoad()
                .Cascade.SaveUpdate();

            HasOne(c => c.Fidelidade)
                .PropertyRef(p => p.Cliente);
        }
    }
}
