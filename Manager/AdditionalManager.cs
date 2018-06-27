using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosMovilkes.Models;
using System.Data.SqlClient;

namespace ServiciosMovilkes.Manager
{
    public class AdditionalManager
    {
        public Additional Obtener(int id)
        {
            Additional spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "select Id,QuotationId,Price,Description,State from Additionals where Id = @additional";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@additional", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new Additional();
                spe.id = reader.GetInt32(0);
                spe.quotation.id = reader.GetInt32(1);
                spe.price = reader.GetDecimal(2);
                spe.description = reader.GetString(3);
                spe.state = reader.GetByte(4);
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return spe;
        }
        public Additional Insertar(Additional spe)
        {
            Additional result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Insert into Additionals(QuotationId,Price,Description,State) output INSERTED.Id "+
                "values(@quotationid,@price,@description,@state)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@quotationid", System.Data.SqlDbType.Int).Value = spe.quotation.id;
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = spe.price;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.Int).Value = spe.description;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Int).Value = spe.state;
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
        public Additional Editar(int id, Additional spe)
        {
            Additional result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update Additionals set QuotationId = @quotationid,Price= @price " +
                    ",Description = @description,State = @state output INSERTED.Id where Id = @id";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@quotationid", System.Data.SqlDbType.Int).Value = spe.quotation.id;
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = spe.price;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.Int).Value = spe.description;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Int).Value = spe.state;
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
        public Additional Eliminar(int id)
        {
            Additional temp = Obtener(id);
            temp.state = 0;
            return Editar(id, temp);
        }

    }
}