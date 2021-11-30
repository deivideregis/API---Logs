using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.APILogs.ViewModels
{
    public class MaquinaViewModel
    {
        [Key]
        public Guid Id { get; set; }        

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomeMaquina { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string IP { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string MAC { get; set; }

        public DateTime DataCadastro { get; set; }
        
        //public Log Logs { get; set; }
        public IEnumerable<Log> Logs { get; set; }

        public IEnumerable<TipoSistema> TipoSistema { get; set; }

    }
}
