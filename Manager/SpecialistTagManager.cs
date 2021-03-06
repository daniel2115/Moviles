﻿using System;
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
                TagManager tagmanager = new TagManager();
                SpecialistManager specialistManager = new SpecialistManager();

                string sql = "Select Id,TagId,specialistid from SpecialistTags";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    SpecialistTag spe = new SpecialistTag();
                    spe.id = reader.GetInt32(0);
                    spe.tag = tagmanager.Obtener(reader.GetInt32(1));
                    spe.specialist = specialistManager.Obtener(reader.GetInt32(2));
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
            TagManager tagmanager = new TagManager();
            SpecialistManager specialistManager = new SpecialistManager();

            SpecialistTag spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "Select Id,TagId,specialistid from SpecialistTags where Id = @idSpectags";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@idSpectags", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new SpecialistTag();
                spe.id = reader.GetInt32(0);
                spe.tag = tagmanager.Obtener(reader.GetInt32(1));
                spe.specialist = specialistManager.Obtener(reader.GetInt32(2));
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
                string sql = "Insert into SpecialistTags(TagId,specialistid) output INSERTED.Id values(@tgd,@specialist)";
                  
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tgd", System.Data.SqlDbType.Int).Value = spe.tag.id;
                cmd.Parameters.Add("@specialist", System.Data.SqlDbType.Int).Value = spe.specialist.id;
                int modified = (int)cmd.ExecuteScalar();
                if (modified != 0)
                {
                    TagManager tagManager = new TagManager();
                    result = Obtener(modified);
                    result.tag = tagManager.Obtener(result.tag.id);
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
        public SpecialistTag Editar(int id, int tagid)
        {
            SpecialistTag result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update SpecialistTags set TagId = @tgd output INSERTED.Id where Id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tgd", System.Data.SqlDbType.Int).Value = tagid;
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

    }
}