using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade para usuário.
    /// </summary>
    public class Usuario
    {
        public required Guid Id { get; set; } = Guid.NewGuid();
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string  Senha { get; set; }
        public required bool Ativo { get; set; } = true;

        #region Relacionamentos
        public ICollection<Tarefa>? Tarefas { get; set; }

        #endregion
    }
}
