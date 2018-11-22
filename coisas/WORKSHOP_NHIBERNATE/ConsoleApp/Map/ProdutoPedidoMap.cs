using ConsoleApp.Entity;
using FluentNHibernate.Mapping;

namespace ConsoleApp.Map
{
    /*
    CREATE TABLE [dbo].[ProdutoPedido] (
	    [Codigo]			INTEGER				IDENTITY (1, 1)
	    , [Pedido_Numero]	UNIQUEIDENTIFIER	NOT NULL
	    , [Produto_Codigo]	INTEGER				NOT NULL
	    , [Quantidade]		DECIMAL (10, 2)     NOT NULL
	    , [ValorUnitario]	MONEY				NOT NULL
	    , CONSTRAINT [PK_ProdutoPedido]
		    PRIMARY KEY ([Codigo])
	    , CONSTRAINT [FK_ProdutoPedido_Pedido]
		    FOREIGN KEY ([Pedido_Numero])
		    REFERENCES [dbo].[Pedido] ([Numero])
	    , CONSTRAINT [FK_ProdutoPedido_Produto]
		    FOREIGN KEY ([Produto_Codigo])
		    REFERENCES [dbo].[Produto] ([Codigo])
    )
    GO
     */
    internal class ProdutoPedidoMap : ClassMap<ProdutoPedido>
    {
        public ProdutoPedidoMap()
        {
            Schema("dbo");
            Table("ProdutoPedido");

            Id(p => p.Codigo, "Codigo")
                .GeneratedBy.Identity();

            Map(p => p.Quantidade, "Quantidade")
                .Not.Nullable()
                .Precision(10)
                .Scale(2);

            Map(p => p.ValorUnitario, "ValorUnitario")
                .Not.Nullable()
                .CustomSqlType("MONEY");

            References(p => p.Pedido, "Pedido_Numero")
                .Not.Nullable();

            References(p => p.Produto, "Produto_Codigo")
                .Not.Nullable();
        }
    }
}
