using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {           
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }


        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "ID Inválido!");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }


        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome do Produto é Requirido!");

            DomainExceptionValidation.When(name.Length < 3,
               "Nome não pode conter menos de 3 Caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Descriação do Produto Obrigatória!");

            DomainExceptionValidation.When(description.Length < 5,
               "Descrição não pode conter menos de 5 Caracteres");

            DomainExceptionValidation.When(price < 0,
               "Valor do Produto é Inválido");

            DomainExceptionValidation.When(stock < 0,
               "Valor do Estoque é Inválido");

            //Como na Regra de negocio permitimos a Imagem Nula
            //Se não utilizar o Operador ? o sistema irá lançar a Execeção
            //De Ojeto nulo e irá quebrar o Código ao tentar efetuar a Expresão para 
            //Verificar o tamanho da Imagem
            DomainExceptionValidation.When(image?.Length > 250,
               "O Nome da Imagem não pode conter mais de 250 Caracteres");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;  
            Image = image;  

        }

        public int CategoryId { get;  set; }
        public Category Category { get;  set; }

    }
}
