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
                    spe.id = reader.GetInt32(0);
                    spe.login = reader.GetString(1);
                    spe.name = reader.GetString(2);
                    spe.lastName = reader.GetString(3);
                    spe.email = reader.GetString(4);
                    spe.document.id = reader.GetInt32(5);
                    spe.document.description = reader.GetString(6);
                    spe.phoneNumber = reader.GetString(7);
                    spe.address = reader.GetString(8);
                    spe.reference = reader.GetString(9);
                    spe.latitude = reader.GetDecimal(10);
                    spe.longitude = reader.GetDecimal(11);
                    spe.rate = reader.GetDecimal(12);
                    spe.online = reader.GetBoolean(13);
                    spe.state = reader.GetBoolean(14);
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
                spe.id = reader.GetInt32(0);
                spe.login = reader.GetString(1);
                spe.password = reader.GetString(2);
                spe.name = reader.GetString(3);
                spe.lastName = reader.GetString(4);
                spe.email = reader.GetString(5);
                spe.document.id = reader.GetInt32(6);
                spe.document.description = reader.GetString(7);
                spe.phoneNumber = reader.GetString(8);
                spe.address = reader.GetString(9);
                spe.reference = reader.GetString(10);
                spe.latitude = reader.GetDecimal(11);
                spe.longitude = reader.GetDecimal(12);
                spe.rate = reader.GetDecimal(13);
                spe.online = reader.GetBoolean(14);
                spe.state = reader.GetBoolean(15);
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
            cmd.Parameters.Add("@EmailClient", System.Data.SqlDbType.NVarChar).Value = obj.login;
            cmd.Parameters.Add("@clientPassword", System.Data.SqlDbType.NVarChar).Value = obj.password;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new Customer();
                spe.id = reader.GetInt32(0);
                spe.login = reader.GetString(1);
                spe.name = reader.GetString(2);
                spe.lastName = reader.GetString(3);
                spe.email = reader.GetString(4);
                spe.document.id = reader.GetInt32(5);
                spe.document.description = reader.GetString(6);
                spe.phoneNumber = reader.GetString(7);
                spe.address = reader.GetString(8);
                spe.reference = reader.GetString(9);
                spe.latitude = reader.GetDecimal(10);
                spe.longitude = reader.GetDecimal(11);
                spe.rate = reader.GetDecimal(12);
                spe.online = reader.GetBoolean(13);
                spe.state = reader.GetBoolean(14);
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
                cmd.Parameters.Add("@login", System.Data.SqlDbType.VarChar).Value = spe.login;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = spe.password;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = spe.name;
                cmd.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar).Value = spe.lastName;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = spe.email;
                cmd.Parameters.Add("@documenttypeid", System.Data.SqlDbType.Int).Value = spe.document.id;
                cmd.Parameters.Add("@documentnumber", System.Data.SqlDbType.VarChar).Value = spe.document.description;
                cmd.Parameters.Add("@phonenumber", System.Data.SqlDbType.Char).Value = spe.phoneNumber;          
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = spe.address;
                cmd.Parameters.Add("@reference", System.Data.SqlDbType.VarChar).Value = spe.reference;
                cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal).Value = spe.latitude;
                cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal).Value = spe.longitude;
                cmd.Parameters.Add("@rate", System.Data.SqlDbType.Decimal).Value = spe.rate;
                cmd.Parameters.Add("@online", System.Data.SqlDbType.Bit).Value = spe.online;
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
                cmd.Parameters.Add("@login", System.Data.SqlDbType.VarChar).Value = spe.login;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = spe.password;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = spe.name;
                cmd.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar).Value = spe.lastName;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = spe.email;
                cmd.Parameters.Add("@documenttypeid", System.Data.SqlDbType.Int).Value = spe.document.id;
                cmd.Parameters.Add("@documentnumber", System.Data.SqlDbType.VarChar).Value = spe.document.description;
                cmd.Parameters.Add("@phonenumber", System.Data.SqlDbType.Char).Value = spe.phoneNumber;
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = spe.address;
                cmd.Parameters.Add("@reference", System.Data.SqlDbType.VarChar).Value = spe.reference;
                cmd.Parameters.Add("@latitude", System.Data.SqlDbType.Decimal).Value = spe.latitude;
                cmd.Parameters.Add("@longitude", System.Data.SqlDbType.Decimal).Value = spe.longitude;
                cmd.Parameters.Add("@rate", System.Data.SqlDbType.Decimal).Value = spe.rate;
                cmd.Parameters.Add("@online", System.Data.SqlDbType.Bit).Value = spe.online;
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
        public Customer Eliminar(int id)
        {
            Customer temp = Obtener(id);
            temp.state = false;
            return Editar(id, temp);
        }
        public List<Favorite> Favorite(int id)
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Favorite> lista = new List<Favorite>();
            try
            {
                CustomerManager customerManager = new CustomerManager();
                SpecialistManager specialistManager = new SpecialistManager();

                string sql = "Select Id,Hidden,CustomerId,SpecialistId from Favorites where CustomerId = @idClient";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@idClient", System.Data.SqlDbType.NVarChar).Value = id;
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
        public List<Problem> Problem(int id) {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Problem> lista = new List<Problem>();
            try
            {
                string sql = "select Id,CustomerId,Title,Description,State from Problems where CustomerId = @problem";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@problem", System.Data.SqlDbType.NVarChar).Value = id;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Problem spe = new Problem();
                    spe.id = reader.GetInt32(0);
                    spe.customerId = reader.GetInt32(1);
                    spe.title = reader.GetString(2);
                    spe.description = reader.GetString(3);
                    spe.state = reader.GetByte(4);
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
        public List<Quotation> Quotations(int problemid)
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Quotation> lista = new List<Quotation>();
            try
            {
                string sql = "Select qu.Id,ProblemId,qu.SpecialistId,qu.Description,qu.Price," +
                "qu.EstimatedTime,qu.IncludesMaterials,qu.State,qu.StartDate," +
                "qu.FinishDate,qu.FinalPrice,qu.SpecialistRate,qu.SpecialistComment," +
                "qu.CustomerRate,qu.CustomerComment from Quotations qu" +
                "join Problems pro on pro.Id = qu.ProblemId" +
                "where pro.CustomerId = @problemid";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@problemid", System.Data.SqlDbType.NVarChar).Value = problemid;
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