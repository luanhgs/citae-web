using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Citae_Application.Models;

namespace Citae_Application.DAL
{
    public class DALUsuario
    {
        private string connectionString;

        public DALUsuario() {
            connectionString = ConfigurationManager.ConnectionStrings["citaeConnection"].ConnectionString;
        }

        public Usuario Select(Usuario user)
        {
            Usuario userReturn = null;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE email = @email", connection);
                cmd.Parameters.AddWithValue("@email", user.email);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) {
                    dr.Read();
                    userReturn = new Usuario(
                        int.Parse(dr["idUsuario"].ToString()),
                        dr["nome"].ToString(),
                        dr["email"].ToString(),
                        dr["senha"].ToString(),
                        (dr["imgPerfil"] != DBNull.Value && dr["imgPerfil"] != null) ? (byte[])dr["imgPerfil"] : null
                    );
                }
                connection.Close();
            }
            return userReturn;
        }

        public bool Insert(Usuario user, ref string error)
        {
            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_signin_usuario", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nome", user.nome);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@senha", user.senha);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException se) {
                error = se.Errors[0].Message.ToString(); //posição 0 pois apenas existe um erro de cada 
                return false;
            }
            return true;
        }

        public bool Login(Usuario user, ref string error)
        {
            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("sp_login_usuario", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@senha", user.senha);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException se) {
                error = se.Errors[0].Message.ToString(); //posição 0 pois apenas existe um erro de cada 
                return false;
            }
            return true;
        }
    }
}