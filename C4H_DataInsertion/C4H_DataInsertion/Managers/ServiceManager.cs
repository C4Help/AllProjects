using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace C4H_DataInsertion.Managers
{
    public class ServiceManager
    {

        public static bool AddServiceType(string Name, List<string> Services)   
        {
            int ID = addServiceType(Name);

            if (ID == -1)
                return false;

            foreach (string service in Services)
                addService(ID, service);

            return true;
        }

        private static int addServiceType(string Name)                          
        {
            try
            {
                //###########
                //# Command #
                //###########

                string command = "INSERT INTO [ServiceType] (serviceTypeName) "
                    + "output INSERTED.serviceTypeID "
                    + "VALUES (@serviceTypeName)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@serviceTypeName", Name));

                //#############
                //# Execution #
                //#############
                int ID = DatabaseManager.ExecuteScalarQueryCommand(command, parameters.ToArray());

                return ID;
            }
            catch { return -1; }
        }
        private static bool addService(int ServiceTypeID, string Name)          
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "INSERT INTO [Service] (serviceTypeID, serviceName) "
                    + "VALUES (@serviceTypeID, @serviceName)";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@serviceTypeID", ServiceTypeID));
                parameters.Add(new SqlParameter("@serviceName", Name));

                //#############
                //# Execution #
                //#############
                bool valid = DatabaseManager.ExecuteNonQueryCommand(command, parameters.ToArray());

                return valid;
            }
            catch { return false; }
        }

    }
}
