using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    [Table("Estudiante", Schema ="Core")]
    public class Estudiante : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Correo { get; set; }
    }
}
