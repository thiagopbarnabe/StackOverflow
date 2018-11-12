using System;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Web.Models
{
    public class PerguntaViewModel
    {
        [ScaffoldColumn(false)]
        public int PerguntaId { get; set; }

        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }

        public int AutorId { get; set; }
    }
}
