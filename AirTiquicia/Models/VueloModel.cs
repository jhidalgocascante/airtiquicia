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

    }
}
