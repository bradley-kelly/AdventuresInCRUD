using System.Configuration;

namespace AdventuresInCRUD
{
    public static class DB
    {
        public static string getConnection()
        {
            string myConn = ConfigurationManager.AppSettings["myConn"].ToString();
            return myConn;
        }
    }
}
