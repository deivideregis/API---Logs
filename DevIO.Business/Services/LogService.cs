using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class LogService : BaseService, ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository,
                          INotificador notificador) : base(notificador)
        {
            _logRepository = logRepository;
        }

        public async Task<bool> Adicionar(Log log)
        {
            if (!ExecutarValidacao(new LogValidation(), log)) return false;

            if (_logRepository.Buscar(f => f.Detalhe == log.Detalhe).Result.Any())
            {
                Notificar("Já existe um log de informação.");
                return false;
            }

            await _logRepository.Adicionar(log);

            return true;
        }

        public async Task<bool> Atualizar(Log log)
        {
            if (!ExecutarValidacao(new LogValidation(), log)) return false;

            if (_logRepository.Buscar(f => f.Detalhe == log.Detalhe && f.Id != log.Id).Result.Any())
            {
                Notificar("Já existe um log de informação.");
                return false;
            }

            await _logRepository.Atualizar(log);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (!_logRepository.ObterLogPorMaquina(id).Result.Detalhe.Any())
            {
                Notificar("Não há informação de log cadastrado!");
                return false;
            }

            await _logRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _logRepository?.Dispose();
        }
    }
}
