using StackOverflow.Core.Entities;
using System;

namespace StackOverflow.Core.Entities
{
    public class Resposta
    {
        public int RespostaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }

        public int AutorId { get; set; }

        public Pergunta ObjPergunta { get; set; }
        public int PerguntaId { get; set; }
    }
}
