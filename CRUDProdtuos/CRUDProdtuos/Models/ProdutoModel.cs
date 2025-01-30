using System.ComponentModel.DataAnnotations;

namespace CRUDProdtuos.Models
{
    public class ProdutoModel
    {
        
        public int Id { get; set; }

        
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do produto não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; }

        
        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double Preco { get; set; }

        
        [StringLength(500, ErrorMessage = "A descrição não pode ter mais que 500 caracteres.")]
        public string Descricao { get; set; }

       
        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
        public int Quantidade { get; set; }
    }
}