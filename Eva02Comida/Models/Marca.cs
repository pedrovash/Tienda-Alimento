﻿namespace Eva02Comida.Models
{
    public class Marca // Marca = DOGSHOW ,SABROCAN , MASTERDOG
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descripcion { get; set; }

        public List<Alimento>? Alimentos { get; set; }
    }
}
