using AirTiquicia.Models;
using System.Data.SqlClient;
using System.Data;


namespace AirTiquicia.Datos
{
    public class ReservaDatos
    {

        public List<ReservaModel> Listar()
        {

            var oLista = new List<ReservaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarReserva", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new ReservaModel()
                        {
                            CodReserva = Convert.ToInt32(dr["CodReserva"]),
                            CodVuelo = Convert.ToInt32(dr["CodVuelo"]),
                            NumOcupantes = Convert.ToInt32(dr["NumOcupantes"]),
                            NumKilosEquipaje = Convert.ToDecimal(dr["NumKilosEquipaje"]),
                            MonTiquete = Convert.ToDecimal(dr["MonTiquete"]),
                            MonEquipaje = Convert.ToDecimal(dr["MonEquipaje"]),
                            MonTotal = Convert.ToDecimal(dr["MonTotal"]),
                            //
                            NumIdentificacion = dr["NumIdentificacion"].ToString(),
                            NomIdentificacion = dr["NomIdentificacion"].ToString(),
                            ApeIdentificacion = dr["ApeIdentificacion"].ToString(),
                            FecNacimiento = dr["FecNacimiento"].ToString(),
                            DesCorreo = dr["DesCorreo"].ToString(),
                            NumTelefono = dr["NumTelefono"].ToString(),


                        });

                    }
                }
            }
            return oLista;
        }

        //
        public ReservaModel Obtener(int CodReserva)
        {

            var oReserva = new ReservaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerReserva", conexion);
                cmd.Parameters.AddWithValue("CodReserva", @CodReserva);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oReserva.CodReserva = Convert.ToInt32(dr["CodReserva"]);
                        oReserva.CodVuelo = Convert.ToInt32(dr["CodVuelo"]);
                        oReserva.NumOcupantes = Convert.ToInt32(dr["NumOcupantes"]);
                        oReserva.NumKilosEquipaje = Convert.ToDecimal(dr["NumKilosEquipaje"]);
                        oReserva.MonTiquete = Convert.ToDecimal(dr["MonTiquete"]);
                        oReserva.MonEquipaje = Convert.ToDecimal(dr["MonEquipaje"]);
                        oReserva.MonTotal = Convert.ToDecimal(dr["MonTotal"]);
                        //
                        oReserva.NumIdentificacion = dr["NumIdentificacion"].ToString();
                        oReserva.NomIdentificacion = dr["NomIdentificacion"].ToString();
                        oReserva.ApeIdentificacion = dr["ApeIdentificacion"].ToString();
                        oReserva.FecNacimiento = dr["FecNacimiento"].ToString();
                        oReserva.DesCorreo = dr["DesCorreo"].ToString();
                        oReserva.NumTelefono = dr["NumTelefono"].ToString();

                    };

                }

            }
            return oReserva;
        }


        //Contacto
        public bool Guardar(ReservaModel oReserva)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardarReserva", conexion);

                    cmd.Parameters.AddWithValue("CodVuelo", oReserva.CodVuelo);
                    cmd.Parameters.AddWithValue("NumOcupantes", oReserva.NumOcupantes);
                    cmd.Parameters.AddWithValue("NumKilosEquipaje", oReserva.NumKilosEquipaje);
                    cmd.Parameters.AddWithValue("MonTiquete", oReserva.MonTiquete);
                    cmd.Parameters.AddWithValue("MonEquipaje", oReserva.MonEquipaje);
                    cmd.Parameters.AddWithValue("MonTotal", oReserva.MonTotal);
                    cmd.Parameters.AddWithValue("NumIdentificacion", oReserva.NumIdentificacion);
                    cmd.Parameters.AddWithValue("NomIdentificacion", oReserva.NomIdentificacion);
                    cmd.Parameters.AddWithValue("ApeIdentificacion", oReserva.ApeIdentificacion);
                    cmd.Parameters.AddWithValue("FecNacimiento", oReserva.FecNacimiento);
                    cmd.Parameters.AddWithValue("DesCorreo", oReserva.DesCorreo);
                    cmd.Parameters.AddWithValue("NumTelefono", oReserva.NumTelefono);


                    //cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = true;
            }
            return rpta;
        }

        //Editar
        public bool Editar(ReservaModel oReserva)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarReserva", conexion);

                    cmd.Parameters.AddWithValue("CodReserva", oReserva.CodReserva);
                    cmd.Parameters.AddWithValue("CodVuelo", oReserva.CodVuelo);
                    cmd.Parameters.AddWithValue("NumOcupantes", oReserva.NumOcupantes);
                    cmd.Parameters.AddWithValue("NumKilosEquipaje", oReserva.NumKilosEquipaje);
                    cmd.Parameters.AddWithValue("MonTiquete", oReserva.MonTiquete);
                    cmd.Parameters.AddWithValue("MonEquipaje", oReserva.MonEquipaje);
                    cmd.Parameters.AddWithValue("MonTotal", oReserva.MonTotal);
                    cmd.Parameters.AddWithValue("NumIdentificacion", oReserva.NumIdentificacion);
                    cmd.Parameters.AddWithValue("NomIdentificacion", oReserva.NomIdentificacion);
                    cmd.Parameters.AddWithValue("ApeIdentificacion", oReserva.ApeIdentificacion);
                    cmd.Parameters.AddWithValue("FecNacimiento", oReserva.FecNacimiento);
                    cmd.Parameters.AddWithValue("DesCorreo", oReserva.DesCorreo);
                    cmd.Parameters.AddWithValue("NumTelefono", oReserva.NumTelefono);

                    //cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = true;
            }
            return rpta;
        }


        //Borrar
        public bool Eliminar(int CodReserva)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarReserva", conexion);

                    cmd.Parameters.AddWithValue("CodReserva", CodReserva);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = true;
            }
            return rpta;
        }

       



    }
}
