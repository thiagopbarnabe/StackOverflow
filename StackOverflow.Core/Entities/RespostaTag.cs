using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Core.Entities
{
    public class RespostaTag
    {
        public int RespostaTagId { get; set; }

        public int RespostaId { get; set; }
        public Resposta Resposta { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
