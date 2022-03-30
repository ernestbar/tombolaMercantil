using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace tombolaMercantil.Clases
{
    public class Sorteos_detalle
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_COD_SORTEO_DETALLE = "";
        private string _PV_COD_SORTEO = "";
        private Int64 _PB_NRO_SORTEO = 0;
        private string _PV_DESCRIPCION = "";
        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_COD_SORTEO_DETALLE { get { return _PV_COD_SORTEO_DETALLE; } set { _PV_COD_SORTEO_DETALLE = value; } }
        public string PV_COD_SORTEO { get { return _PV_COD_SORTEO; } set { _PV_COD_SORTEO = value; } }
        public Int64 PB_NRO_SORTEO { get { return _PB_NRO_SORTEO; } set { _PB_NRO_SORTEO = value; } }
        public string PV_DESCRIPCION { get { return _PV_DESCRIPCION; } set { _PV_DESCRIPCION = value; } }
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        public Sorteos_detalle(string pV_COD_SORTEO_DETALLE)
        {
            _PV_COD_SORTEO_DETALLE = pV_COD_SORTEO_DETALLE;
            RecuperarDatos();
        }
        public Sorteos_detalle(string pV_TIPO_OPERACION, string pV_COD_SORTEO_DETALLE, string pV_COD_SORTEO, string pV_DESCRIPCION,
            Int64 pB_NRO_SORTEO,  string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_COD_SORTEO = pV_COD_SORTEO;
            _PV_DESCRIPCION = pV_DESCRIPCION;
            _PB_NRO_SORTEO = pB_NRO_SORTEO;
            _PV_COD_SORTEO_DETALLE = pV_COD_SORTEO_DETALLE;
            _PV_USUARIO = pV_USUARIO;
        }

        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable PR_SOR_GET_SORTEOS_DETALLE(string pV_COD_SORTEO)
        {

            DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_GET_SORTEOS_DETALLE");
            db1.AddInParameter(cmd, "PV_COD_SORTEO", DbType.String, pV_COD_SORTEO);
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_GET_SORTEOS_DETALLE_IND");
                db1.AddInParameter(cmd, "PV_COD_SORTEO_DETALLE", DbType.String, _PV_COD_SORTEO_DETALLE);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _PV_DESCRIPCION = (string)dr["DESCRIPCION"];
                        _PB_NRO_SORTEO = Int64.Parse(dr["NRO_SORTEO"].ToString());
                        _PV_COD_SORTEO = (string)dr["COD_SORTEO"];
                    }
                }
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_ABM_SORTEOS_DETALLE");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                if (_PV_COD_SORTEO_DETALLE == "")
                    db1.AddInParameter(cmd, "PV_COD_SORTEO_DETALLE", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_COD_SORTEO_DETALLE", DbType.String, _PV_COD_SORTEO_DETALLE);
                db1.AddInParameter(cmd, "PV_COD_SORTEO", DbType.String, _PV_COD_SORTEO);
                db1.AddInParameter(cmd, "PB_NRO_SORTEO", DbType.Int64, _PB_NRO_SORTEO);
                db1.AddInParameter(cmd, "PV_DESCRIPCION", DbType.String, _PV_DESCRIPCION);
                
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
                resultado = "Se produjo un error al registrar||";
                return resultado;
            }
        }

        #endregion

    }
}