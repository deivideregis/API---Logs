using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface ILogService : IDisposable
    {
        Task<bool> Adicionar(Log log);
        Task<bool> Atualizar(Log log);
        Task<bool> Remover(Guid id);
    }
}
