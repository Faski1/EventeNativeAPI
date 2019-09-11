using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EventeNative_API.Util
{
    public class ExceptionHandler
    {
        public static string HandleException(EntityException error)
        {

            SqlException ex = error.InnerException as SqlException;

            switch (ex.Number)
            {
                case 2627:
                    {
                        return GetConstraintExceptionMessage(ex);
                    }
                default:
                    return ex.Message + "(" + ex.Number + ")";
            }
        }
        /*Message "Violation of UNIQUE KEY constraint 'CS_KorisnickoIme'. Cannot insert duplicate key in object 'dbo.Korisnici'. The duplicate key value is (farish).\r\nThe statement has been terminated."	string*/

        private static string GetConstraintExceptionMessage(SqlException error)
        {
            string newMessage = error.Message;
            int startIndex = newMessage.IndexOf("'");
            int endIndex = newMessage.IndexOf("'", startIndex + 1);

            if (startIndex > 0 && endIndex > 0)
            {
                string constraintName = newMessage.Substring(startIndex + 1, endIndex - startIndex - 1);

                if (constraintName == "CS_KorisnickoIme")
                    newMessage = "Username je zauzet";
                else if (constraintName == "CS_Email")
                    newMessage = "Email je zauzet";

            }
            return newMessage;
        }
    }
}