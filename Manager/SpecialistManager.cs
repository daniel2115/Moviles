using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosMovilkes.Models;
using System.Data.SqlClient;

namespace ServiciosMovilkes.Manager
{
    public class SpecialistManager
    {
        public List<Specialist> Obtener()
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Specialist> lista = new List<Specialist>();
            try
            {
                string sql = "select Id,Login,Names,LastNames,"+
                "Email,CompanyName,ServiceDescription,"+
                "DocumentTypeId,DocumentNumber,PhoneNumber,"+
                "Facebook,Website,Address,Reference,Latitude,"+
                "Longitude,Accredited,Membership,Rate,"+
                "Online,State from Specialists";
 
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Specialist spe = new Specialist();
                    spe.id = reader.GetInt32(0);
                    spe.login = reader.GetString(1);
                    spe.name = reader.GetString(2);
                    spe.lastName = reader.GetString(3);
                    spe.email = reader.GetString(4);
                    spe.companyName = reader.GetString(5);
                    spe.serviceDescription = reader.GetString(6);
                    spe.document.id = reader.GetInt32(7);
                    spe.document.description = reader.GetString(8);
                    spe.phoneNumber = reader.GetString(9);
                    spe.facebook = reader.GetString(10);
                    spe.webSite = reader.GetString(11);
                    spe.address = reader.GetString(12);
                    spe.reference = reader.GetString(13);
                    spe.latitude = reader.GetDecimal(14);
                    spe.longitude = reader.GetDecimal(15);
                    spe.acredited = reader.GetBoolean(16);
                    spe.memberShip = reader.GetBoolean(17);
                    spe.rate = reader.GetDecimal(18);
                    spe.online = reader.GetBoolean(19);
                    spe.state = reader.GetBoolean(20);                 
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
        public Specialist Obtener(int id)
        {
            Specialist spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "select Id,Login,Password,Names,LastNames," +
              "Email,CompanyName,ServiceDescription," +
              "DocumentTypeId,DocumentNumber,PhoneNumber," +
              "Facebook,Website,Address,Reference,Latitude," +
              "Longitude,Accredited,Membership,Rate," +
              "Online,State from Specialists where Id = @idSpecialist";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@idSpecialist", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new Specialist();
                spe.id = reader.GetInt32(0);
                spe.login = reader.GetString(1);
                spe.password = reader.GetString(2);
                spe.name = reader.GetString(3);
                spe.lastName = reader.GetString(4);
                spe.email = reader.GetString(5);
                spe.companyName = reader.GetString(6);
                spe.serviceDescription = reader.GetString(7);
                spe.document.id = reader.GetInt32(8);
                spe.document.description = reader.GetString(9);
                spe.phoneNumber = reader.GetString(10);
                spe.facebook = reader.GetString(11);
                spe.webSite = reader.GetString(12);
                spe.address = reader.GetString(13);
                spe.reference = reader.GetString(14);
                spe.latitude = reader.GetDecimal(15);
                spe.longitude = reader.GetDecimal(16);
                spe.acredited = reader.GetBoolean(17);
                spe.memberShip = reader.GetBoolean(18);
                spe.rate = reader.GetDecimal(19);
                spe.online = reader.GetBoolean(20);
                spe.state = reader.GetBoolean(21);    
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return spe;
        }
        public Specialist Authentication(Input obj)
        {
            Specialist spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();

            string sql = "select Id,Login,Password,Names,LastNames," +
            "Email,CompanyName,ServiceDescription," +
            "DocumentTypeId,DocumentNumber,PhoneNumber," +
            "Facebook,Website,Address,Reference,Latitude," +
            "Longitude,Accredited,Membership,Rate," +
            "Online,State from Specialists where Login = @specialistLogin and Password = @specialistPassword";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@specialistLogin", System.Data.SqlDbType.NVarChar).Value = obj.login;
            cmd.Parameters.Add("@specialistPassword", System.Data.SqlDbType.NVarChar).Value = obj.password;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new Specialist();
                spe.id = reader.GetInt32(0);
                spe.login = reader.GetString(1);
                spe.password = reader.GetString(2);
                spe.name = reader.GetString(3);
                spe.lastName = reader.GetString(4);
                spe.email = reader.GetString(5);
                spe.companyName = reader.GetString(6);
                spe.serviceDescription = reader.GetString(7);
                spe.document.id = reader.GetInt32(8);
                spe.document.description = reader.GetString(9);
                spe.phoneNumber = reader.GetString(10);
                spe.facebook = reader.GetString(11);
                spe.webSite = reader.GetString(12);
                spe.address = reader.GetString(13);
                spe.reference = reader.GetString(14);
                spe.latitude = reader.GetDecimal(15);
                spe.longitude = reader.GetDecimal(16);
                spe.acredited = reader.GetBoolean(17);
                spe.memberShip = reader.GetBoolean(18);
                spe.rate = reader.GetDecimal(19);
                spe.online = reader.GetBoolean(20);
                spe.state = reader.GetBoolean(21);     
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return spe;
        }
        public Specialist Insertar(Specialist spe)
        {
            Specialist result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Insert into Specialists(Login,Password,Names,"+
                    "LastNames,Email,CompanyName,ServiceDescription,DocumentTypeId,DocumentNumber,"+
                    "PhoneNumber,Facebook,WebSite,Address,Reference,Latitude,"+
                    "Longitude,Accredited,Membership,Rate,Online,State)"+ 
                    " output INSERTED.Id values(@login,@password,@names,@lastnames,@email,@companyname,@description,@doctype,@docnumber,"+
                    "@phone,@facebook,@web,@address,@reference,@latitud,@longitud,@acredited,@membership,@rate,@online,@state)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@login", System.Data.SqlDbType.VarChar).Value = spe.login;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = spe.password;
                cmd.Parameters.Add("@names", System.Data.SqlDbType.VarChar).Value = spe.name;
                cmd.Parameters.Add("@lastnames", System.Data.SqlDbType.VarChar).Value = spe.lastName;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = spe.email;
                cmd.Parameters.Add("@companyname", System.Data.SqlDbType.VarChar).Value = spe.companyName;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = spe.serviceDescription;
                cmd.Parameters.Add("@doctype", System.Data.SqlDbType.Int).Value = spe.document.id;
                cmd.Parameters.Add("@docnumber", System.Data.SqlDbType.VarChar).Value = spe.document.description;
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.Char).Value = spe.phoneNumber;
                cmd.Parameters.Add("@facebook", System.Data.SqlDbType.VarChar).Value = spe.facebook;
                cmd.Parameters.Add("@web", System.Data.SqlDbType.VarChar).Value = spe.webSite;
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = spe.address;
                cmd.Parameters.Add("@reference", System.Data.SqlDbType.VarChar).Value = spe.reference;
                cmd.Parameters.Add("@latitud", System.Data.SqlDbType.Decimal).Value = spe.latitude;
                cmd.Parameters.Add("@longitud", System.Data.SqlDbType.Decimal).Value = spe.longitude;
                cmd.Parameters.Add("@acredited", System.Data.SqlDbType.Bit).Value = spe.acredited;
                cmd.Parameters.Add("@membership", System.Data.SqlDbType.Bit).Value = spe.memberShip;
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
        public Specialist Editar(int id, Specialist spe)
        {
            Specialist result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update Specialists set Login = @login,Password = @password,Names = @names," +
                    "LastNames = @lastnames,Email=@email,CompanyName = @companyname,ServiceDescription = @description," +
                    "DocumentTypeId = @doctype, DocumentNumber = @docnumber, PhoneNumber = @phone, Facebook = @facebook," +
                    "WebSite = @web, Address = @address , Reference = @reference , Latitude = @latitud," +
                    "Longitude = @longitud, Accredited = @acredited , Membership = @membership, Rate = @rate," +
                    "Online = @online,State = @state output INSERTED.Id where Id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@login", System.Data.SqlDbType.VarChar).Value = spe.login;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = spe.password;
                cmd.Parameters.Add("@names", System.Data.SqlDbType.VarChar).Value = spe.name;
                cmd.Parameters.Add("@lastnames", System.Data.SqlDbType.VarChar).Value = spe.lastName;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = spe.email;
                cmd.Parameters.Add("@companyname", System.Data.SqlDbType.VarChar).Value = spe.companyName;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = spe.serviceDescription;
                cmd.Parameters.Add("@doctype", System.Data.SqlDbType.Int).Value = spe.document.id;
                cmd.Parameters.Add("@docnumber", System.Data.SqlDbType.VarChar).Value = spe.document.description;
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.Char).Value = spe.phoneNumber;
                cmd.Parameters.Add("@facebook", System.Data.SqlDbType.VarChar).Value = spe.facebook;
                cmd.Parameters.Add("@web", System.Data.SqlDbType.VarChar).Value = spe.webSite;
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = spe.address;
                cmd.Parameters.Add("@reference", System.Data.SqlDbType.VarChar).Value = spe.reference;
                cmd.Parameters.Add("@latitud", System.Data.SqlDbType.Decimal).Value = spe.latitude;
                cmd.Parameters.Add("@longitud", System.Data.SqlDbType.Decimal).Value = spe.longitude;
                cmd.Parameters.Add("@acredited", System.Data.SqlDbType.Bit).Value = spe.acredited;
                cmd.Parameters.Add("@membership", System.Data.SqlDbType.Bit).Value = spe.memberShip;
                cmd.Parameters.Add("@rate", System.Data.SqlDbType.Decimal).Value = spe.rate;
                cmd.Parameters.Add("@online", System.Data.SqlDbType.Bit).Value = spe.online;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Bit).Value = spe.state;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                int modified = (int)cmd.ExecuteScalar();
                if (modified != 0)
                {
                    result = Obtener(modified);
                }
            }catch(Exception e){
                Console.WriteLine(e);
                result = null;
            }
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return result;
        }
        public Specialist Eliminar(int id)
        {
            Specialist temp = Obtener(id);
            temp.online = false;
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

                string sql = "Select Id,Hidden,CustomerId,SpecialistId from Favorites where SpecialistId = @specialistId";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@specialistId", System.Data.SqlDbType.NVarChar).Value = id;
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
        public List<SpecialistTag> SpecialistTag(int id)
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<SpecialistTag> lista = new List<SpecialistTag>();
            try
            {
                string sql = "Select Id,TagId,SpecialistId from SpecialistTags where SpecialistId = @specialistId";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@specialistId", System.Data.SqlDbType.NVarChar).Value = id;
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
        public List<Quotation> Quotations(int id) {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Quotation> lista = new List<Quotation>();
            try
            {
                string sql = "Select Id,ProblemId,SpecialistId,Description,Price,"+
                "EstimatedTime,IncludesMaterials,State,StartDate,"+
                "FinishDate,FinalPrice,SpecialistRate,SpecialistComment,"+
                "CustomerRate,CustomerComment from Quotations where SpecialistId = @specialistId";
             
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@specialistId", System.Data.SqlDbType.NVarChar).Value = id;
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