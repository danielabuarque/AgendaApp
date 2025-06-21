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
    /// Classe de mapeamento para a entidade Tarefa
    /// </summary>
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Data).IsRequired();
            builder.Property(t => t.Hora).IsRequired();
            builder.Property(t => t.Prioridade).IsRequired();
            builder.Property(t => t.Ativo).IsRequired();

            builder.HasOne(t => t.Usuario) //Tarefa PERTENCE A 1 USUÁRIO
                .WithMany(u => u.Tarefas) //1 USUÁRIO POSSUI MUITAS TAREFAS
                .HasForeignKey(t => t.UsuarioId) //CHAVE ESTRANGEIRA DO relacionamento
                .OnDelete(DeleteBehavior.Restrict); //Só vai poder excluir um usuário se não houver tarefas associadas a ele, ou seja, não vai excluir em cascata as tarefas quando o usuário for excluído. Isso é importante para manter a integridade dos dados.
        }
    }
}
