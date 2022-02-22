using System.ComponentModel.DataAnnotations;

namespace Cadastro.Domain.Entities
{
    public class Product : BaseModel
    {
        public string Nome { get; set; }
        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
    }
}