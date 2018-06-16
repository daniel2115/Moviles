using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosMovilkes.Models;
using System.Data.SqlClient;

namespace ServiciosMovilkes.Manager
{
    public class SpecialistTagManager
    {
        public List<SpecialistTag> Obtener()
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<SpecialistTag> lista = new List<SpecialistTag>();
            try
            {
                string sql = "Select Id,TagId,SpecialistId from SpecialistTags";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    SpecialistTag spe = new SpecialistTag();
                    spe.Id = reader.GetInt32(0);
                    spe.TagId = reader.GetInt32(1);
                    spe.SpecialistId = reader.GetInt32(2);
                    lista.Add(spe);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return lista;
        }
        public SpecialistTag Obtener(int id)
        {
            SpecialistTag spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "Select Id,TagId,SpecialistId from SpecialistTags where Id = @idSpectags";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@idSpectags", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new SpecialistTag();
                spe.Id = reader.GetInt32(0);
                spe.TagId = reader.GetInt32(1);
                spe.SpecialistId = reader.GetInt32(2);
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return spe;
        }
        public SpecialistTag Insertar(SpecialistTag spe)
        {
            SpecialistTag result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Insert into SpecialistTags(TagId,specialistId) output INSERTED.Id values(@tgd,@specialist)";
                  
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tgd", System.Data.SqlDbType.Int).Value = spe.TagId;
                cmd.Parameters.Add("@specialist", System.Data.SqlDbType.Int).Value = spe.SpecialistId;
                int modified = (int)cmd.ExecuteScalar();
                if (modified != 0)
                {
                    result = Obtener(modified);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result = null;

            }
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return result;
        }
        public SpecialistTag Editar(int id, SpecialistTag spe)
        {
            SpecialistTag result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update SpecialistTags set TagId = @tgd,SpecialistId = @specialist output INSERTED.Id where Id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tgd", System.Data.SqlDbType.Int).Value= spe.TagId;
                cmd.Parameters.Add("@specialist", System.Data.SqlDbType.Int).Value = spe.SpecialistId;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = spe.Id;
                int modified = (int)cmd.ExecuteScalar();
                if (modified != 0)
                {
                    result = Obtener(modified);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result = null;
            }
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return result;
        }

    }
}