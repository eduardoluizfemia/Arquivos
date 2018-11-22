namespace ConsoleApp.Entity
{
    public class PerfilFidelidade
    {
        public virtual long Cpf
        {
            get { return Cliente == null ? 0 : Cliente.Cpf; }
            set { }
        }

        public virtual Cliente Cliente { get; set; }
        public virtual int Pontuacao { get; set; }
        public virtual NivelFidelidade Nivel { get; set; }
    }
}
