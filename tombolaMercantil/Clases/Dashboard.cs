using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace tombolaMercantil.Clases
{
    public class Dashboard
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
       
        //Propiedades públicas
        
        #endregion

        #region Constructores
        
       
        #endregion

        #region Métodos que NO requieren constructor

        
        public static DataTable PR_GET_DASHBOARD(string PV_TIPO)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_GET_DASHBOARD");

                db1.AddInParameter(cmd, "PV_TIPO", DbType.String, PV_TIPO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        


        #endregion

        #region Métodos que requieren constructor
        

        #endregion
    }
}