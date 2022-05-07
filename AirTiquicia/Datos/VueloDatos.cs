using AirTiquicia.Models;
using System.Data.SqlClient;
using System.Data;

namespace AirTiquicia.Datos
{
    public class VueloDatos
    {
        public List<VueloModel> Listar()
        {

            var oLista = new List<VueloModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarVuelo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new VueloModel()
                        {
                            CodVuelo = Convert.ToInt32(dr["CodVuelo"]),
                            NombreVuelo = dr["NombreVuelo"].ToString(), 
                            FechaVuelo = dr["FechaVuelo"].ToString(),
                            DuracionVuelo = Convert.ToDecimal(dr["DuracionVuelo"]),
                            PaisOrigen = dr["PaisOrigen"].ToString(),
                            AeropuertoOrigen = dr["AeropuertoOrigen"].ToString(),
                            PaisDestino = dr["PaisDestino"].ToString(),
                            AeropuertoDestino = dr["AeropuertoDestino"].ToString(),
                            CodDestino = Convert.ToInt32(dr["CodDestino"]),
                        });

                    }
                }
            }
            return oLista;
        }

        //
        public VueloModel Obtener(int CodVuelo)
        {

            var oVuelo = new VueloModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerVuelo", conexion);
                cmd.Parameters.AddWithValue("CodVuelo", @CodVuelo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oVuelo.CodVuelo = Convert.ToInt32(dr["CodVuelo"]);
                        oVuelo.NombreVuelo = dr["NombreVuelo"].ToString();
                        oVuelo.FechaVuelo = dr["FechaVuelo"].ToString();
                        oVuelo.DuracionVuelo = Convert.ToDecimal(dr["DuracionVuelo"]);
                        oVuelo.PaisOrigen = dr["PaisOrigen"].ToString();
                        oVuelo.AeropuertoOrigen = dr["AeropuertoOrigen"].ToString();
                        oVuelo.PaisDestino = dr["PaisDestino"].ToString();
                        oVuelo.AeropuertoDestino = dr["AeropuertoDestino"].ToString();
                        oVuelo.CodDestino = Convert.ToInt32(dr["CodDestino"]);
                     };

                }
                
            }
            return oVuelo;
        }


        //Contacto
        public bool Guardar(VueloModel oVuelo)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardarVuelo", conexion);

                    cmd.Parameters.AddWithValue("NombreVuelo", oVuelo.NombreVuelo);
                    cmd.Parameters.AddWithValue("FechaVuelo", oVuelo.FechaVuelo);
                    cmd.Parameters.AddWithValue("DuracionVuelo", oVuelo.DuracionVuelo);
                    cmd.Parameters.AddWithValue("PaisOrigen", oVuelo.PaisOrigen);
                    cmd.Parameters.AddWithValue("AeropuertoOrigen", oVuelo.AeropuertoOrigen);
                    cmd.Parameters.AddWithValue("PaisDestino", oVuelo.PaisDestino);
                    cmd.Parameters.AddWithValue("AeropuertoDestino", oVuelo.AeropuertoDestino);
                    cmd.Parameters.AddWithValue("CodDestino", oVuelo.CodDestino);


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
        public bool Editar(VueloModel oVuelo)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarVuelo", conexion);

                    cmd.Parameters.AddWithValue("CodVuelo", oVuelo.CodVuelo);
                    cmd.Parameters.AddWithValue("NombreVuelo", oVuelo.NombreVuelo);
                    cmd.Parameters.AddWithValue("FechaVuelo", oVuelo.FechaVuelo);
                    cmd.Parameters.AddWithValue("DuracionVuelo", oVuelo.DuracionVuelo);
                    cmd.Parameters.AddWithValue("PaisOrigen", oVuelo.PaisOrigen);
                    cmd.Parameters.AddWithValue("AeropuertoOrigen", oVuelo.AeropuertoOrigen);
                    cmd.Parameters.AddWithValue("PaisDestino", oVuelo.PaisDestino);
                    cmd.Parameters.AddWithValue("AeropuertoDestino", oVuelo.AeropuertoDestino);
                    cmd.Parameters.AddWithValue("CodDestino", oVuelo.CodDestino);

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
        public bool Eliminar(int CodVuelo)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarVuelo", conexion);

                    cmd.Parameters.AddWithValue("CodVuelo", CodVuelo);
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

        //nuevo
        public List<VueloModel> BuscarVuelos(string DestinoBusqueda, string FechaInicio, string FechaFinal)
        {

            var oLista = new List<VueloModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_buscarVuelos", conexion);
                cmd.Parameters.AddWithValue("DestinoBusqueda", @DestinoBusqueda);
                cmd.Parameters.AddWithValue("FechaInicio", @FechaInicio);
                cmd.Parameters.AddWithValue("FechaFinal", @FechaFinal);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new VueloModel()
                        {
                            CodVuelo = Convert.ToInt32(dr["CodVuelo"]),
                            NombreVuelo = dr["NombreVuelo"].ToString(),
                            FechaVuelo = dr["FechaVuelo"].ToString(),
                            DuracionVuelo = Convert.ToDecimal(dr["DuracionVuelo"]),
                            PaisOrigen = dr["PaisOrigen"].ToString(),
                            AeropuertoOrigen = dr["AeropuertoOrigen"].ToString(),
                            PaisDestino = dr["PaisDestino"].ToString(),
                            AeropuertoDestino = dr["AeropuertoDestino"].ToString(),
                            CodDestino = Convert.ToInt32(dr["CodDestino"]),
                            //Detalle del tipo de clasificacion
                            DescripcionDestino = dr["DescripcionDestino"].ToString(),
                            ValorDestino = Convert.ToDecimal(dr["ValorDestino"]),
                            CodClase = Convert.ToInt32(dr["CodClase"]),
                            NombreClase = dr["NombreClase"].ToString()
                        });

                    }
                }
            }
            return oLista;
        }



    }
}
