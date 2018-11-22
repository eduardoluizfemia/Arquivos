using System;
using System.Collections.Generic;

namespace ConsoleApp.Entity
{
    public class Cliente
    {
        public virtual long Cpf { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual DateTime Nascimento { get; set; }
        public virtual int Idade { get; set; }
        public virtual PerfilFidelidade Fidelidade { get; set; }

        public virtual IList<string> Telefones { get; set; }
        public virtual ISet<Email> Emails { get; set; }
    }
}
