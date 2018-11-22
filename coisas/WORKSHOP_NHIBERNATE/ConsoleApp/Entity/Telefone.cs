namespace ConsoleApp.Entity
{
    public class Telefone
    {
        public virtual int Codigo { get; set; }
        public virtual string Numero { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
