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
                spe.id = reader.GetInt32(0);
                spe.customerId = reader.GetInt32(1);
                spe.title = reader.GetString(2);
                spe.description = reader.GetString(3);
                spe.state = reader.GetByte(4);
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
                cmd.Parameters.Add("@customerid", System.Data.SqlDbType.Int).Value = spe.customerId;
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar).Value = spe.title;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.NVarChar).Value = spe.description;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Bit).Value = spe.state; 
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
                cmd.Parameters.Add("@customerid", System.Data.SqlDbType.Int).Value = spe.customerId;
                cmd.Parameters.Add("@title", System.Data.SqlDbType.NVarChar).Value = spe.title;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.NVarChar).Value = spe.description;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Bit).Value = spe.state; 
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
            temp.state = 0;
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
                    spe.id = reader.GetInt32(0);
                    spe.problemId = reader.GetInt32(1);
                    spe.specialistId = reader.GetInt32(2);
                    spe.description = reader.GetString(3);
                    spe.price = reader.GetDecimal(4);
                    spe.estimatedTime = reader.GetByte(5);
                    spe.includesMaterial = reader.GetBoolean(6);
                    spe.state = reader.GetByte(7);
                    spe.startDate = reader.GetDateTime(8);
                    spe.finishDate = reader.GetDateTime(9);
                    spe.finalPrice = reader.GetDecimal(10);
                    spe.specialistRate = reader.GetDecimal(11);
                    spe.specialistComment = reader.GetString(12);
                    spe.customerRate = reader.GetDecimal(13);
                    spe.customerComment = reader.GetString(14);
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