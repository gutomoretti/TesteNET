using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteNET.Models
{
    [Table("fitcard.categoria")]
    public class Categoria
    {
        [Key]
        public int IDCategoria { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Ativo")]
        public bool Status { get; set; }

    }
}