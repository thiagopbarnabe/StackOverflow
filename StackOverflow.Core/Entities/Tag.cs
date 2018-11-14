using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Core.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Nome { get; set; }

        public List<PerguntaTag> PerguntaTags { get; set; }
        public List<RespostaTag> RespostaTags { get; set; }
    }
}
