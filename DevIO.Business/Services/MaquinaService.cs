using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class MaquinaService : BaseService, IMaquinaService
    {
        private readonly IMaquinaRepository _maquinaRepository;
        private readonly ILogRepository _logRepository;

        public MaquinaService(IMaquinaRepository maquinaRepository,
                              ILogRepository logRepository,
                              INotificador notificador) : base(notificador)
        {
            _maquinaRepository = maquinaRepository;
            _logRepository = logRepository;
        }

        public async Task<bool> Adicionar(Maquina maquina)
        {
            if (!ExecutarValidacao(new MaquinaValidation(), maquina)) return false;

            if (_maquinaRepository.Buscar(f => f.NomeMaquina == maquina.NomeMaquina).Result.Any())
            {
                Notificar("Já existe uma máquina informado.");
                return false;
            }

            if (_maquinaRepository.Buscar(f => f.IP == maquina.IP).Result.Any())
            {
                Notificar("Já existe um IP informado.");
                return false;
            }

            if (_maquinaRepository.Buscar(f => f.MAC == maquina.MAC).Result.Any())
            {
                Notificar("Já existe um MAC informado.");
                return false;
            }

            await _maquinaRepository.Adicionar(maquina);

            return true;
        }

        public async Task<bool> Atualizar(Maquina maquina)
        {
            if (!ExecutarValidacao(new MaquinaValidation(), maquina)) return false;

            if (_maquinaRepository.Buscar(f => f.NomeMaquina == maquina.NomeMaquina && f.Id != maquina.Id).Result.Any())
            {
                Notificar("Já existe uma máquina infomado.");
                return false;
            }

            else if (_maquinaRepository.Buscar(f => f.IP == maquina.IP && f.Id != maquina.Id).Result.Any())
            {
                Notificar("Já existe um IP infomado.");
                return false;
            }

            else if (_maquinaRepository.Buscar(f => f.IP == maquina.MAC && f.Id != maquina.Id).Result.Any())
            {
                Notificar("Já existe um MAC infomado.");
                return false;
            }

            await _maquinaRepository.Atualizar(maquina);
            return true;
        }

        public async Task AtualizarLog(Log log)
        {
            if (!ExecutarValidacao(new LogValidation(), log)) return;

            await _logRepository.Atualizar(log);
        }

        public async Task<bool> Remover(Guid id)
        {
            if (!_maquinaRepository.ObterMaquinaLog(id).Result.NomeMaquina.Any())
            {
                Notificar("Não há informação de máquina cadastrados!");
                return false;
            }

            await _maquinaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _maquinaRepository?.Dispose();
            _logRepository?.Dispose();
        }
    }
}
