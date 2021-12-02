using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface ITipoSistemaRepository : IRepository<TipoSistema>
    {
        Task<TipoSistema> ObterTipoSistemaPorMaquina(Guid maquinaid);
    }
}
