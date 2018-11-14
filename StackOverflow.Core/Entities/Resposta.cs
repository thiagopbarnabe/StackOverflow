using StackOverflow.Core.Entities;
using System;
using System.Collections.Generic;

namespace StackOverflow.Core.Entities
{
    public class Resposta
    {
        public int RespostaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; }


        public Pergunta Pergunta { get; set; }
        public int? PerguntaId { get; set; }

        public List<RespostaTag> RespostaTags { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
