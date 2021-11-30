using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class TipoSistemaService : BaseService, ITipoSistemaService
    {
        private readonly ITipoSistemaRepository _tipoSistemaRepository;

        public TipoSistemaService(ITipoSistemaRepository tiposistemaRepository,
                          INotificador notificador) : base(notificador)
        {
            _tipoSistemaRepository = tiposistemaRepository;
        }

        public async Task<bool> Adicionar(TipoSistema tiposistema)
        {
            if (!ExecutarValidacao(new TipoSistemaValidation(), tiposistema)) return false;

            if (_tipoSistemaRepository.Buscar(f => f.NomeSistema == tiposistema.NomeSistema).Result.Any())
            {
                Notificar("Já existe um tipo de sistema informado.");
                return false;
            }

            await _tipoSistemaRepository.Adicionar(tiposistema);

            return true;
        }

        public async Task<bool> Atualizar(TipoSistema tiposistema)
        {
            if (!ExecutarValidacao(new TipoSistemaValidation(), tiposistema)) return false;

            if (_tipoSistemaRepository.Buscar(f => f.NomeSistema == tiposistema.NomeSistema && f.Id != tiposistema.Id).Result.Any())
            {
                Notificar("Já existe um tipo de sistema informado.");
                return false;
            }

            await _tipoSistemaRepository.Atualizar(tiposistema);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (!_tipoSistemaRepository.ObterTipoSistemaPorMaquina(id).Result.NomeSistema.Any())
            {
                Notificar("Não há informação de tipo de sistema cadastrado!");
                return false;
            }

            await _tipoSistemaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _tipoSistemaRepository?.Dispose();
        }
    }
}
