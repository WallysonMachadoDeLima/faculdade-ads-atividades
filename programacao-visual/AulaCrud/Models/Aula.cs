using System.ComponentModel.DataAnnotations;

namespace AulaCrud.Models
{
    public class Aula
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A data/hora é obrigatória")]
        [Display(Name = "Data e Hora")]
        [DataType(DataType.DateTime)]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória")]
        [Range(1, 300, ErrorMessage = "A duração deve estar entre 1 e 300 minutos")]
        [Display(Name = "Duração (min)")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O professor é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do professor deve ter no máximo 100 caracteres")]
        [Display(Name = "Professor")]
        public string Professor { get; set; } = string.Empty;
    }
}
