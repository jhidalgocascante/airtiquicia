using AirTiquicia.Models;
using System.Data.SqlClient;
using System.Data;

namespace AirTiquicia.Datos
{
    public class TripulacionDatos
    {

        public List<TripulacionModel> Listar()
        {

            var oLista = new List<TripulacionModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarTripulacion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new TripulacionModel()
                        {
                            CodTripulante = Convert.ToInt32(dr["CodTripulante"]),
                            NombreTripulante = dr["NombreTripulante"].ToString(),
                            CodTipoTripulante = Convert.ToInt32(dr["CodTipoTripulante"])
                        });

                    }
                }
            }
            return oLista;
        }

        //
        public TripulacionModel Obtener(int CodTripulante)
        {

            var oTripulacion = new TripulacionModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerTripulante", conexion);
                cmd.Parameters.AddWithValue("CodTripulante", @CodTripulante);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oTripulacion.CodTripulante = Convert.ToInt32(dr["CodTripulante"]);
                        oTripulacion.NombreTripulante = dr["NombreTripulante"].ToString();
                        oTripulacion.CodTipoTripulante = Convert.ToInt32(dr["CodTipoTripulante"]);

                    }
                }
            }
            return oTripulacion;
        }

       
        //Contacto
        public bool Guardar(TripulacionModel oTripulacion)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardarTripulante", conexion);

                    cmd.Parameters.AddWithValue("NombreTripulante", oTripulacion.NombreTripulante);
                    cmd.Parameters.AddWithValue("CodTipoTripulante", oTripulacion.CodTipoTripulante);
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
        public bool Editar(TripulacionModel oTripulacion)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarTripulante", conexion);

                    cmd.Parameters.AddWithValue("CodTripulante", oTripulacion.CodTripulante);
                    cmd.Parameters.AddWithValue("NombreTripulante", oTripulacion.NombreTripulante);
                    cmd.Parameters.AddWithValue("CodTipoTripulante", oTripulacion.CodTipoTripulante);
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
        public bool Eliminar(int CodTripulante)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarTripulante", conexion);

                    cmd.Parameters.AddWithValue("CodTripulante", CodTripulante);
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
