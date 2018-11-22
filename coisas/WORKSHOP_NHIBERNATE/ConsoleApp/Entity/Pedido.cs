using System;
using System.Collections.Generic;

namespace ConsoleApp.Entity
{
    public class Pedido
    {
        public virtual Guid Numero { get; set; }
        public virtual DateTime Emissao { get; set; }
        public virtual TipoPedido Tipo { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual IList<ProdutoPedido> Produtos { get; set; }
    }
}
