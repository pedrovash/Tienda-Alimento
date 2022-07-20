using System.ComponentModel.DataAnnotations.Schema;

namespace Eva02Comida.Models
{
    public class Alimento // 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descripcion { get; set; }
        public string? Detalles { get; set; }
        public string? Color { get; set; }
        public string? Porte { get; set; }
        public string? Peso { get; set; }
        public string? Cantidad { get; set; }

        public string? imagenUrl { get; set; }
        [NotMapped]
        public IFormFile? ImagenFile { get; set; }

        //foreign 

        public int? MarcaId { get; set; }
        public Marca? Marca { get; set; }

        public int EdadId { get; set; }
        public Edad? Edad { get; set; }

        public int EspecieId { get; set; }
        public Especie? Especie { get; set; }

        public int FormatoId { get; set; }
        public Formato? Formato { get; set; }
    }
}
