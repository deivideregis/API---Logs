using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.APILogs.ViewModels
{
    public class ListaSistemaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public string NumeroSistema { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(3, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]

        public string NomeSistema { get; set; }
    }
}
