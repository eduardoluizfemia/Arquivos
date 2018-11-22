using ConsoleApp.Entity;
using NHibernate;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            log4net.Config.XmlConfigurator.Configure();

            var sessionFactory = NHibernateBuilder.Instance.SessionFactory;

            //using (var session = sessionFactory.OpenSession())
            //{

            //    var query = session.QueryOver<Produto>();
            //    var lista = query.List();  
            //}

            using (var session = sessionFactory.OpenSession())
            {
                string hql = "select p from Pedido as p" +
                        " inner join PedidoProduto as pp " + 
                        " on p.Codigo == pp.Pedido ";
                IQuery query = session.CreateQuery(hql);
                var produtosPedidos = query.List();
            }
              
        }
    }
}
