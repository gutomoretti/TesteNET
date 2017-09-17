using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteNET.Models
{
    [Table("fitcard.cidade")]
    public class Cidade
    {
        [Key]
        public int IDCidade { get; set; }
        public string nome { get; set; }
        public int IDEstado { get; set; }

        public virtual Estado Estado { get; set; }
    }

    public class cidadelista
    {
        public int IDCidade { get; set; }
        public string Nome { get; set; }
    }
}