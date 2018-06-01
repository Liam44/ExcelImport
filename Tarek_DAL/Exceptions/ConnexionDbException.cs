using System;

namespace Tarek_DAL.Exceptions
{
    public class ConnexionDbException : Exception
    {
        private string TableName { get; set; }

        public override string Message
        {
            get
            {
                return "Error during connection to the database (table " + TableName + ").";
            }
        }

        public ConnexionDbException(string tableName) : base()
        {
            TableName = tableName;
        }
    }
}