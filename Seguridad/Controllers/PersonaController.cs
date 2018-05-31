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

                var lstPersonas = listarPersonasSentenciaSql();
                //var lstPersonas = ListarPersonas();
                return View(lstPersonas);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

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

        public List<clsPersonaVM> listarPersonasSentenciaSql() {
            /* List<clsPersonaVM> oPersonaVM = new List<clsPersonaVM>();

             string SelectAllTablePerson = @"SELECT	Persona.PersonaId, 
                                             Persona.PersonaNombre, 
                                             Persona.PersonaSexo, 
                                             Persona.PersonaEstadoCivil,
                                             Persona.PersonaFechaNacimiento,
                                             Persona.PersonaTelefono 
                                             FROM	Persona 
                                             ORDER BY PersonaId";
             //Inicializa el comando que se va a ejecutar
             SqlCommand cmd = new SqlCommand(SelectAllTablePerson, clsAppInfo.Connection);
             //Se agregan los parámetros
             // cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             try
             {

                 //Se abre la conexión
                 cmd.Connection.Open();
                 SqlDataReader reader = cmd.ExecuteReader();

                 while (reader.Read())
                 {
                     oPersonaVM.Add(new clsPersonaVM()
                     {
                         //Convert.ToString(reader("campo1")); 
                         PersonaID = SysData.ToLong(reader[clsPersonaVM.varPersonaId]),
                         PersonaNombre = SysData.ToStr(reader[clsPersonaVM.varPersonaNombre]),
                         PersonaEstadoCivil = SysData.ToStr(reader[clsPersonaVM.varPersonaEstadoCivil]),
                         PersonaSexo = SysData.ToStr(reader[clsPersonaVM.varPersonaSexo]),
                         PersonaFechaNacimiento = SysData.ToDateTime(reader[clsPersonaVM.varPersonaFechaNacimiento]),
                         PersonaTelefono = SysData.ToStr(reader[clsPersonaVM.varPersonaTelefono])
                     });
                 }
                 cmd.Connection.Dispose();

             }
             catch (SqlException sqlEx)
             {
                 string error = sqlEx.Message;
                 throw;
             }
             return oPersonaVM;*/

            clsPersonaDAC oPersonaDAC = new clsPersonaDAC(clsAppInfo.Connection);
            List<clsPersonaVM> oPersonaVM = new List<clsPersonaVM>();

            try
            {
                oPersonaDAC.SelectFilter = clsPersonaDAC.SelectFilters.Grid;
                oPersonaDAC.WhereFilter = clsPersonaDAC.WhereFilters.Grid;
                oPersonaDAC.OrderByFilter = clsPersonaDAC.OrderByFilters.Grid;

                if (oPersonaDAC.OpenCarlos())
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