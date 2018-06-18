using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosMovilkes.Models;
using System.Data.SqlClient;

namespace ServiciosMovilkes.Manager
{
    public class CustomerManager
    {
        public List<Customer> Obtener()
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Customer> lista = new List<Customer>();
            try
            {
                string sql = "Select Id,Login,Names,LastNames,Email," +
                "DocumentTypeId,DocumentNumber,PhoneNumber,Address," +
                "Reference,Latitude,Longitude,Rate,"+
                "Online,State from Customers";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Customer spe = new Customer();
                    spe.Id = reader.GetInt32(0);
                    spe.Login = reader.GetString(1);
                    spe.Name = reader.GetString(2);
                    spe.LastName = reader.GetString(3);
                    spe.Email = reader.GetString(4);
                    spe.DocumentTypeId = reader.GetInt32(5);
                    spe.DocumentNumber = reader.GetString(6);
                    spe.PhoneNumber = reader.GetString(7);
                    spe.Address = reader.GetString(8);
                    spe.Reference = reader.GetString(9);
                    spe.Latitude = reader.GetDecimal(10);
                    spe.Longitude = reader.GetDecimal(11);
                    spe.Rate = reader.GetDecimal(12);
                    spe.Online = reader.GetBoolean(13);
                    spe.State = reader.GetBoolean(14);
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
        public Customer Obtener(int id)
        {
            Customer spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "Select Id,Login,Password,Names,LastNames,Email," +
              "DocumentTypeId,DocumentNumber,PhoneNumber,Address," +
              "Reference,Latitude,Longitude,Rate," +
              "Online,State from Customers where Id = @idClient";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@idClient", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new Customer();
                spe.Id = reader.GetInt32(0);
                spe.Login = reader.GetString(1);
                spe.Password = reader.GetString(2);
                spe.Name = reader.GetString(3);
                spe.LastName = reader.GetString(4);
                spe.Email = reader.GetString(5);
                spe.DocumentTypeId = reader.GetInt32(6);
                spe.DocumentNumber = reader.GetString(7);
                spe.PhoneNumber = reader.GetString(8);
                spe.Address = reader.GetString(9);
                spe.Reference = reader.GetString(10);
                spe.Latitude = reader.GetDecimal(11);
                spe.Longitude = reader.GetDecimal(12);
                spe.Rate = reader.GetDecimal(13);
                spe.Online = reader.GetBoolean(14);
                spe.State = reader.GetBoolean(15);
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return spe;
        }
        public Customer Authentication(Input obj)
        {
            Customer spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "Select Id,Login,Names,LastNames,Email," +
                "DocumentTypeId,DocumentNumber,PhoneNumber,Address," +
                "Reference,Latitude,Longitude,Rate,"  +
                "Online,State from Customers  where " +
                "Login = @EmailClient and Password = @clientPassword";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@EmailClient", System.Data.SqlDbType.NVarChar).Value = obj.Login;
            cmd.Parameters.Add("@clientPassword", System.Data.SqlDbType.NVarChar).Value = obj.Password;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new Customer();
                spe.Id = reader.GetInt32(0);
                spe.Login = reader.GetString(1);
                spe.Name = reader.GetString(2);
                spe.LastName = reader.GetString(3);
                spe.Email = reader.GetString(4);
                spe.DocumentTypeId = reader.GetInt32(5);
                spe.DocumentNumber = reader.GetString(6);
                spe.PhoneNumber = reader.GetString(7);
                spe.Address = reader.GetString(8);
                spe.Reference = reader.GetString(9);
                spe.Latitude = reader.GetDecimal(10);
                spe.Longitude = reader.GetDecimal(11);
                spe.Rate = reader.GetDecimal(12);
                spe.Online = reader.GetBoolean(13);
                spe.State = reader.GetBoolean(14);
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return spe;
        }
        public Customer Insertar(Customer spe)
        {
            Customer result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "insert into Customers(Login,Password,Names,LastNames,"+
                "Email,DocumentTypeId,DocumentNumber,PhoneNumber,Address,"+
                "Reference,Latitude,Longitude,Rate,Online,State) output INSERTED.Id " +
                "values(@login,@password,@name,@lastname,@email,@documenttypeid," +
                "@documentnumber,@phonenumber,@address,@reference,@latitude,@longitude,@rate,@online,@state)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@login", System.Data.SqlDbType.VarChar).Value = spe.Login;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = spe.Password;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = spe.Name;
                cmd.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar).Value = spe.LastName;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = spe.Email;
                cmd.Parameters.Add("@documenttypeid", System.Data.SqlDbType.Int).Value = spe.DocumentTypeId;
                cmd.Parameters.Add("@documentnumber", System.Data.SqlDbType.VarChar).Value = spe.DocumentNumber;
                cmd.Parameters.Add("@phonenumber", System.Data.SqlDbType.Char).Value = spe.PhoneNumber;          
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = spe.Address;
                cmd.Parameters.Add("@reference", System.Data.SqlDbType.VarChar).Value = spe.Reference;
                cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal).Value = spe.Latitude;
                cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal).Value = spe.Longitude;
                cmd.Parameters.Add("@rate", System.Data.SqlDbType.Decimal).Value = spe.Rate;
                cmd.Parameters.Add("@online", System.Data.SqlDbType.Bit).Value = spe.Online;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Bit).Value = spe.State;
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
        public Customer Editar(int id, Customer spe)
        {
            Customer result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update Customers set Login = @login,Password= @password, Names= @name," +
                    "LastNames = @lastname, Email = @email, DocumentTypeId = @documenttypeid, DocumentNumber = @documentnumber,"+
                    "PhoneNumber = @phonenumber, Address = @address, Reference = @reference, Latitude = @latitude," +
                    "Longitude = @longitude, Rate = @rate, Online = @online, @State = state output INSERTED.Id where Id = @id";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@login", System.Data.SqlDbType.VarChar).Value = spe.Login;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = spe.Password;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = spe.Name;
                cmd.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar).Value = spe.LastName;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = spe.Email;
                cmd.Parameters.Add("@documenttypeid", System.Data.SqlDbType.Int).Value = spe.DocumentTypeId;
                cmd.Parameters.Add("@documentnumber", System.Data.SqlDbType.VarChar).Value = spe.DocumentNumber;
                cmd.Parameters.Add("@phonenumber", System.Data.SqlDbType.Char).Value = spe.PhoneNumber;
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = spe.Address;
                cmd.Parameters.Add("@reference", System.Data.SqlDbType.VarChar).Value = spe.Reference;
                cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal).Value = spe.Latitude;
                cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal).Value = spe.Longitude;
                cmd.Parameters.Add("@rate", System.Data.SqlDbType.Decimal).Value = spe.Rate;
                cmd.Parameters.Add("@online", System.Data.SqlDbType.Bit).Value = spe.Online;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Bit).Value = spe.State;
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
        public Customer Eliminar(int id)
        {
            Customer temp = Obtener(id);
            temp.State = false;
            return Editar(id, temp);
        }
        public List<Favorite> Favorite(int id)
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Favorite> lista = new List<Favorite>();
            try
            {
                string sql = "Select Id,Hidden,CustomerId,SpecialistId from Favorites where CustomerId = @idClient";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@idClient", System.Data.SqlDbType.NVarChar).Value = id;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Favorite spe = new Favorite();
                    spe.Id = reader.GetInt32(0);
                    spe.Hidden = reader.GetBoolean(1);
                    spe.CustomerId = reader.GetInt32(2);
                    spe.SpecialistId = reader.GetInt32(3);
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
        public List<Problem> Problem(int id) {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Problem> lista = new List<Problem>();
            try
            {
                string sql = "select Id,CustomerId,Title,Description,State from Problems where Id = @problem";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@problem", System.Data.SqlDbType.NVarChar).Value = id;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Problem spe = new Problem();
                    spe.Id = reader.GetInt32(0);
                    spe.CustomerId = reader.GetInt32(1);
                    spe.Title = reader.GetString(2);
                    spe.Description = reader.GetString(3);
                    spe.State = reader.GetByte(4);
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