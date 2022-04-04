using AirTiquicia.Models;
using System.Data.SqlClient;
using System.Data;

namespace AirTiquicia.Datos
{
    public class AvionDatos
    {


        public List<AvionModel> Listar()
        {

            var oLista = new List<AvionModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarAvion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new AvionModel()
                        {
                            CodAvion = Convert.ToInt32(dr["CodAvion"]),
                            CodMarca = Convert.ToInt32(dr["CodMarca"]),
                            ModeloAvion = dr["ModeloAvion"].ToString(),
                            DetalleAvion = dr["DetalleAvion"].ToString()

                        });

                    }
                }
            }
            return oLista;
        }

        //
        public AvionModel Obtener(int CodAvion)
        {

            var oAvion = new AvionModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerAvion", conexion);
                cmd.Parameters.AddWithValue("CodAvion", @CodAvion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oAvion.CodAvion = Convert.ToInt32(dr["CodAvion"]);
                        oAvion.CodMarca = Convert.ToInt32(dr["CodMarca"]);
                        oAvion.ModeloAvion = dr["ModeloAvion"].ToString();
                        oAvion.DetalleAvion = dr["DetalleAvion"].ToString();

                    }
                }
            }
            return oAvion;
        }


        //Contacto
        public bool Guardar(AvionModel oAvion)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardarAvion", conexion);

                    cmd.Parameters.AddWithValue("CodMarca", oAvion.CodMarca);
                    cmd.Parameters.AddWithValue("ModeloAvion", oAvion.ModeloAvion);
                    cmd.Parameters.AddWithValue("DetalleAvion", oAvion.DetalleAvion);
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
        public bool Editar(AvionModel oAvion)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarAvion", conexion);

                    cmd.Parameters.AddWithValue("CodAvion", oAvion.CodAvion);
                    cmd.Parameters.AddWithValue("CodMarca", oAvion.CodMarca);
                    cmd.Parameters.AddWithValue("ModeloAvion", oAvion.ModeloAvion);
                    cmd.Parameters.AddWithValue("DetalleAvion", oAvion.DetalleAvion);
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
        public bool Eliminar(int CodAvion)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarAvion", conexion);

                    cmd.Parameters.AddWithValue("CodAvion", CodAvion);
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
