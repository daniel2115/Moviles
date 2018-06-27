using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosMovilkes.Models;
using System.Data.SqlClient;

namespace ServiciosMovilkes.Manager
{
    public class FavoriteManager
    {
        public List<Favorite> Obtener()
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Favorite> lista = new List<Favorite>();
            try
            {
                CustomerManager customerManager = new CustomerManager();
                SpecialistManager specialistManager = new SpecialistManager();

                string sql = "Select Id,Hidden,CustomerId,SpecialistId from Favorites";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Favorite spe = new Favorite();
                    spe.id = reader.GetInt32(0);
                    spe.hidden = reader.GetBoolean(1);
                    spe.customerId = reader.GetInt32(2);
                    spe.specialistId = reader.GetInt32(3);
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
        public Favorite Obtener(int id)
        {
            CustomerManager customerManager = new CustomerManager();
            SpecialistManager specialistManager = new SpecialistManager();

            Favorite spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "Select Id,Hidden,CustomerId,SpecialistId from Favorites where Id = @idFavorite";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@idFavorite", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new Favorite();
                spe.id = reader.GetInt32(0);
                spe.hidden = reader.GetBoolean(1);
                spe.customerId = reader.GetInt32(2);
                spe.specialistId = reader.GetInt32(3);
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return spe;
        }
        public Favorite Insertar(Favorite spe)
        {
            Favorite result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Insert into Favorites(Hidden,CustomerId,SpecialistId) output INSERTED.Id values(@hidden,@customer,@specialist)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@hidden", System.Data.SqlDbType.Int).Value = spe.hidden;
                cmd.Parameters.Add("@customer", System.Data.SqlDbType.Int).Value = spe.customerId;
                cmd.Parameters.Add("@specialist", System.Data.SqlDbType.Int).Value = spe.specialistId;
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
        public Favorite Editar(int id, Favorite spe)
        {
            Favorite result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update Favorites set Hidden = @hidden,CustomerId= @customer, SpecialistId = @specialist output INSERTED.Id where Id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@hidden", System.Data.SqlDbType.Bit).Value = spe.hidden;
                cmd.Parameters.Add("@customer", System.Data.SqlDbType.Int).Value = spe.customerId;
                cmd.Parameters.Add("@specialist", System.Data.SqlDbType.Int).Value = spe.specialistId;
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
        public Favorite Eliminar(int id)
        {
            Favorite temp = Obtener(id);
            temp.hidden = true;
            return Editar(id, temp);
        }
    }
}