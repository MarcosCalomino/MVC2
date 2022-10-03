using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Libro //SE CREA EL MODELO, ESTO REPRESENTA UNA TABLA EN LA BASE DE DATOS
    {
        [Key] //Indica que esta Id es una clave primaria y autoincremental ([Key] es una dataanotation)
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio")] //mensaje que se  muestra en caso de que se trate de mandar este campo vacio
        [StringLength(50, ErrorMessage ="El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]//valida la longitud de los caracteres que tiene que tener el campo. En este caso debe estar entre 3 y 50 caracteres
        [Display(Name ="Título")]//Es para mostrar el tilde en las palabras. en la bdd va a estar sin tilde pero en la app se muestra con tilde
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        [Display(Name = "Fehca Lanzamiento")]
        [DataType(DataType.Date)]//es para configurar la fecha, que solo quede fecha y no quede fecha y hora
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "campo obligatorio")]
        public int Precio { get; set; }
    }
}
