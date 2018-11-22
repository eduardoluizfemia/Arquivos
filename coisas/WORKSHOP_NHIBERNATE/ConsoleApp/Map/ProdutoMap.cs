using ConsoleApp.Entity;
using FluentNHibernate.Mapping;

namespace ConsoleApp.Map
{
    /*
    CREATE TABLE [dbo].[Produto] (
	    [Codigo]					INTEGER			IDENTITY (1, 1)
	    , [Nome]					VARCHAR (255)	NOT NULL
	    , [UnidadeMedida_Codigo]	INT				NOT NULL
	    , [PrecoUnitario]			MONEY			NOT NULL
	    , [QuantidadeEstoque]		DECIMAL (10, 2) NOT NULL
	    , CONSTRAINT [PK_Produto]
		    PRIMARY KEY ([Codigo])
	    , CONSTRAINT [FK_Produto_UnidadeMedida]
		    FOREIGN KEY ([UnidadeMedida_Codigo])
		    REFERENCES [dbo].[UnidadeMedida] ([Codigo])
    )
    GO

    CREATE TABLE [dbo].[ProdutoCategoria] (
	    [Produto_Codigo]		INTEGER	NOT NULL
	    , [Categoria_Codigo]	INTEGER	NOT NULL
	    , CONSTRAINT [PK_ProdutoCategoria]
		    PRIMARY KEY ([Produto_Codigo], [Categoria_Codigo])
	    , CONSTRAINT [FK_ProdutoCategoria_Produto]
		    FOREIGN KEY ([Produto_Codigo])
		    REFERENCES [dbo].[Produto] ([Codigo])
	    , CONSTRAINT [FK_ProdutoCategoria_Categoria]
		    FOREIGN KEY ([Categoria_Codigo])
		    REFERENCES [dbo].[Categoria] ([Codigo])
    )
    GO
     */
    internal class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Schema("dbo");
            Table("Produto");

            Id(p => p.Codigo, "Codigo")
                .GeneratedBy.Identity();

            Map(p => p.Nome, "Nome")
                .Not.Nullable()
                .Length(255);

            Map(p => p.PrecoUnitario, "PrecoUnitario")
                .Not.Nullable()
                .CustomSqlType("MONEY");

            Map(p => p.QuantidadeEstoque, "QuantidadeEstoque")
                .Not.Nullable()
                .Precision(10)
                .Scale(2);
            //Verificar a propriedade que ele já pega do cache 
            //
            References(p => p.UnidadeMedida, "UnidadeMedida_Codigo")
                .Not.Nullable()
                .Fetch.Join();

            HasManyToMany(p => p.Categorias)
                .Table("ProdutoCategoria")
                .ParentKeyColumn("Produto_Codigo") // Chave da entidade que eu estou mapeando
                .ChildKeyColumn("Categoria_Codigo")
                .LazyLoad();

        }
    }
}
