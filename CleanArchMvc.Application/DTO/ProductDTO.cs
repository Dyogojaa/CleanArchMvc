using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é Requerido")]
        [MinLength(3, ErrorMessage = "O Tamanho minimo permitido é de 3 Caracteres")]
        [MaxLength(100, ErrorMessage = "O Tamanho máximo permitido é de 3 Caracteres")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A Descrição é Requerido")]
        [MinLength(5, ErrorMessage = "O Tamanho minimo permitido é de 5 Caracteres")]
        [MaxLength(200, ErrorMessage = "O Tamanho máximo permitido é de 200 Caracteres")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }


        [Required(ErrorMessage = "O Preço é Requerido")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [DataType(DataType.Currency)]        
        [Display(Name = "Preço")]
        public decimal Price { get;  set; }

        [Required(ErrorMessage = "O Estoque é Requerido")]
        [Range(1,9999)]
        [Display(Name = "Estoque")]
        public int Stock { get;  set; }

        [MaxLength(250, ErrorMessage = "O Tamanho máximo permitido é de 200 Caracteres")]
        [Display(Name = "Imagem do Produto")]
        public string Image { get;  set; }
        
        [Display(Name = "Categorias")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
    }
}
