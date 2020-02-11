using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGetSysParamTaroltEljarasFW
{
    public class GetSysParamDBCap
    {

        private SqlConnection AdatbazisKapcsolat { get; set; }

        public GetSysParamDBCap() { }

        public GetSysParamDBCap(SqlConnection connection)
        {
            AdatbazisKapcsolat = connection;
            AdatbazisKapcsolat.Open();
        }

        public string RendszerParameterLekerdezese(string rendszerParameterNeve)
        {
            string eredmeny = "";

            using (SqlCommand sqlUtasitas = new SqlCommand("select dbo.GetSysParam(@sNev)", AdatbazisKapcsolat))
            {

                sqlUtasitas.CommandType = CommandType.StoredProcedure;

                sqlUtasitas.Parameters.AddWithValue("@sNev", rendszerParameterNeve);
                eredmeny = (string)sqlUtasitas.ExecuteScalar();
                
            }
            return eredmeny;

        } // RendszerParameterLekerdezese

        public string RendszerParameterLekerdezeseSql(string rendszerParameterNeve)
        {
            string eredmeny = "";
            string sql = "select dbo.GetSysParam(@sNev)";
            using (SqlCommand sqlUtasitas = new SqlCommand(sql, AdatbazisKapcsolat))
            {

                //sqlUtasitas.CommandType = CommandType.StoredProcedure;

                sqlUtasitas.Parameters.Add("@sNev", SqlDbType.VarChar).Value = rendszerParameterNeve;
                sqlUtasitas.ExecuteNonQuery();
                eredmeny = (string)sqlUtasitas.Parameters["@sNev"].Value;

            }
            return eredmeny;

        } // RendszerParameterLekerdezese
    }
}
