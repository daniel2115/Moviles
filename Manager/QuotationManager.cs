using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosMovilkes.Models;
using System.Data.SqlClient;


namespace ServiciosMovilkes.Manager
{
    public class QuotationManager
    {
        public Quotation Obtener(int id)
        {
            Quotation spe = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            string sql = "select Id,ProblemId,SpecialistId,Description,"+
            "Price,EstimatedTime,IncludesMaterials,State,"+
            "StartDate,FinishDate,FinalPrice,SpecialistRate,"+
            "SpecialistComment,CustomerRate,CustomerComment from Quotations where Id = @quotation";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@quotation", System.Data.SqlDbType.NVarChar).Value = id;
            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                ProblemManager problemManager = new ProblemManager();
                SpecialistManager specialistManager = new SpecialistManager();

                spe = new Quotation();
                spe.id = reader.GetInt32(0);
                spe.problem = problemManager.Obtener(reader.GetInt32(1));
                spe.specialist = specialistManager.Obtener(reader.GetInt32(2));
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
            }
            reader.Close();
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return spe;
        }
        public Quotation Insertar(Quotation spe)
        {
            Quotation result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Insert into Quotations(ProblemId,SpecialistId,Description,Price,EstimatedTime"+
                ",IncludesMaterials,State,StartDate,FinishDate,FinalPrice,SpecialistRate,SpecialistComment"+
                ",CustomerRate,CustomerComment) output INSERTED.Id values(@problemid,@specialistid,@description"+
                ",@price,@estimatedtime,@includesmaterials,@state,@startdate,@finishdate,@finalprice"+
                ",@specialistrate,@specialistcomment,@customerrate,@customercomment)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@problemid", System.Data.SqlDbType.Int).Value = spe.problem.id;
                cmd.Parameters.Add("@specialistid", System.Data.SqlDbType.Int).Value = spe.specialist.id;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = spe.description;
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Decimal).Value = spe.price;
                cmd.Parameters.Add("@estimatedtime", System.Data.SqlDbType.Bit).Value = spe.estimatedTime;
                cmd.Parameters.Add("@includesmaterials", System.Data.SqlDbType.Bit).Value = spe.includesMaterial;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Bit).Value = spe.state;
                cmd.Parameters.Add("@startdate", System.Data.SqlDbType.DateTime).Value = spe.startDate;
                cmd.Parameters.Add("@finishdate", System.Data.SqlDbType.DateTime).Value = spe.finishDate;
                cmd.Parameters.Add("@finalprice", System.Data.SqlDbType.Decimal).Value = spe.finalPrice;
                cmd.Parameters.Add("@specialistrate", System.Data.SqlDbType.Decimal).Value = spe.specialistRate;
                cmd.Parameters.Add("@specialistcomment", System.Data.SqlDbType.VarChar).Value = spe.specialistComment;
                cmd.Parameters.Add("@customerrate", System.Data.SqlDbType.Decimal).Value = spe.customerRate;
                cmd.Parameters.Add("@customercomment", System.Data.SqlDbType.VarChar).Value = spe.customerComment;  
                int modified = (int)cmd.ExecuteScalar();
                if (modified != 0)
                {
                    ProblemManager problemManager = new ProblemManager();
                    SpecialistManager specialistManager = new SpecialistManager();

                    result = Obtener(modified);
                    result.specialist =  specialistManager.Obtener(result.specialist.id);
                    result.problem = problemManager.Obtener(result.problem.id);
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
        public Quotation Editar(int id, Quotation spe)
        {
            Quotation result = null;
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            try
            {
                string sql = "Update Quotations set ProblemId = @problemid,SpecialistId= @specialistid"+
                    ",Description = @description,Price = @price,EstimatedTime=@estimatedtime,IncludesMaterials=@includesmaterials"+
                    ",State=@state,StartDate=@startdate,FinishDate=@finishdate,FinalPrice=@finalprice,SpecialistRate=@specialistrate"+
                    ",SpecialistComment=@specialistcomment,CustomerRate=@customerrate,CustomerComment=@customercomment "+
                    "output INSERTED.Id where Id = @id";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@problemid", System.Data.SqlDbType.Int).Value = spe.problem.id;
                cmd.Parameters.Add("@specialistid", System.Data.SqlDbType.Int).Value = spe.specialist.id;
                cmd.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = spe.description;
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Decimal).Value = spe.price;
                cmd.Parameters.Add("@estimatedtime", System.Data.SqlDbType.Bit).Value = spe.estimatedTime;
                cmd.Parameters.Add("@includesmaterials", System.Data.SqlDbType.Bit).Value = spe.includesMaterial;
                cmd.Parameters.Add("@state", System.Data.SqlDbType.Bit).Value = spe.state;
                cmd.Parameters.Add("@startdate", System.Data.SqlDbType.DateTime).Value = spe.startDate;
                cmd.Parameters.Add("@finishdate", System.Data.SqlDbType.DateTime).Value = spe.finishDate;
                cmd.Parameters.Add("@finalprice", System.Data.SqlDbType.Decimal).Value = spe.finalPrice;
                cmd.Parameters.Add("@specialistrate", System.Data.SqlDbType.Decimal).Value = spe.specialistRate;
                cmd.Parameters.Add("@specialistcomment", System.Data.SqlDbType.VarChar).Value = spe.specialistComment;
                cmd.Parameters.Add("@customerrate", System.Data.SqlDbType.Decimal).Value = spe.customerRate;
                cmd.Parameters.Add("@customercomment", System.Data.SqlDbType.VarChar).Value = spe.customerComment;  
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
        public Quotation Eliminar(int id)
        {
            Quotation temp = Obtener(id);
            temp.state = 2;
            return Editar(id, temp);
        }
        public List<Additional> Additional(int id) {
            SqlConnection con = new SqlConnection(Resource.CadenaConexion);
            con.Open();
            List<Additional> lista = new List<Additional>();
            try
            {
                string sql = "select Id,QuotationId,Price,Description,State from Additionals where QuotationId = @quotationid";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@quotationid", System.Data.SqlDbType.NVarChar).Value = id;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Additional spe = new Additional();
                    spe.id = reader.GetInt32(0);
                    spe.quotation.id = reader.GetInt32(1);
                    spe.price = reader.GetDecimal(2);
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

    }
}