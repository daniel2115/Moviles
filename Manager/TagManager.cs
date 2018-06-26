using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosMovilkes.Models;
using System.Data.SqlClient;

namespace ServiciosMovilkes.Manager
{
    public class TagManager
    {
        public List<Tag> Obtener()
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Tag> lista = new List<Tag>();
            try
            {
                string sql = "select Id,Description from Tags";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Tag tag = new Tag();
                    tag.id = reader.GetInt32(0);
                    tag.description= reader.GetString(1);
                    lista.Add(tag);
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
        public Tag Obtener(int id)
        {
            Tag tag = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "Select Id,Description from Tags where Id = @idTag";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@idTag", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                tag = new Tag();
                tag.id = reader.GetInt32(0);
                tag.description = reader.GetString(1);
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return tag;
        }
        public Tag Insertar(Tag tag)
        {
            Tag result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Insert into Tags(Description)" +
                    " output INSERTED.Id values(@description)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = tag.description;
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
        public Tag Editar(int id, Tag tag)
        {
            Tag result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update Tags set Description = @description output INSERTED.Id where Id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = tag.description;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
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
        public List<SpecialistTag> SpecialistTags(int id)
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<SpecialistTag> lista = new List<SpecialistTag>();
            try
            {
                string sql = "Select Id,TagId,SpecialistId from SpecialistTags where TagId = @idTag";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@idTag", System.Data.SqlDbType.NVarChar).Value = id;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    SpecialistTag spe = new SpecialistTag();
                    spe.id = reader.GetInt32(0);
                    spe.tagId = reader.GetInt32(1);
                    spe.specialistId = reader.GetInt32(2);
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
    
    }
}