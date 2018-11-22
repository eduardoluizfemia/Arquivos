using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Entity;
using FluentNHibernate.Mapping;

namespace ConsoleApp.Map
{
    /*
    CREATE TABLE [dbo].[Pedido] (
	    [Numero]		UNIQUEIDENTIFIER	NOT NULL
	    , [Emissao]		DATETIME			NOT NULL DEFAULT(GETDATE())
	    , [Tipo]		VARCHAR(50)			NOT NULL
	    , [Cliente_Cpf]	BIGINT				NOT NULL
	    , CONSTRAINT [PK_Pedido]
		    PRIMARY KEY ([Numero])
	    , CONSTRAINT [FK_Pedido_Cliente]
		    FOREIGN KEY ([Cliente_Cpf])
		    REFERENCES [dbo].[Cliente] ([Cpf])
    )
    GO
     */
    internal class PedidoMap : ClassMap<Pedido>
    {
        public PedidoMap()
        {
            Schema("dbo");
            Table("Pedido");

            Id(p => p.Numero, "Numero")
                .GeneratedBy.Guid();

            Map(p => p.Emissao, "Emissao")
                .Not.Nullable();

            Map(p => p.Tipo, "Tipo")
                .Not.Nullable()
                .CustomType<GenericEnumMapper<TipoPedido>>(); //Mapear o Enum 

            References(p => p.Cliente, "Cliente_Cpf")
                .Not.Nullable();

            HasMany(p => p.Produtos)
                .Cascade.SaveUpdate();
        }
    }
}
