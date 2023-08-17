using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class BodegaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La direccion es requerida")]
        public string Direccion { get; set; }
    }
}
