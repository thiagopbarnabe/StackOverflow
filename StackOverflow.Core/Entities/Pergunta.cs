using System;

namespace StackOverflow.Core.Entities
{
    public class Pergunta
    {
        public int PerguntaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }

        public int AutorId { get; set; }
    }
}
