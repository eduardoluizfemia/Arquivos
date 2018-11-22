namespace ConsoleApp.Entity
{
    public class Comentario
    {
        public virtual int Codigo { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual Postagem Postagem { get; set; }
    }
}
