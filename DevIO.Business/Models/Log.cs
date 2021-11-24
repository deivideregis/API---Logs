using System;

namespace DevIO.Business.Models
{
    public class Log : Entity
    {
        public Guid MaquinaId { get; set; }

        public TipoLogs TipoLogs { get; set; }

        public string Detalhe { get; set; }

        public string Acao { get; set; }

        public DateTime DataCadastro { get; set; }

        /* EF Relation */
        public Maquina Maquina { get; set; }
    }
}
