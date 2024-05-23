using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    //Classe da FluentApi para definir as precisões dos tipos de dados que serão criados no banco de dados
    //Ao aplicar as migrations do entity framework, será seguido as regras configuradas aqui.
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
              new Category(1, "Material Escolar"),
              new Category(2, "Eletrônicos"),
               new Category(3, "Acessórios")
            );
        }
    }
}
