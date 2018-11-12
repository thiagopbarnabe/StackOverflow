using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.Web.Models
{
    public class RespostaViewModel
    {
        public string Autor { get; set; }
        public string Publicacao { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
