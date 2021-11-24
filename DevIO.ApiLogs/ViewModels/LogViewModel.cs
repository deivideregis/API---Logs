using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.APILogs.ViewModels
{
    public class LogViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid MaquinaId { get; set; }

        public int TipoLogs { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Detalhe { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Acao { get; set; }

        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public string NomeMaquinaLog { get; set; }
    }
}
