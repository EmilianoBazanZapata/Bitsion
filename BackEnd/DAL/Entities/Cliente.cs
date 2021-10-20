using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        [MaxLength(255)]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        [MaxLength(255)]
        public string Apellido { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        [MaxLength(255)]
        public int Identificacion { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public bool Genero { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public bool Maneja { get; set; }
        [Required]
        public bool UsaLentes { get; set; }
        [Required]
        public bool EsDiabetico { get; set; }
        [Required]
        public bool PadeceOtraEnfermedad { get; set; }
        [Required]
        public string OtraEnfermedad { get; set; }
    }
}