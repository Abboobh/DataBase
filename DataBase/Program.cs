using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace DataBase
{
    internal class Program
    {
       static void Main()
        {
            SQLConnector.ConnectionToSQL();

        }
    }
}