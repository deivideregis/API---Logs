using System;
using System.Collections.Generic;

namespace DevIO.Business.Models
{
    public class Maquina : Entity
    {
        public string NomeMaquina { get; set; }

        public string IP { get; set; }

        public string MAC { get; set; }

        public DateTime DataCadastro { get; set; }

        /* EF Relation */
        //public Log Logs { get; set; }
        public IEnumerable<Log> Logs { get; set; }

        public IEnumerable<TipoSistema> TipoSistema { get; set; }
    }
}
