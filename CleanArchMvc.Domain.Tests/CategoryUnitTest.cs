using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName ="Criar categoria com estado valido")]
        //Teste de unidade para validar parametros validos para o dominio Category
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "CategoryName");
            //Ao executar o teste, n�o dever� lan�ar uma exce��o.
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar categoria com id negativo")]
        //Teste de unidade para validar se o id do dominio Category � negativo
        public void CreateCategory_NegativeValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "CategoryName");
            //Ao executar o teste, dever� lan�ar exce��o retornando mensagem.
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Id invalido!");
        }


        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Nome inv�lido - O nome deve ter no minimo 3 caracteres!");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inv�lido - O nome � de preenchimento obrigat�rio!");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}