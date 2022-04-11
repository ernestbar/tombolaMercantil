using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace tombolaMercantil.Clases
{
    public class Sorteo_detalle_sorteos
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_COD_SORTEO = "";
        private string _PV_COD_SORTEO_DETALLE = "";
        private string _PV_CUPON = "";
        
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";

        private string _PV_DESC_TIPO_SORTEO = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_COD_SORTEO { get { return _PV_COD_SORTEO; } set { _PV_COD_SORTEO = value; } }
        public string PV_COD_SORTEO_DETALLE { get { return _PV_COD_SORTEO_DETALLE; } set { _PV_COD_SORTEO_DETALLE = value; } }
        public string PV_CUPON { get { return _PV_CUPON; } set { _PV_CUPON = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }

        #endregion

        #region Constructores
        public Sorteo_detalle_sorteos(string pV_COD_SORTEO)
        {
            _PV_COD_SORTEO = pV_COD_SORTEO;
            RecuperarDatos();
        }
        public Sorteo_detalle_sorteos(string pV_TIPO_OPERACION, string pV_COD_SORTEO, string pV_COD_SORTEO_DETALLE,
            string pV_CUPON, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_COD_SORTEO = pV_COD_SORTEO;
            _PV_COD_SORTEO_DETALLE = pV_COD_SORTEO_DETALLE;
            _PV_CUPON = pV_CUPON;
            _PV_USUARIO = pV_USUARIO;
        }

        #endregion

        #region Métodos que NO requieren constructor

        //public static DataTable PR_SOR_GET_EXPORT_CUPONERIA_CSV_TXT(string PV_SORTEO, string PV_TIPO)
        //{

        //    DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_GET_EXPORT_CUPONERIA_CSV_TXT");
        //    cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //    db1.AddInParameter(cmd, "PV_COD_SORTEO", DbType.String, PV_SORTEO);
        //    db1.AddInParameter(cmd, "PV_TIPO", DbType.Int64, PV_TIPO);
        //    return db1.ExecuteDataSet(cmd).Tables[0];
        //}
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                //DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_GET_SORTEOS_IND");
                //db1.AddInParameter(cmd, "PV_COD_SORTEO", DbType.String, _PV_COD_SORTEO);
                //cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                //DataTable dt = new DataTable();
                //dt = db1.ExecuteDataSet(cmd).Tables[0];
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        _PD_FECHA_DESDE = DateTime.Parse(dr["FECHA_DESDE"].ToString());
                //        _PD_FECHA_HASTA = DateTime.Parse(dr["FECHA_HASTA"].ToString());
                //        _PV_COD_SORTEO_DETALLE = (string)dr["DESCRIPCION"];
                //        _PD_FECHA_SORTEO = DateTime.Parse(dr["FECHA_SORTEO"].ToString());
                //        _PV_TIPO_SORTEO = (string)dr["TIPO_SORTEO"];
                //        _PV_CUPON = (string)dr["LOGO"];
                //        _PV_DESC_TIPO_SORTEO = (string)dr["DESC_TIPO_SORTEO"];
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
        }



        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_ABM_SORTEOS_DETALLE_SORTEO");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_COD_SORTEO", DbType.String, _PV_COD_SORTEO);
                db1.AddInParameter(cmd, "PV_COD_SORTEO_DETALLE", DbType.String, _PV_COD_SORTEO_DETALLE);
                db1.AddInParameter(cmd, "PV_CUPON", DbType.String, _PV_CUPON);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "|Se produjo un error al registrar|";
                return resultado;
            }
        }

        #endregion
    }
}