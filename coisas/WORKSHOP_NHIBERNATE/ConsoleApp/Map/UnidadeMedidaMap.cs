using ConsoleApp.Entity;
using FluentNHibernate.Mapping;

namespace ConsoleApp.Map
{
    /*
    CREATE TABLE [dbo].[UnidadeMedida] (
        [Codigo]		INTEGER			IDENTITY (1, 1)
        , [Descricao]	VARCHAR (50)	NOT NULL
        , [Sigla]		VARCHAR (10)	NOT NULL
        , CONSTRAINT [PK_UnidadeMedida]
            PRIMARY KEY ([Codigo])
    )
    GO
     */
    internal class UnidadeMedidaMap : ClassMap<UnidadeMedida>
    {
        public UnidadeMedidaMap()
        {
            Schema("dbo");
            Table("UnidadeMedida");

            Id(u => u.Codigo, "Codigo")
                .GeneratedBy.Identity();

            Map(u => u.Descricao, "Descricao")
                .Not.Nullable()
                .Length(50);

            Map(u => u.Sigla, "Sigla")
                .Not.Nullable()
                .Length(10);
        }
    }
}
