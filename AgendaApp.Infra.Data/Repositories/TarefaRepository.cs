using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Repositories
{
    /// <summary>
    /// Implementação do repositório de tarefas
    /// </summary>
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext _dataContext;

        //Método construtor utilizado para injeção de dependência
        public TarefaRepository(DataContext dataContext)
        {
            _dataContext=dataContext;
        }

        public void Add(Tarefa tarefa)
        {
            _dataContext.Add(tarefa);
            _dataContext.SaveChanges();
        }

        public void Update(Tarefa tarefa)
        {
            _dataContext.Update(tarefa);
            _dataContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var tarefa = _dataContext.Set<Tarefa>().Find(id);

            //Condição de segurança (if me protege de erros)
            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada.");

            tarefa.Ativo = false; //Desativa a tarefa ao invés de excluir do banco

            _dataContext.Update(tarefa);
            _dataContext.SaveChanges();
        }

        public List<Tarefa>? FindAll(DateOnly dataMin, DateOnly dataMax, Guid usuarioId)
        {
           return _dataContext.Set<Tarefa>()
                              .Where(t => t.Ativo && t.Data >= dataMin && t.Data <= dataMax && t.UsuarioId == usuarioId)
                              .OrderByDescending(t => t.Data)
                              .ToList();
        }

        public Tarefa? FindById(Guid id, Guid usuarioId)
        {
            return _dataContext.Set<Tarefa>()
                               .Where(t => t.Ativo && t.Id == id && t.UsuarioId == usuarioId)
                               .SingleOrDefault();
        }
    }
}
