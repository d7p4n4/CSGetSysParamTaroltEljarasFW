using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGetSysParamTaroltEljarasFW
{
    public class GetSysParamTaroltEljarasSapka
    {

        private SqlConnection AdatbazisKapcsolat { get; set; }

        public GetSysParamTaroltEljarasSapka() { }

        public GetSysParamTaroltEljarasSapka(SqlConnection connection)
        {
            AdatbazisKapcsolat = connection;
            AdatbazisKapcsolat.Open();
        }

        public string RendszerParameterLekerdezese(string rendszerParameterNeve)
        {
            string eredmeny = "";

            using (SqlCommand sqlUtasitas = new SqlCommand("SELECT dbo.GetSysParam(@sNev)", AdatbazisKapcsolat))
            {

                sqlUtasitas.CommandType = CommandType.Text;

                sqlUtasitas.Parameters.Add("@sNev", SqlDbType.VarChar).Value = rendszerParameterNeve;

                SqlDataReader olvaso = sqlUtasitas.ExecuteReader();

                if (olvaso.HasRows)
                {
                    while (olvaso.Read())
                    {
                        eredmeny = olvaso.GetString(0);
                    }
                }
                
            }
            return eredmeny;

        } // RendszerParameterLekerdezese
        
    }
}
