namespace ConsoleApp.Entity
{
    public class Email
    {
        public virtual int Codigo { get; set; }
        public virtual string Endereco { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
