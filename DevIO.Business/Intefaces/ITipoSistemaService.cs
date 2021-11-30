using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface ITipoSistemaService : IDisposable
    {
        Task<bool> Adicionar(TipoSistema tipoSistema);
        Task<bool> Atualizar(TipoSistema tipoSistema);
        Task<bool> Remover(Guid id);
    }
}
