using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Core.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public List<Pergunta> Perguntas { get; set; }
        public List<Resposta> Respostas { get; set; }
    }
}
