using System.Collections.Generic;

namespace ConsoleApp.Entity
{
    public class Produto
    {
        public virtual int Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual decimal PrecoUnitario { get; set; }
        public virtual decimal QuantidadeEstoque { get; set; }
        public virtual UnidadeMedida UnidadeMedida { get; set; }
        public virtual IList<Categoria> Categorias { get; set; }
    }
}
