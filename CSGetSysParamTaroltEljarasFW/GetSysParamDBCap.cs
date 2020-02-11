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

            using (SqlCommand sqlUtasitas = new SqlCommand("GetSysParam", AdatbazisKapcsolat))
            {

                sqlUtasitas.CommandType = CommandType.StoredProcedure;

                sqlUtasitas.Parameters.Add("@sNev", SqlDbType.VarChar).Value = rendszerParameterNeve;

                SqlDataReader reader = sqlUtasitas.ExecuteReader();

                while (reader.Read())
                {
                    eredmeny = (string)sqlUtasitas.Parameters["@sNev"].Value;
                }
                reader.Close();
            }
            return eredmeny;

        } // RendszerParameterLekerdezese
    }
}
