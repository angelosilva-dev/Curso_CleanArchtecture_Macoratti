using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é de preenchimento obrigatório!")]
        [StringLength(100,MinimumLength = 3, ErrorMessage = "O campo nome deve ter entre 3 e 100 caracteres!")]
        [Display(Name ="Nome")]
        public string Name { get; set; }
    }
}
