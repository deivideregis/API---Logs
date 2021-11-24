using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface IMaquinaRepository : IRepository<Maquina>
    {
        Task<Maquina> ObterMaquinaLog(Guid id);
    }
}
