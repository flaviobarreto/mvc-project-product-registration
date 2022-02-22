using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace Cadastro.ViewModels
{
    public class ProductViewModels
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Nome { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O produto é requerido.")]
        public string Produto{ get; set; }
        
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        public string Valor { get; set; }

        [Display(Name = "Disponivel")]
        public bool Status { get; set; }
    }
}