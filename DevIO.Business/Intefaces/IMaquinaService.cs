using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface IMaquinaService : IDisposable
    {
        Task<bool> Adicionar(Maquina maquina);
        Task<bool> Atualizar(Maquina maquina);
        Task<bool> Remover(Guid id);

        Task AtualizarLog(Log log);
    }
}
