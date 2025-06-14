using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    [Table("Semestre", Schema = "Core")]
    public class Semestre : BaseEntity<int>
    {
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public bool Activo { get; set; }
    }
}
