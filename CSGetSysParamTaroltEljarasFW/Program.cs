using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGetSysParamTaroltEljarasFW
{
    class Program
    {
        public static string APPLICATIOPARAMETER_ADATBAZISKAPCSOLAT = ConfigurationManager.ConnectionStrings[
                                "KapcsolatParameter"
                            ].ConnectionString;
        public static void Main(string[] args)
        {
            GetSysParamDBCap getSysParamDBCap = new GetSysParamDBCap(new System.Data.SqlClient.SqlConnection(APPLICATIOPARAMETER_ADATBAZISKAPCSOLAT));
            getSysParamDBCap.RendszerParameterLekerdezese("K59verzio");
        }

    }
}
