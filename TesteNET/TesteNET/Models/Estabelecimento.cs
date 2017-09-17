using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteNET.Models
{
    [Table("fitcard.estabelecimento")]
    public class Estabelecimento
    {
        [Key]
        public int IDEstabelecimento { get; set; }

        [Required(ErrorMessage = "O campo Categoria é obrigatório.")]
        [Display(Name = "Categoria")]
        public int IDCategoria { get; set; }

        [Required(ErrorMessage = "O campo Razão Social é obrigatório.")]
        [Display(Name = "Razão Social")]
        [StringLength(200, ErrorMessage = "O campo Razão Social deve ter no máximo 200 caracteres.")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        [StringLength(180, ErrorMessage = "O campo Nome Fantasia deve ter no máximo 180 caracteres.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(150, ErrorMessage = "O campo E-mail deve ter no máximo 150 caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        [StringLength(150, ErrorMessage = "O campo Endereço deve ter no máximo 150 caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [Display(Name = "Estado")]
        public int IDEstado { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [Display(Name = "Cidade")]
        public int IDCidade { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(20, ErrorMessage = "O campo Telefone deve ter no máximo 20 caracteres.")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        [Display(Name = "Ativo")]
        public bool Status { get; set; }

        public virtual Estado estado { get; set; }
        public virtual Cidade cidade { get; set; }
        public virtual Categoria categoria { get; set; }       

    }
}