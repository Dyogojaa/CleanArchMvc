using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Teste de Validação da Criação de um Objeto Produto Valido")]
        public void CriacaoProduto_ComParametrosValidos_ResultadoObjetoComEstadoValido()
        {


            Action action = () => new Product("PlayStation 5", "VideoGame de Ultima Geração", 4000, 25, "PS5DIGITAL.JPG");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }


        [Fact(DisplayName = "Teste de Criação de Produto com Id Inválido ")]
        public void CriacaoProduto_ComIdNegativo_ResultadoExececaoIdInvalido()
        {

            Action action = () => new Product(-1, "PlayStation 5", "VideoGame de Ultima Geração", 4000, 25, "PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("ID Inválido!");

        }


        [Fact(DisplayName = "Teste de Criação de Produto com Nome Nulo ")]
        public void CriacaoProduto_ComNomeNulo_ResultadoExececaoNomeRequerido()
        {

            Action action = () => new Product( null, "VideoGame de Ultima Geração", 4000, 25, "PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome do Produto é Requirido!");

        }


        [Fact(DisplayName = "Teste de Criação de Produto com Nome em Branco ")]
        public void CriacaoProduto_ComNomeEmBranco_ResultadoExececaoNomeRequerido()
        {

            Action action = () => new Product("", "VideoGame de Ultima Geração", 4000, 25, "PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome do Produto é Requirido!");

        }

        [Fact(DisplayName = "Teste de Criação de Produto com Nome Menor que 3 Caracteres ")]
        public void CriacaoProduto_ComNomeMenor_ResultadoExececaoNomeMuitoCurto()
        {

            Action action = () => new Product("PS", "VideoGame de Ultima Geração", 4000, 25, "PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome não pode conter menos de 3 Caracteres");

        }


        [Fact(DisplayName = "Teste de Criação de Produto com Descricao em Branco ")]
        public void CriacaoProduto_ComDescricaoEmBranco_ResultadoExececaoDescricaoRequerida()
        {

            Action action = () => new Product("PS5", "", 4000, 25, "PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descriação do Produto Obrigatória!");

        }


        [Fact(DisplayName = "Teste de Criação de Produto com Descricao nula ")]
        public void CriacaoProduto_ComDescricaoNula_ResultadoExececaoDescricaoRequerida()
        {

            Action action = () => new Product("PS5", null, 4000, 25, "PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descriação do Produto Obrigatória!");

        }


        [Fact(DisplayName = "Teste de Criação de Produto com Descricao muita curta ")]
        public void CriacaoProduto_ComDescricaoMuitaCurta_ResultadoExececaoDescricaoMuitoCurta()
        {

            Action action = () => new Product("PS5", "TES", 4000, 25, "PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição não pode conter menos de 5 Caracteres");

        }


        [Theory(DisplayName = "Teste de Criação de Produto com Preço Inválido ")]
        [InlineData(-5)]
        [InlineData(-25)]
        public void CriacaoProduto_ComPrecoNegativo_ResultadoExececaoValorInvalido(decimal valor)
        {

            Action action = () => new Product("PS5", "Playstation Digital", valor, 25, "PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor do Produto é Inválido");

        }

        [Fact(DisplayName = "Teste de Criação de Produto com Estoque Inválido ")]
        public void CriacaoProduto_ComEstoqueNegativo_ResultadoExececaoValorInvalido()
        {

            Action action = () => new Product("PS5", "Playstation Digital", 10, -25, "PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Valor do Estoque é Inválido");

        }

        [Fact(DisplayName = "Teste de Criação de Produto nome Imagem Invalido ")]
        public void CriacaoProduto_ComImagemComTamanhoSuperior250_ResultadoExececaoNomeImageInvalido()
        {

            Action action = () => new Product("PS5", "Playstation Digital", 10, 10, "55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555PS5DIGITAL.JPG");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O Nome da Imagem não pode conter mais de 250 Caracteres");

        }


        [Fact(DisplayName = "Teste de Criação de Produto nome Imagem nulo ")]
        public void CriacaoProduto_ComImagemNula_ResultadoObjetoValido()
        {

            Action action = () => new Product("PS5", "Playstation Digital", 10, 10, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
                

        }

        [Fact(DisplayName = "Teste de Criação de Produto nome Imagem em Branco ")]
        public void CriacaoProduto_ComImagemEmBranco_ResultadoObjetoValido()
        {

            Action action = () => new Product("PS5", "Playstation Digital", 10, 10, "");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();


        }


        [Fact(DisplayName = "Teste de Criação de Produto nome Imagem nulo ")]
        public void CriacaoProduto_ComImagemNula_ResultadoSemExcecaoReferenciaNulo()
        {

            Action action = () => new Product("PS5", "Playstation Digital", 10, 10, null);
            action.Should()
                .NotThrow<NullReferenceException>();


        }




    }
}
