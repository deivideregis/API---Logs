using AutoMapper;
using DevIO.APILogs.Controllers;
using DevIO.APILogs.Extensions;
using DevIO.APILogs.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.APILogs.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/maquina")]
    public class MaquinasController : MainController
    {
        private readonly IMaquinaRepository _maquinaRepository;
        private readonly IMaquinaService _maquinaService;
        private readonly ILogRepository _logRepository;
        private readonly ITipoSistemaRepository _tipoSistemaRepository;
        private readonly IMapper _mapper;
        
        public MaquinasController(IMaquinaRepository maquinaRepository,
                                      IMapper mapper,
                                      IMaquinaService maquinaService,
                                      INotificador notificador,
                                      ILogRepository logRepository,
                                      ITipoSistemaRepository tipoSistemaRepository,
                                      IUser user) : base(notificador, user)
        {
            _maquinaRepository = maquinaRepository;
            _mapper = mapper;
            _maquinaService = maquinaService;
            _logRepository = logRepository;
            _tipoSistemaRepository = tipoSistemaRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<MaquinaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<MaquinaViewModel>>(await _maquinaRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MaquinaViewModel>> ObterPorId(Guid id)
        {
            var maquina = await ObterMaquinaLog(id);

            if (maquina == null) return NotFound();

            return maquina;
        }

        [ClaimsAuthorize("Maquina", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<MaquinaViewModel>> Adicionar(MaquinaViewModel maquinaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _maquinaService.Adicionar(_mapper.Map<Maquina>(maquinaViewModel));

            return CustomResponse(maquinaViewModel);
        }

        [ClaimsAuthorize("Maquina", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<MaquinaViewModel>> Atualizar(Guid id, MaquinaViewModel maquinaViewModel)
        {
            if (id != maquinaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(maquinaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _maquinaService.Atualizar(_mapper.Map<Maquina>(maquinaViewModel));

            return CustomResponse(maquinaViewModel);
        }

        [ClaimsAuthorize("Maquina", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<MaquinaViewModel>> Excluir(Guid id)
        {
            var maquinaViewModel = await ObterMaquinaLog(id);

            if (maquinaViewModel == null) return NotFound();

            await _maquinaService.Remover(id);

            return CustomResponse(maquinaViewModel);
        }

        [HttpGet("log/{id:guid}")]
        public async Task<LogViewModel> ObterLogPorId(Guid id)
        {
            return _mapper.Map<LogViewModel>(await _logRepository.ObterPorId(id));
        }

        [AllowAnonymous]
        [HttpGet("tiposistema")]
        public async Task<IEnumerable<TipoSistemaViewModel>> ObterTodosTipoSistema()
        {
            return _mapper.Map<IEnumerable<TipoSistemaViewModel>>(await _tipoSistemaRepository.ObterTodosTipoSistema());
        }

        [ClaimsAuthorize("Maquina", "Atualizar")]
        [HttpPut("log/{id:guid}")]
        public async Task<IActionResult> AtualizarLog(Guid id, LogViewModel logViewModel)
        {
            if (id != logViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(logViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _maquinaService.AtualizarLog(_mapper.Map<Log>(logViewModel));

            return CustomResponse(logViewModel);
        }

        private async Task<MaquinaViewModel> ObterMaquinaLog(Guid id)
        {
            return _mapper.Map<MaquinaViewModel>(await _maquinaRepository.ObterMaquinaLog(id));
        }
    }
}
