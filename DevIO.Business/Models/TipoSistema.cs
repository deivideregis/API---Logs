using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public class TipoSistema : Entity
    {
        public Guid MaquinaId { get; set; }

        public string NumeroSistema { get; set; }

        public string NomeSistema { get; set; }

        /* EF Relation */
        public Maquina Maquina { get; set; }
    }
}
