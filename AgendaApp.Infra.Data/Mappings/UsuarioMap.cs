using AgendaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Usuário
    /// </summary>
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome).HasMaxLength(150).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();
            //Temos que colocar um tamanho de senha para caber a senha criptografada
            builder.Property(u => u.Senha).HasMaxLength(100).IsRequired(); 
            builder.Property(u => u.Ativo).IsRequired();

            //Todo campo que é índice é alguma coisa especial. Pesquisas feitas nesse campo são mais rápidas
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
