using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O Nome é Requerido")]
        [MinLength(3,ErrorMessage ="O Tamanho minimo permitido é de 3 Caracteres")]
        [MaxLength(100, ErrorMessage ="O Tamanho máximo permitido é de 3 Caracteres")]
        public string Name { get; set; }    
    }
}
