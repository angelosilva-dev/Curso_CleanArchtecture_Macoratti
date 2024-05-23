using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo nome é de preenchimento obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo nome deve ter entre 3 e 100 caracteres!")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é de preenchimento obrigatório!")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O campo descrição deve ter entre 5 e 100 caracteres!")]
        public string Description { get;  set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo preço é de preenchimento obrigatório!")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Estoque")]
        [Required(ErrorMessage = "O campo estoque é de preenchimento obrigatório!")]
        [Range(0, 9999, ErrorMessage ="O estoque deve ter o valor entre 0 e 9999")]
        public int Stock { get; set; }

        [Display(Name = "Imagem")]
        [MaxLength(250, ErrorMessage ="A imagem não deve ultrapassar 250 caracteres!")]
        public string Image { get; set; }

        [Display(Name="Categorias")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
