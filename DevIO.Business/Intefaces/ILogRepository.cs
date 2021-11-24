using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface ILogRepository : IRepository<Log>
    {
        Task<Log> ObterLogPorMaquina(Guid maquinaid);
    }
}
