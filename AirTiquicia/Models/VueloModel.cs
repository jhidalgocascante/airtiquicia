namespace AirTiquicia.Models
{
    public class VueloModel
    {
        public int CodVuelo { get; set; }

        public string? NombreVuelo { get; set; }

        public string? FechaVuelo { get; set; }

        public decimal DuracionVuelo { get; set; }

        public string? PaisOrigen { get; set; }

        public string? AeropuertoOrigen { get; set; }

        public string? PaisDestino { get; set; }

        public string? AeropuertoDestino { get; set; }

         public int CodDestino { get; set; }

        //Corresponden a los datos que van a ser utilizados en la busqueda
        public string? DescripcionDestino { get; set; }
        public decimal ValorDestino { get; set; }
        public int CodClase { get; set; }
        public string? NombreClase { get; set; }

    }
}
