﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    [Table("Materia", Schema = "Core")]
    public class Materia : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Creditos { get; set; }
        public bool Activo { get; set; }

        public ICollection<MateriaEstudianteSemestre> MateriaEstudianteSemestre { get; set; } = new List<MateriaEstudianteSemestre>();
    }
}
