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
                    spe.Id = reader.GetInt32(0);
                    spe.Login = reader.GetString(1);
                    spe.Name = reader.GetString(2);
                    spe.LastName = reader.GetString(3);
                    spe.Email = reader.GetString(4);
                    spe.CompanyName = reader.GetString(5);
                    spe.ServiceDescription = reader.GetString(6);
                    spe.DocumentTypeId = reader.GetInt32(7);
                    spe.DocumentNumber = reader.GetString(8);
                    spe.PhoneNumber = reader.GetString(9);
                    spe.Facebook = reader.GetString(10);
                    spe.WebSite = reader.GetString(11);
                    spe.Address = reader.GetString(12);
                    spe.Reference = reader.GetString(13);
                    spe.Latitude = reader.GetDecimal(14);
                    spe.Longitude = reader.GetDecimal(15);
                    spe.Acredited = reader.GetBoolean(16);
                    spe.MemberShip = reader.GetBoolean(17);
                    spe.Rate = reader.GetDecimal(18);
                    spe.Online = reader.GetBoolean(19);
                    spe.State = reader.GetBoolean(20);                 
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
                spe.Id = reader.GetInt32(0);
                spe.Login = reader.GetString(1);
                spe.Password = reader.GetString(2);
                spe.Name = reader.GetString(3);
                spe.LastName = reader.GetString(4);
                spe.Email = reader.GetString(5);
                spe.CompanyName = reader.GetString(6);
                spe.ServiceDescription = reader.GetString(7);
                spe.DocumentTypeId = reader.GetInt32(8);
                spe.DocumentNumber = reader.GetString(9);
                spe.PhoneNumber = reader.GetString(10);
                spe.Facebook = reader.GetString(11);
                spe.WebSite = reader.GetString(12);
                spe.Address = reader.GetString(13);
                spe.Reference = reader.GetString(14);
                spe.Latitude = reader.GetDecimal(15);
                spe.Longitude = reader.GetDecimal(16);
                spe.Acredited = reader.GetBoolean(17);
                spe.MemberShip = reader.GetBoolean(18);
                spe.Rate = reader.GetDecimal(19);
                spe.Online = reader.GetBoolean(20);
                spe.State = reader.GetBoolean(21);    
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
            cmd.Parameters.Add("@specialistLogin", System.Data.SqlDbType.NVarChar).Value = obj.Login;
            cmd.Parameters.Add("@specialistPassword", System.Data.SqlDbType.NVarChar).Value = obj.Password;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                spe = new Specialist();
                spe.Id = reader.GetInt32(0);
                spe.Login = reader.GetString(1);
                spe.Password = reader.GetString(2);
                spe.Name = reader.GetString(3);
                spe.LastName = reader.GetString(4);
                spe.Email = reader.GetString(5);
                spe.CompanyName = reader.GetString(6);
                spe.ServiceDescription = reader.GetString(7);
                spe.DocumentTypeId = reader.GetInt32(8);
                spe.DocumentNumber = reader.GetString(9);
                spe.PhoneNumber = reader.GetString(10);
                spe.Facebook = reader.GetString(11);
                spe.WebSite = reader.GetString(12);
                spe.Address = reader.GetString(13);
                spe.Reference = reader.GetString(14);
                spe.Latitude = reader.GetDecimal(15);
                spe.Longitude = reader.GetDecimal(16);
                spe.Acredited = reader.GetBoolean(17);
                spe.MemberShip = reader.GetBoolean(18);
                spe.Rate = reader.GetDecimal(19);
                spe.Online = reader.GetBoolean(20);
                spe.State = reader.GetBoolean(21);     
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
                cmd.Parameters.Add("@login", System.Data.SqlDbType.VarChar).Value = spe.Login;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = spe.Password;
                cmd.Parameters.Add("@names", System.Data.SqlDbType.VarChar).Value = spe.Name;
                cmd.Parameters.Add("@lastnames", System.Data.SqlDbType.VarChar).Value = spe.LastName;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = spe.Email;
                cmd.Parameters.Add("@companyname", System.Data.SqlDbType.VarChar).Value = spe.CompanyName;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = spe.ServiceDescription;
                cmd.Parameters.Add("@doctype", System.Data.SqlDbType.Int).Value = spe.DocumentTypeId;
                cmd.Parameters.Add("@docnumber", System.Data.SqlDbType.VarChar).Value = spe.DocumentNumber;
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.Char).Value = spe.PhoneNumber;
                cmd.Parameters.Add("@facebook", System.Data.SqlDbType.VarChar).Value = spe.Facebook;
                cmd.Parameters.Add("@web", System.Data.SqlDbType.VarChar).Value = spe.WebSite;
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = spe.Address;
                cmd.Parameters.Add("@reference", System.Data.SqlDbType.VarChar).Value = spe.Reference;
                cmd.Parameters.Add("@latitud", System.Data.SqlDbType.Decimal).Value = spe.Latitude;
                cmd.Parameters.Add("@longitud", System.Data.SqlDbType.Decimal).Value = spe.Longitude;
                cmd.Parameters.Add("@acredited", System.Data.SqlDbType.Bit).Value = spe.Acredited;
                cmd.Parameters.Add("@membership", System.Data.SqlDbType.Bit).Value = spe.MemberShip;
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
                cmd.Parameters.Add("@login", System.Data.SqlDbType.VarChar).Value = spe.Login;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = spe.Password;
                cmd.Parameters.Add("@names", System.Data.SqlDbType.VarChar).Value = spe.Name;
                cmd.Parameters.Add("@lastnames", System.Data.SqlDbType.VarChar).Value = spe.LastName;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = spe.Email;
                cmd.Parameters.Add("@companyname", System.Data.SqlDbType.VarChar).Value = spe.CompanyName;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = spe.ServiceDescription;
                cmd.Parameters.Add("@doctype", System.Data.SqlDbType.Int).Value = spe.DocumentTypeId;
                cmd.Parameters.Add("@docnumber", System.Data.SqlDbType.VarChar).Value = spe.DocumentNumber;
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.Char).Value = spe.PhoneNumber;
                cmd.Parameters.Add("@facebook", System.Data.SqlDbType.VarChar).Value = spe.Facebook;
                cmd.Parameters.Add("@web", System.Data.SqlDbType.VarChar).Value = spe.WebSite;
                cmd.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = spe.Address;
                cmd.Parameters.Add("@reference", System.Data.SqlDbType.VarChar).Value = spe.Reference;
                cmd.Parameters.Add("@latitud", System.Data.SqlDbType.Decimal).Value = spe.Latitude;
                cmd.Parameters.Add("@longitud", System.Data.SqlDbType.Decimal).Value = spe.Longitude;
                cmd.Parameters.Add("@acredited", System.Data.SqlDbType.Bit).Value = spe.Acredited;
                cmd.Parameters.Add("@membership", System.Data.SqlDbType.Bit).Value = spe.MemberShip;
                cmd.Parameters.Add("@rate", System.Data.SqlDbType.Decimal).Value = spe.Rate;
                cmd.Parameters.Add("@online", System.Data.SqlDbType.Bit).Value = spe.Online;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Bit).Value = spe.State;
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
            temp.Online = false;
            return Editar(id, temp);
        }
        public List<Favorite> Favorite(int id)
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Favorite> lista = new List<Favorite>();
            try
            {
                string sql = "Select Id,Hidden,CustomerId,SpecialistId from Favorites where SpecialistId = @specialistId";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@specialistId", System.Data.SqlDbType.NVarChar).Value = id;
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