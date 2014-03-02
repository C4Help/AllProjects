using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C4H_Webservice.Structure;
using System.Data.SqlClient;
using System.Data;

namespace C4H_Webservice.Managers
{
    public static class ServiceManager
    {

        public static List<ServiceType> GetServiceTypes()                   
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT serviceTypeID, serviceTypeName FROM [ServiceType]";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                List<ServiceType> types = new List<ServiceType>();

                foreach (DataRow row in table.Rows)
                {
                    int serviceTypeID = int.Parse(row["serviceTypeID"].ToString());
                    string serviceTypeName = row["serviceTypeName"].ToString();

                    types.Add(new ServiceType(serviceTypeID, serviceTypeName));
                }

                return types;
            }
            catch { return null; }
        }

        public static List<Structure.Service> GetServices()                 
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT serviceID, serviceName, serviceTypeID, (SELECT serviceTypeName FROM [ServiceType] WHERE [ServiceType].serviceTypeID = [Service].serviceTypeID) as serviceTypeName FROM [Service]";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                List<Structure.Service> services = new List<Structure.Service>();

                foreach (DataRow row in table.Rows)
                {
                    int serviceID = int.Parse(row["serviceID"].ToString());
                    string serviceName = row["serviceName"].ToString();

                    int serviceTypeID = int.Parse(row["serviceTypeID"].ToString());
                    string serviceTypeName = row["serviceTypeName"].ToString();

                    services.Add(new Structure.Service(serviceID, serviceName, new ServiceType(serviceTypeID, serviceTypeName)));
                }

                return services;
            }
            catch { return null; }
        }
        public static List<Structure.Service> GetServices(int ServiceTypeID)
        {
            try
            {
                //###########
                //# Command #
                //###########
                string command = "SELECT serviceID, serviceName, serviceTypeID, (SELECT serviceTypeName FROM [ServiceType] WHERE [ServiceType].serviceTypeID = [Service].serviceTypeID) as serviceTypeName FROM [Service] WHERE serviceTypeID = @serviceTypeID";

                //##############
                //# Parameters #
                //##############
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("serviceTypeID", ServiceTypeID));

                //#############
                //# Execution #
                //#############
                DataTable table = DatabaseManager.ExecuteDataQueryCommand(command, parameters.ToArray());

                if (table == null)
                    return null;

                //############
                //# Analysis #
                //############
                List<Structure.Service> services = new List<Structure.Service>();

                foreach (DataRow row in table.Rows)
                {
                    int serviceID = int.Parse(row["serviceID"].ToString());
                    string serviceName = row["serviceName"].ToString();

                    int serviceTypeID = int.Parse(row["serviceTypeID"].ToString());
                    string serviceTypeName = row["serviceTypeName"].ToString();

                    services.Add(new Structure.Service(serviceID, serviceName, new ServiceType(serviceTypeID, serviceTypeName)));
                }

                return services;
            }
            catch { return null; }
        }

    }
}