using AirTiquicia.Models;
using System.Data.SqlClient;
using System.Data;

namespace AirTiquicia.Datos
{
    public class RangoEquipajeDatos
    {

        public List<RangoEquipajeModel> Listar()
        {

            var oLista = new List<RangoEquipajeModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarRangosEquipaje", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new RangoEquipajeModel()
                        {
                            CodRangoEquipaje    = Convert.ToInt32(dr["CodRangoEquipaje"]),
                            PesoInicio          = Convert.ToDecimal(dr["PesoInicio"]),
                            PesoFin             = Convert.ToDecimal(dr["PesoFin"]),
                            ValorEquipaje       = Convert.ToDecimal(dr["ValorEquipaje"]),
                            DescripcionRango    = dr["DescripcionRango"].ToString()    

                        });

                    }
                }
            }
            return oLista;
        }

        //
        public RangoEquipajeModel Obtener(int CodRangoEquipaje)
        {

            var oRangoEquipaje= new RangoEquipajeModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerRangoEquipaje", conexion);
                cmd.Parameters.AddWithValue("CodRangoEquipaje", @CodRangoEquipaje);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oRangoEquipaje.CodRangoEquipaje = Convert.ToInt32(dr["CodRangoEquipaje"]);
                        oRangoEquipaje.PesoInicio = Convert.ToDecimal(dr["PesoInicio"]);
                        oRangoEquipaje.PesoFin = Convert.ToDecimal(dr["PesoFin"]);
                        oRangoEquipaje.ValorEquipaje = Convert.ToDecimal(dr["ValorEquipaje"]);
                        oRangoEquipaje.DescripcionRango = dr["DescripcionRango"].ToString();

                    }
                }
            }
            return oRangoEquipaje;
        }


        //Contacto
        public bool Guardar(RangoEquipajeModel oRangoEquipaje)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardarRangoEquipaje", conexion);

                    cmd.Parameters.AddWithValue("PesoInicio", oRangoEquipaje.PesoInicio);
                    cmd.Parameters.AddWithValue("PesoFin", oRangoEquipaje.PesoFin);
                    cmd.Parameters.AddWithValue("ValorEquipaje", oRangoEquipaje.ValorEquipaje);
                    cmd.Parameters.AddWithValue("DescripcionRango", oRangoEquipaje.DescripcionRango);
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
        public bool Editar(RangoEquipajeModel oRangoEquipaje)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarRangoEquipaje", conexion);

                    cmd.Parameters.AddWithValue("CodRangoEquipaje", oRangoEquipaje.CodRangoEquipaje);
                    cmd.Parameters.AddWithValue("PesoInicio", oRangoEquipaje.PesoInicio);
                    cmd.Parameters.AddWithValue("PesoFin", oRangoEquipaje.PesoFin);
                    cmd.Parameters.AddWithValue("ValorEquipaje", oRangoEquipaje.ValorEquipaje);
                    cmd.Parameters.AddWithValue("DescripcionRango", oRangoEquipaje.DescripcionRango);
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
        public bool Eliminar(int CodRangoEquipaje)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarRangoEquipaje", conexion);

                    cmd.Parameters.AddWithValue("CodRangoEquipaje", CodRangoEquipaje);
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


    }
}
