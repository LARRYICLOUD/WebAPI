using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class UsuarioData
    {
        public static bool Registrar(Usuario usuario)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documentoidentidad", usuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@ciudad", usuario.Ciudad);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

        }

        public static bool Modificar(Usuario usuario)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documentoidentidad", usuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@ciudad", usuario.Ciudad);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

        }


        public static List<Usuario> Listar()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())

                        {
                            oListaUsuario.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),

                            });


                        }


                    }
                    return oListaUsuario;






                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }
        }

        public static Usuario Obtener(int idusuario)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(" @idusuario", idusuario);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oUsuario = new Usuario()
                            {

                                IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),

                            };


                        }






                    }
                    return oUsuario;


                }
                catch (Exception ex)
                {
                    return oUsuario;
                }





            }


        }
        public static bool Eliminar(int id)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(" @idusuario", id);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    return true;




                }
                catch (Exception ex)
                {
                    return false;
                }



            }






        }
    }
}