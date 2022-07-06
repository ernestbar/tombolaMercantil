using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace tombolaMercantil.Clases
{
    public class Importacion
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_COD_IMPORTACION_DATOS = "";
        private string _PV_COD_IMPORTACION_DATOS_DETALLE = "";
        //cabecera
        private string _PV_COD_SORTEO = "";
        private string _PV_TIPO_ARCHIVO = "";
        private string _PV_RUTA = "";
        //detalle
        private string _PV_PRODUCTO_NIVEL = "";
        private string _PV_CODIGO_CLIENTE = "";
        private string _PV_CLIENTE = "";
        private string _PV_IDENTIFICACION = "";
        private string _PV_CUENTA = "";
        private string _PV_MONEDA = "";
        private string _PV_SUCURSAL_ASIGNADA = "";
        private string _PV_BANCA = "";
        private Int64 _PV_CUPONES_FINAL = 0;

        private string _PV_USUARIO = "";
        private string _PV_COD_IMPORTACION_DATOS_OUT = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_COD_IMPORTACION_DATOS { get { return _PV_COD_IMPORTACION_DATOS; } set { _PV_COD_IMPORTACION_DATOS = value; } }
        public string PV_COD_IMPORTACION_DATOS_DETALLE { get { return _PV_COD_IMPORTACION_DATOS_DETALLE; } set { _PV_COD_IMPORTACION_DATOS_DETALLE = value; } }
        /// cabecera
        public string PV_COD_SORTEO { get { return _PV_COD_SORTEO; } set { _PV_COD_SORTEO = value; } }
        public string PV_TIPO_ARCHIVO { get { return _PV_TIPO_ARCHIVO; } set { _PV_TIPO_ARCHIVO = value; } }
        public string PV_RUTA { get { return _PV_RUTA; } set { _PV_RUTA = value; } }
        /// detalle
        public string PV_PRODUCTO_NIVEL { get { return _PV_PRODUCTO_NIVEL; } set { _PV_PRODUCTO_NIVEL = value; } }
        public string PV_CODIGO_CLIENTE { get { return _PV_CODIGO_CLIENTE; } set { _PV_CODIGO_CLIENTE = value; } }
        public string PV_CLIENTE { get { return _PV_CLIENTE; } set { _PV_CLIENTE = value; } }
        public string PV_IDENTIFICACION { get { return _PV_IDENTIFICACION; } set { _PV_IDENTIFICACION = value; } }
        public string PV_CUENTA { get { return _PV_CUENTA; } set { _PV_CUENTA = value; } }
        public string PV_MONEDA { get { return _PV_MONEDA; } set { _PV_MONEDA = value; } }
        public string PV_SUCURSAL_ASIGNADA { get { return _PV_SUCURSAL_ASIGNADA; } set { _PV_SUCURSAL_ASIGNADA = value; } }
        public string PV_BANCA { get { return _PV_BANCA; } set { _PV_BANCA = value; } }
        public Int64 PV_CUPONES_FINAL { get { return _PV_CUPONES_FINAL; } set { _PV_CUPONES_FINAL = value; } }
        

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_COD_IMPORTACION_DATOS_OUT { get { return _PV_COD_IMPORTACION_DATOS_OUT; } set { _PV_COD_IMPORTACION_DATOS_OUT = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        
        public Importacion(string pV_TIPO_OPERACION, string pV_COD_IMPORTACION_DATOS, string pV_COD_IMPORTACION_DATOS_DETALLE,
         string pV_COD_SORTEO, string pV_TIPO_ARCHIVO, string pV_RUTA,
         string pV_PRODUCTO_NIVEL, string pV_CODIGO_CLIENTE ,string pV_CLIENTE,string pV_IDENTIFICACION,
        string pV_CUENTA,string pV_MONEDA,string pV_SUCURSAL_ASIGNADA,string pV_BANCA,Int64 pV_CUPONES_FINAL,
        string pV_USUARIO )
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_COD_IMPORTACION_DATOS = pV_COD_IMPORTACION_DATOS;
            _PV_COD_IMPORTACION_DATOS_DETALLE = pV_COD_IMPORTACION_DATOS_DETALLE;
            _PV_COD_SORTEO = pV_COD_SORTEO;
            _PV_TIPO_ARCHIVO = pV_TIPO_ARCHIVO;
            _PV_PRODUCTO_NIVEL = pV_PRODUCTO_NIVEL;
            _PV_RUTA = pV_RUTA;
            _PV_CODIGO_CLIENTE = pV_CODIGO_CLIENTE;
            _PV_CLIENTE = pV_CLIENTE;
            _PV_IDENTIFICACION = pV_IDENTIFICACION;
            _PV_CUENTA = pV_CUENTA;
            _PV_MONEDA = pV_MONEDA;
            _PV_SUCURSAL_ASIGNADA = pV_SUCURSAL_ASIGNADA;
            _PV_BANCA = pV_BANCA;
            _PV_CUPONES_FINAL = pV_CUPONES_FINAL;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        public static DataTable Lista()
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_GET_IMPORTACION_DATOS");
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

        public static DataTable PR_SOR_GET_IMPORTACION_DATOS_DETALLE(string PV_COD_IMPORTACION_DATOS)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_GET_IMPORTACION_DATOS_DETALLE");
                db1.AddInParameter(cmd, "COD_IMPORTACION_DATOS", DbType.String, PV_COD_IMPORTACION_DATOS);
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

        public static void limpiar()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_LIMPIABUFFER");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                //return "|" + ex.ToString() + "|";
            }

        }


        #endregion

        #region Métodos que requieren constructor
        public static string PR_SOR_ABM_IMPORTACION_CUPON(string PV_TIPO_OPERACION,  string PV_COD_IMPORTACION_DATOS, string PV_USUARIO)
        {
            try
            {
                string resultado = "";
                DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_ABM_IMPORTACION_CUPON_MASIVO");
                //db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_COD_IMPORTACION_DATOS", DbType.String, PV_COD_IMPORTACION_DATOS);
                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, PV_USUARIO);
                //db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                cmd.CommandTimeout = 0;
                db1.ExecuteNonQuery(cmd);
                string PV_ESTADOPR = "";
                string PV_DESCRIPCIONPR = "";
                string PV_ERROR = "";
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                //    PV_ERROR = "";
                //else
                //    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");



                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" +PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                return "|" + ex.ToString()+"|";
            }

        }

        public static string PR_SOR_ABM_IMPORTACION_DELETE( string PV_COD_IMPORTACION_DATOS)
        {
            try
            {
                //if (isnull((select top 1 COD_IMPORTACION_DATOS_CUPON from SOR_IMPORTACION_DATOS_CUPON WHERE COD_IMPORTACION_DATOS = 13),0)> 0)
	               // select 1;
                //                ELSE
                //                    select 2;
                string resultado = "";
                //string SQL_ELIMINAR = @" WHILE 1 = 1
                //                    BEGIN
                //                      delete TOP(1000) FROM SOR_IMPORTACION_DATOS_CUPON
                //                        where COD_IMPORTACION_DATOS = '" + PV_COD_IMPORTACION_DATOS + "';" +
                //                          "IF @@ROWCOUNT < 1000 BREAK;" +
                //                    "END " +
                //                          "DELETE FROM SOR_IMPORTACION_DATOS_DETALLE " +
                //                            "WHERE COD_IMPORTACION_DATOS = '" + PV_COD_IMPORTACION_DATOS + "';" +

                //                           "DELETE FROM SOR_IMPORTACION_DATOS " +
                //                            "WHERE COD_IMPORTACION_DATOS = '" + PV_COD_IMPORTACION_DATOS + "';";

                string SQL_ELIMINAR = @" delete FROM SOR_IMPORTACION_DATOS_CUPON
                where COD_IMPORTACION_DATOS = '" + PV_COD_IMPORTACION_DATOS + "';" +
                               "DELETE FROM SOR_IMPORTACION_DATOS_DETALLE " +
                                "WHERE COD_IMPORTACION_DATOS = '" + PV_COD_IMPORTACION_DATOS + "';" +

                               "DELETE FROM SOR_IMPORTACION_DATOS " +
                                "WHERE COD_IMPORTACION_DATOS = '" + PV_COD_IMPORTACION_DATOS + "';";

                DbCommand cmd = db1.GetSqlStringCommand(SQL_ELIMINAR);
                //db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION);
                cmd.CommandTimeout = 0;
                db1.ExecuteNonQuery(cmd);
                resultado = "OK";
                return resultado;
            }
            catch (Exception ex)
            {
                return  ex.ToString();
            }

        }

        public static string PR_REDUCIR_PESO()
        {
            try
            {
                string resultado = "";
                string SQL_ELIMINAR = @" ALTER DATABASE sorteos_bmsc
                                            SET RECOVERY SIMPLE;
                                            DBCC SHRINKFILE(sorteos_bmsc, 1);
                                            ALTER DATABASE sorteos_bmsc
                                            SET RECOVERY FULL;
                                            ";

                DbCommand cmd = db1.GetSqlStringCommand(SQL_ELIMINAR);
                //db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION);
                cmd.CommandTimeout = 0;
                db1.ExecuteNonQuery(cmd);
                resultado = "OK";
                return resultado;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public static string PR_REDUCIR_LOGS()
        {
            try
            {
                string resultado = "";
                string SQL_ELIMINAR = @" ALTER DATABASE sorteos_bmsc
                                            SET RECOVERY SIMPLE;
                                            DBCC SHRINKFILE(sorteos_bmsc_log, 1);
                                            ALTER DATABASE sorteos_bmsc
                                            SET RECOVERY FULL;
                                            ";

                DbCommand cmd = db1.GetSqlStringCommand(SQL_ELIMINAR);
                //db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, PV_TIPO_OPERACION);
                cmd.CommandTimeout = 0;
                db1.ExecuteNonQuery(cmd);
                resultado = "OK";
                return resultado;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }


        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                DbCommand cmd = db1.GetStoredProcCommand("PR_SOR_ABM_IMPORTACION");
                
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PV_COD_IMPORTACION_DATOS", DbType.String, _PV_COD_IMPORTACION_DATOS);
                if(_PV_COD_IMPORTACION_DATOS_DETALLE=="")
                    db1.AddInParameter(cmd, "PV_COD_IMPORTACION_DATOS_DETALLE", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_COD_IMPORTACION_DATOS_DETALLE", DbType.String, _PV_COD_IMPORTACION_DATOS_DETALLE);
                //cabecera
                if (_PV_COD_SORTEO == "")
                    db1.AddInParameter(cmd, "PV_COD_SORTEO", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_COD_SORTEO", DbType.String, _PV_COD_SORTEO);
                
                if (_PV_TIPO_ARCHIVO == "")
                    db1.AddInParameter(cmd, "PV_TIPO_ARCHIVO", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_TIPO_ARCHIVO", DbType.String, _PV_TIPO_ARCHIVO);
               
                if (_PV_RUTA == "")
                    db1.AddInParameter(cmd, "PV_RUTA", DbType.String,null );
                else
                    db1.AddInParameter(cmd, "PV_RUTA", DbType.String, _PV_RUTA);
                //detalle
                if (_PV_PRODUCTO_NIVEL == "")
                    db1.AddInParameter(cmd, "PV_PRODUCTO_NIVEL", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_PRODUCTO_NIVEL", DbType.String, _PV_PRODUCTO_NIVEL);

                if (_PV_CODIGO_CLIENTE == "")
                    db1.AddInParameter(cmd, "PV_CODIGO_CLIENTE", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_CODIGO_CLIENTE", DbType.String, _PV_CODIGO_CLIENTE);
                
                if (_PV_CLIENTE == "")
                    db1.AddInParameter(cmd, "PV_CLIENTE", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_CLIENTE", DbType.String, _PV_CLIENTE);
                
                if (_PV_IDENTIFICACION == "")
                    db1.AddInParameter(cmd, "PV_IDENTIFICACION", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_IDENTIFICACION", DbType.String, _PV_IDENTIFICACION);

              
                if (_PV_CUENTA == "")
                    db1.AddInParameter(cmd, "PV_CUENTA", DbType.String,null );
                else
                    db1.AddInParameter(cmd, "PV_CUENTA", DbType.String, _PV_CUENTA);

                
                if (_PV_MONEDA == "")
                    db1.AddInParameter(cmd, "PV_MONEDA", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_MONEDA", DbType.String, _PV_MONEDA);

                
                if (_PV_SUCURSAL_ASIGNADA == "")
                    db1.AddInParameter(cmd, "PV_SUCURSAL_ASIGNADA", DbType.String,null );
                else
                    db1.AddInParameter(cmd, "PV_SUCURSAL_ASIGNADA", DbType.String, _PV_SUCURSAL_ASIGNADA);

                
                if (_PV_BANCA == "")
                    db1.AddInParameter(cmd, "PV_BANCA", DbType.String,null );
                else
                    db1.AddInParameter(cmd, "PV_BANCA", DbType.String, _PV_BANCA);
                
                if (_PV_CUPONES_FINAL == 0)
                    db1.AddInParameter(cmd, "PV_CUPONES_FINAL", DbType.Int64,null );
                else
                    db1.AddInParameter(cmd, "PV_CUPONES_FINAL", DbType.Int64, _PV_CUPONES_FINAL);

                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_COD_IMPORTACION_DATOS_OUT", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                //cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                cmd.CommandTimeout = 0;
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
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_COD_IMPORTACION_DATOS_OUT").ToString()))
                    PV_COD_IMPORTACION_DATOS_OUT = "";
                else
                    PV_COD_IMPORTACION_DATOS_OUT = (string)db1.GetParameterValue(cmd, "PV_COD_IMPORTACION_DATOS_OUT");

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR+"|"+PV_COD_IMPORTACION_DATOS_OUT;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "|Se produjo un error al registrar||";
                return resultado;
            }
        }

        #endregion
    }
}