using AutoMapper;
using DevIO.APILogs.ViewModels;
using DevIO.Business.Models;

namespace DevIO.APILogs.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            //ReverseMap: faz o mesmo (Maquima, MaquinaViewModel) ou (MaquinaViewModel, Maquina)
            CreateMap<Maquina, MaquinaViewModel>().ReverseMap();
            CreateMap<Log, LogViewModel>().ReverseMap();
            CreateMap<TipoSistema, TipoSistemaViewModel>().ReverseMap();
        }
    }
}
