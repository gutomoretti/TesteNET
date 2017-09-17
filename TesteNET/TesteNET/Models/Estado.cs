using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteNET.Models
{
    [Table("fitcard.estado")]
    public class Estado
    {
        [Key]
        public int IDEstado { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public int IDPais { get; set; }

        public virtual Pais Pais { get; set; }
    }
}