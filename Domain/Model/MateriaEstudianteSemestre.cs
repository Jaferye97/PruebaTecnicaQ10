using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    [Table("MateriaEstudianteSemestre", Schema = "Core")]
    public class MateriaEstudianteSemestre : BaseEntity<int>
    {
        public int Id { get; set; }

        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }

        public int MateriaId { get; set; }
        public Materia Materia { get; set; }

        public int SemestreId { get; set; }
        public Semestre Semestre { get; set; }

    }
}
