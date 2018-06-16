using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosMovilkes.Models;
using System.Data.SqlClient;

namespace ServiciosMovilkes.Manager
{
    public class DocumentTypeManager
    {
        public List<DocumentType> Obtener()
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<DocumentType> lista = new List<DocumentType>();
            try
            {
                string sql = "Select Id,Description from DocumentTypes";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    DocumentType documenttypes = new DocumentType();
                    documenttypes.Id = reader.GetInt32(0);
                    documenttypes.Description = reader.GetString(1);
                    lista.Add(documenttypes);
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
        public DocumentType Obtener(int id)
        {
            DocumentType documenttype = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "Select Id,Description from DocumentTypes where Id = @idDocType";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@idDocType", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                documenttype = new DocumentType();
                documenttype.Id = reader.GetInt32(0);
                documenttype.Description = reader.GetString(1);
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return documenttype;
        }
        public DocumentType Insertar(DocumentType documenttypes)
        {
            DocumentType result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Insert into DocumentTypes(Description)" +
                    " output INSERTED.Id values(@description)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = documenttypes.Description;
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
        public DocumentType Editar(int id, DocumentType documenttypes)
        {
            DocumentType result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update DocumentType set Description = @description output INSERTED.Id where Id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = documenttypes.Description;
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
        public List<Specialist> Specialist(int id) {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Specialist> lista = new List<Specialist>();
            try
            {
                string sql = "select Id,Login,Password,Names,LastNames," +
                "Email,CompanyName,ServiceDescription," +
                "DocumentTypeId,DocumentNumber,PhoneNumber," +
                "Facebook,Website,Address,Reference,Latitude," +
                "Longitude,Accredited,Membership,Rate," +
                "Online,State from Specialists where DocumentTypeId = @documentid";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@documentid", System.Data.SqlDbType.NVarChar).Value = id;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Specialist spe = new Specialist();
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
        public List<Customer> Customer(int id)
        {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Customer> lista = new List<Customer>();
            try
            {
                string sql = "Select Id,Login,Names,LastNames,Email," +
                "DocumentTypeId,DocumentNumber,PhoneNumber,Address," +
                "Reference,Latitude,Longitude,Rate," +
                "Online,State from Customers where DocumentTypeId = @documentid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@documentid", System.Data.SqlDbType.NVarChar).Value = id;
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

    }
}