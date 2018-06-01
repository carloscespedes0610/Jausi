using Seguridad.Models.DAC;
using Seguridad.Models.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguridad.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            try
            {
                this.GetDefaultData();

                //var lstPersonas = listarPersonasSentenciaSql();
                var lstPersonas = ListarPersonas();
                return View(lstPersonas);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }
        /*public List<clsPersonaVM> ListarPersonas()
        {
            clsPersonaDAC oPersonaDAC = new clsPersonaDAC(clsAppInfo.Connection);
            List<clsPersonaVM> oPersonaVM = new List<clsPersonaVM>();

            try
            {
                oPersonaDAC.SelectFilter = clsPersonaDAC.SelectFilters.Grid;
                oPersonaDAC.WhereFilter = clsPersonaDAC.WhereFilters.Grid;
                oPersonaDAC.OrderByFilter = clsPersonaDAC.OrderByFilters.Grid;

                if (oPersonaDAC.Open())
                {
                    foreach (DataRow dr in oPersonaDAC.DataSet.Tables[oPersonaDAC.TableName].Rows)
                    {
                        oPersonaVM.Add(new clsPersonaVM()
                        {
                            PersonaID = SysData.ToLong(dr[clsPersonaVM.varPersonaId]),
                            PersonaNombre = SysData.ToStr(dr[clsPersonaVM.varPersonaNombre]),
                            PersonaEstadoCivil = SysData.ToStr(dr[clsPersonaVM.varPersonaEstadoCivil]),
                            PersonaSexo = SysData.ToStr(dr[clsPersonaVM.varPersonaSexo]),
                            PersonaFechaNacimiento = SysData.ToDateTime(dr[clsPersonaVM.varPersonaFechaNacimiento]),
                            PersonaTelefono = SysData.ToStr(dr[clsPersonaVM.varPersonaTelefono])
                        });
                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);

            }
            finally
            {
                //oPersonaDAC.Dispose();
            }

            return oPersonaVM;
        }*/

        public List<clsPersonaVM> ListarPersonas() {
            clsPersonaDAC oPersonaDAC = new clsPersonaDAC(clsAppInfo.Connection);
            List<clsPersonaVM> oPersonaVM = new List<clsPersonaVM>();

            try
            {
                oPersonaDAC.SelectFilter = clsPersonaDAC.SelectFilters.Grid;
                oPersonaDAC.WhereFilter = clsPersonaDAC.WhereFilters.Grid;
                oPersonaDAC.OrderByFilter = clsPersonaDAC.OrderByFilters.Grid;

                if (oPersonaDAC.Open())
                {
                    foreach (DataRow row in oPersonaDAC.DataSet.Tables[oPersonaDAC.TableName].Rows)
                    {
                        clsPersonaVM perAux = new clsPersonaVM();

                        foreach (DataColumn column in oPersonaDAC.DataSet.Tables[oPersonaDAC.TableName].Columns)
                        {
                            switch (column.ColumnName.ToString())
                            {
                                case "PersonaId" : perAux.PersonaID = SysData.ToLong(row[clsPersonaVM.varPersonaId]); break;
                                case "PersonaNombre" : perAux.PersonaNombre = SysData.ToStr(row[clsPersonaVM.varPersonaNombre]); break;
                                case "PersonaSexo" : perAux.PersonaSexo = SysData.ToStr(row[clsPersonaVM.varPersonaSexo]); break;
                                case "PersonaEstadoCivil": perAux.PersonaEstadoCivil = SysData.ToStr(row[clsPersonaVM.varPersonaEstadoCivil]); break;
                                case "PersonaFechaNacimiento": perAux.PersonaFechaNacimiento = SysData.ToDateTime(row[clsPersonaVM.varPersonaFechaNacimiento]); break;
                                case "PersonaTelefono" : perAux.PersonaTelefono = SysData.ToStr(row[clsPersonaVM.varPersonaTelefono]); break;

                            }

                        }

                        oPersonaVM.Add(perAux);
                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);

            }
            finally
            {
                //oPersonaDAC.Dispose();
            }

            return oPersonaVM;
        }

        public List<clsPersonaVM> listarPersonasSentenciaSql() {

            clsPersonaDAC oPersonaDAC = new clsPersonaDAC(clsAppInfo.Connection);
            List<clsPersonaVM> oPersonaVM = new List<clsPersonaVM>();

            try
            {
                oPersonaDAC.SelectFilter = clsPersonaDAC.SelectFilters.Grid;
                oPersonaDAC.WhereFilter = clsPersonaDAC.WhereFilters.Grid;
                oPersonaDAC.OrderByFilter = clsPersonaDAC.OrderByFilters.Grid;

                if (oPersonaDAC.OpenCarlosQuery())
                {
                    foreach (DataRow dr in oPersonaDAC.DataSet.Tables[oPersonaDAC.TableName].Rows)
                    {
                        oPersonaVM.Add(new clsPersonaVM()
                        {
                            PersonaID = SysData.ToLong(dr[clsPersonaVM.varPersonaId]),
                            PersonaNombre = SysData.ToStr(dr[clsPersonaVM.varPersonaNombre]),
                            PersonaEstadoCivil = SysData.ToStr(dr[clsPersonaVM.varPersonaEstadoCivil]),
                            PersonaSexo = SysData.ToStr(dr[clsPersonaVM.varPersonaSexo]),
                            PersonaFechaNacimiento = SysData.ToDateTime(dr[clsPersonaVM.varPersonaFechaNacimiento]),
                            PersonaTelefono = SysData.ToStr(dr[clsPersonaVM.varPersonaTelefono])
                        });

                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);

            }
            finally
            {
                //oPersonaDAC.Dispose();
            }

            return oPersonaVM;
        }

    }

    
}