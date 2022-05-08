namespace AirTiquicia.Models
{
    public class ReservaModel
    {

        public int CodReserva { get; set; }

        public int CodVuelo { get; set; }
        public int NumOcupantes { get; set; }
        public decimal NumKilosEquipaje { get; set; }
        public decimal MonTiquete { get; set; }
        public decimal MonEquipaje { get; set; }
        public decimal MonTotal { get; set; }
        //
        public string? NumIdentificacion { get; set; }
        public string? NomIdentificacion { get; set; }
        public string? ApeIdentificacion { get; set; }
        public string? FecNacimiento { get; set; }
        public string? DesCorreo { get; set; }
        public string? NumTelefono { get; set; }


    }
}
