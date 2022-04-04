using AirTiquicia.Models;
using System.Data.SqlClient;
using System.Data;

namespace AirTiquicia.Datos
{
    public class DestinosDatos
    {


        public List<DestinosModel> Listar()
        {

            var oLista = new List<DestinosModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarDestinos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new DestinosModel()
                        {
                            CodDestino = Convert.ToInt32(dr["CodDestino"]),
                            NombreDestino = dr["NombreDestino"].ToString(),
                            DescripcionDestino = dr["DescripcionDestino"].ToString(),
                            CodClase = Convert.ToInt32(dr["CodClase"]),
                            ValorDestino = Convert.ToDecimal(dr["ValorDestino"])

                        });

                    }
                }
            }
            return oLista;
        }

        //
        public DestinosModel Obtener(int CodDestino)
        {

            var oDestino = new DestinosModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerDestino", conexion);
                cmd.Parameters.AddWithValue("CodDestino", @CodDestino);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oDestino.CodDestino = Convert.ToInt32(dr["CodDestino"]);
                        oDestino.NombreDestino = dr["NombreDestino"].ToString();
                        oDestino.DescripcionDestino = dr["DescripcionDestino"].ToString();
                        oDestino.CodClase = Convert.ToInt32(dr["CodClase"]);
                        oDestino.ValorDestino = Convert.ToDecimal(dr["ValorDestino"]);

                    }
                }
            }
            return oDestino;
        }


        //Contacto
        public bool Guardar(DestinosModel oDestino)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardarDestino", conexion);

                    cmd.Parameters.AddWithValue("NombreDestino", oDestino.NombreDestino);
                    cmd.Parameters.AddWithValue("DescripcionDestino", oDestino.DescripcionDestino);
                    cmd.Parameters.AddWithValue("CodClase", oDestino.CodClase);
                    cmd.Parameters.AddWithValue("ValorDestino", oDestino.ValorDestino);
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
        public bool Editar(DestinosModel oDestino)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarDestino", conexion);

                    cmd.Parameters.AddWithValue("CodDestino", oDestino.CodDestino);
                    cmd.Parameters.AddWithValue("NombreDestino", oDestino.NombreDestino);
                    cmd.Parameters.AddWithValue("DescripcionDestino", oDestino.DescripcionDestino);
                    cmd.Parameters.AddWithValue("CodClase", oDestino.CodClase);
                    cmd.Parameters.AddWithValue("ValorDestino", oDestino.ValorDestino);
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
        public bool Eliminar(int CodDestino)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarDestino", conexion);

                    cmd.Parameters.AddWithValue("CodDestino", CodDestino);
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
