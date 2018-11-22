namespace ConsoleApp.Entity
{
    public class ProdutoPedido
    {
        public virtual int Codigo { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual decimal Quantidade { get; set; }
        public virtual decimal ValorUnitario { get; set; }
    }
}
