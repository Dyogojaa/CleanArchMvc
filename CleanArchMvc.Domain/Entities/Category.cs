using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : Entity
{       
    
    public string Name { get; private set; }

    public ICollection<Product> Products { get; set; }


    public void Update(string name)
    {
        ValidateDomain(name);
    }

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "ID Inválido!");
        Id = id;
        ValidateDomain(name);
    }

    public Category(string name)
    {
        ValidateDomain(name);            
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Nome da Categoria é Requirido!");

        DomainExceptionValidation.When(name.Length <3 ,
           "Nome não pode conter menos de 3 Caracteres");

        Name = name;
    }
}
