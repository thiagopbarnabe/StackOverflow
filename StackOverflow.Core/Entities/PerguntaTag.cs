using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Core.Entities
{
    public class PerguntaTag
    {
        public int PerguntaTagId { get; set; }

        public int PerguntaId { get; set; }
        public Pergunta Pergunta { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
