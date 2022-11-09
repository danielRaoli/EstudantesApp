using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstudantesApp.Transporte
{
    public class EstudanteDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
        
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }
        [Display(Name = "Data")]
        public string FechaInscrição { get; set; }
        public DateTime FechaDate { get; internal set; }
    }
}
