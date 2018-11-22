using System;
using FluentNHibernate.Cfg;
using NHibernate;

namespace ConsoleApp
{
    public class NHibernateBuilder
    {
        private static NHibernateBuilder _instance;
        public static NHibernateBuilder Instance
        {
            get { return _instance ?? (_instance = new NHibernateBuilder()); }
        }

        public ISessionFactory SessionFactory { private set; get; }

        private NHibernateBuilder()
        {
            try
            {
                var nhConfig = Fluently.Configure()
                    .Mappings(ConfigureMappings)
                    .BuildConfiguration();
                SessionFactory = nhConfig.BuildSessionFactory();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
                throw;
            }
        }

        private void ConfigureMappings(MappingConfiguration map)
        {
            map.FluentMappings.AddFromAssemblyOf<NHibernateBuilder>();
        }
    }
}
