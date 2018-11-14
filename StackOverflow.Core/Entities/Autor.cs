using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Core.Entities
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public List<Pergunta> Perguntas { get; set; }
        public List<Resposta> Respostas { get; set; }

    }
}
