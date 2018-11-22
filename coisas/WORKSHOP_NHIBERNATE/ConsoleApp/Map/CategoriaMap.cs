using ConsoleApp.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Map
{
    internal class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Schema("dbo");

            Table("Categoria");

            Id(c => c.Codigo, "Codigo")
                .GeneratedBy.Identity();

            Map(c => c.Nome,"Nome")
                .Length(100)
                .Not.Nullable();
        }
    }
}
