using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : BaseEntity
    {        
        public string Name { get; private set; }

        public ICollection<Product> Products{ get; set; }

        #region Constructor
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id invalido!");
            Id = id;
            ValidateDomain(name);
        }

        #endregion

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        #region Validations
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido - O nome é de preenchimento obrigatório!");

            DomainExceptionValidation.When(name.Length < 3, "Nome inválido - O nome deve ter no minimo 3 caracteres!");

            Name = name;
        }
        #endregion
    }
}
