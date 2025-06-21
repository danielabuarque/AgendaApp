using AgendaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade para tarefa.
    /// </summary>
    public class Tarefa
    {
        public required Guid Id { get; set; } = Guid.NewGuid();
        public required string Nome { get; set; }
        public required DateOnly Data { get; set; }
        public required TimeSpan Hora { get; set; }
        public required Prioridades Prioridade { get; set; }
        public required Guid UsuarioId { get; set; }
        public required bool Ativo { get; set; } = true;

        #region Relacionamentos
        public required Usuario Usuario { get; set; }
        #endregion
    }
}
