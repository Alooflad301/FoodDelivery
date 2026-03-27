using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para4
{
    internal class AppData
    {
        public static DataSet userSet;
        public static DataSet TripSet;
        public static SqlDataAdapter sqlDataAdapter;
        public static SqlDataAdapter sqlDataAdapterFood;
    }
}