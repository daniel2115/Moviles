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
                    documenttypes.id = reader.GetInt32(0);
                    documenttypes.description = reader.GetString(1);
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
                documenttype.id = reader.GetInt32(0);
                documenttype.description = reader.GetString(1);
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
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = documenttypes.description;
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
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = documenttypes.description;
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

    }
}