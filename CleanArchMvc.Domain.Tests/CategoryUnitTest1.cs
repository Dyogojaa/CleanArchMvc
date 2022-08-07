using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Teste de Validação de uma Categoria de Objeto Valido")]
        public void CriacaoCategoria_ComParametrosValidos_ResultadoObjetoComEstadoValido()
        {


            Action action = () => new Category(1, "Nome da Categoria");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Teste de Criação de Categoria com ID Inválido")]
        public void CriacaoCategoria_ComIdNegativo_ResultadoExececao()
        {


            Action action = () => new Category(-1, "Nome da Categori");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("ID Inválido!");

        }

        [Fact(DisplayName = "Teste de Criação de Categoria com Nome Curto")]
        public void CriacaoCategoria_ComNomeCurto_ResultadoExececaooNomeCurto()
        {

            Action action = () => new Category(1, "No");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome não pode conter menos de 3 Caracteres");

        }

        [Fact(DisplayName = "Teste de Criação de Categoria sem Informar NoME")]
        public void CriacaoCategoria_SemInformarNome_ResultadoExececaooNomeRequerido()
        {


            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome da Categoria é Requirido!");
        }

        [Fact(DisplayName = "Teste de Criação de Categoria Nome Nulo")]
        public void CriacaoCategoria_NomeNulo_ResultadoExececaooNomeRequerido()
        {


            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome da Categoria é Requirido!");

        }
    }
}