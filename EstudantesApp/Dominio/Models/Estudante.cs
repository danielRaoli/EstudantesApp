using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudantesApp.Dominio.Models
{
    public class Estudante
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName="varchar(80)")]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "varchar(80)")]
        public string Sobrenome { get; set; }
        [Required]
        public DateTime FechaInscrição { get; set; }




    }
}
