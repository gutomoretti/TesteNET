using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteNET.Models
{
    [Table("fitcard.pais")]
    public class Pais
    {
        [Key]
        public int IDPais { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }

    }
}