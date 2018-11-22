using System.Collections.Generic;

namespace ConsoleApp.Entity
{
    public class Postagem
    {
        public virtual int Codigo { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual IList<Comentario> Comentarios { get; set; }
    }
}
