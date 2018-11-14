using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StackOverflow.Core.Entities
{
    public class Pergunta
    {
        public int PerguntaId { get; set; }
        public string Titulo { get; set; }
        public List<Tag> Tags { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        [DisplayName("Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public List<Resposta> Respostas { get; set; }
        public List<PerguntaTag> PerguntaTags { get; set; }
        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
