using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Contrato de métodos para o nosso repositório de usuário 
    /// </summary>
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);
        Usuario? Find(Guid id);
        Usuario? Find(string email, string senha);
        bool Any(string email); //Método que verifica que se um email já está cadastrado no banco
    }
}
