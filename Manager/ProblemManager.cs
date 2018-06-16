using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosMovilkes.Models;
using System.Data.SqlClient;

namespace ServiciosMovilkes.Manager
{
    public class ProblemManager
    {
        public Problem Obtener(int id)
        {
            Problem spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "select Id,CustomerId,Title,Description,State from Problems where Id = @problem";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@problem", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new Problem();
                spe.Id = reader.GetInt32(0);
                spe.CustomerId = reader.GetInt32(1);
                spe.Title = reader.GetString(2);
                spe.Description = reader.GetString(3);
                spe.State = reader.GetByte(4);
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return spe;
        }
        public Problem Insertar(Problem spe)
        {
            Problem result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Insert into Problems(CustomerId,Title,Description,State) " +
                "output INSERTED.Id values(@customerid,@title,@description,@state)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@customerid", System.Data.SqlDbType.Int).Value = spe.CustomerId;
                cmd.Parameters.Add("@title", System.Data.SqlDbType.Int).Value = spe.Title;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.Int).Value = spe.Description;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Int).Value = spe.State; 
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
        public Problem Editar(int id, Problem spe)
        {
            Problem result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update Problems set CustomerId = @customerid,Title= @title" +
                    ",Description = @description,State = @state output INSERTED.Id where Id = @id";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@customerid", System.Data.SqlDbType.Int).Value = spe.CustomerId;
                cmd.Parameters.Add("@title", System.Data.SqlDbType.Int).Value = spe.Title;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.Int).Value = spe.Description;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Int).Value = spe.State;
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
        public Problem Eliminar(int id)
        {
            Problem temp = Obtener(id);
            temp.State = 0;
            return Editar(id, temp);
        }
        public List<Quotation> Quotation(int id) {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Quotation> lista = new List<Quotation>();
            try
            {
                string sql = "select Id,ProblemId,SpecialistId,Description," +
                "Price,EstimatedTime,IncludesMaterials,State," +
                "StartDate,FinishDate,FinalPrice,SpecialistRate," +
                "SpecialistComment,CustomerRate,CustomerComment from Quotations where ProblemId = @problem";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@problem", System.Data.SqlDbType.NVarChar).Value = id;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Quotation spe = new Quotation();
                    spe.Id = reader.GetInt32(0);
                    spe.ProblemId = reader.GetInt32(1);
                    spe.SpecialistId = reader.GetInt32(2);
                    spe.Description = reader.GetString(3);
                    spe.Price = reader.GetDecimal(4);
                    spe.EstimatedTime = reader.GetByte(5);
                    spe.IncludesMaterial = reader.GetBoolean(6);
                    spe.State = reader.GetByte(7);
                    spe.StartDate = reader.GetDateTime(8);
                    spe.FinishDate = reader.GetDateTime(9);
                    spe.FinalPrice = reader.GetDecimal(10);
                    spe.SpecialistRate = reader.GetDecimal(11);
                    spe.SpecialistComment = reader.GetString(12);
                    spe.CustomerRate = reader.GetDecimal(13);
                    spe.CustomerComment = reader.GetString(14);
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