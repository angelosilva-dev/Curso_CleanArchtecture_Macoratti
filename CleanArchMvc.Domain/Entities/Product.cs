using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string  Image { get; private set; }

        //As propriedades abaixo são de navegação e nao podem ser setters privates
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido!");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        #region Validations
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido - O nome é de preenchimento obrigatório!");

            DomainExceptionValidation.When(name.Length < 3, "Nome inválido - O nome deve ter no minimo 3 caracteres!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição inválida - A descrição é de preenchimento obrigatório!");
            
            DomainExceptionValidation.When(description.Length < 5, "Descrição inválida - A descrição deve ter pelo menos 5 caracteres!");

            DomainExceptionValidation.When(price < 0, "Preço inválido!");

            DomainExceptionValidation.When(stock < 0, "Estoque inválido!");

            DomainExceptionValidation.When(image?.Length > 250, "Imagem muito longa. Permitido no máximo 250 caracteres!");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        #endregion
    }
}
