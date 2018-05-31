using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;
using Seguridad.Models.DAC;
using Seguridad.Models.VM;

namespace Seguridad.Controllers
{
    [SessionExpireFilter]
    public class TipoUsuarioController : Controller
    {
        public ActionResult ExportToExcel(string someParameter)
        {
            //...
            return null;
        }

        // GET: TipoUsuario
        public ActionResult Index()
        {
            try
            {
                this.GetDefaultData();

                var lstTipoUsuario = TipoUsuarioList();
                return View(lstTipoUsuario);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: TipoUsuario/Create
        public ActionResult Create()
        {
            try
            {
                this.GetDefaultData();

                ViewBag.EstadoId = EstadoList();
                return View();
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: TipoUsuario/Create
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(clsTipoUsuarioVM oTipoUsuarioVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsTipoUsuario oTipoUsuario = new clsTipoUsuario(clsAppInfo.Connection);

                    oTipoUsuario.TipoUsuarioCod = SysData.ToStr(oTipoUsuarioVM.TipoUsuarioCod);
                    oTipoUsuario.TipoUsuarioDes = SysData.ToStr(oTipoUsuarioVM.TipoUsuarioDes);
                    oTipoUsuario.EstadoId = SysData.ToLong(oTipoUsuarioVM.EstadoId);

                    if (oTipoUsuario.Insert())
                    {
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.EstadoId = EstadoList();
                return View(oTipoUsuarioVM);
            }

            catch (Exception exp)
            {
                ViewBag.EstadoId = EstadoList();
                ViewBag.MessageErr = exp.Message;
                return View(oTipoUsuarioVM);
            }
        }

        // GET: TipoUsuario/Edit/5
        public ActionResult Edit(int? id, int? PlanId)
        {
            try
            {
                this.GetDefaultData();
                
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsTipoUsuarioVM oTipoUsuarioVM = TipoUsuarioFind(SysData.ToLong(id));

                if (ReferenceEquals(oTipoUsuarioVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                ViewBag.EstadoId = EstadoList();
                return View(oTipoUsuarioVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: TipoUsuario/Edit/5
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(clsTipoUsuarioVM oTipoUsuarioVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsTipoUsuario oTipoUsuario = new clsTipoUsuario(clsAppInfo.Connection);

                    oTipoUsuario.TipoUsuarioId = SysData.ToLong(oTipoUsuarioVM.TipoUsuarioId);
                    oTipoUsuario.TipoUsuarioCod = SysData.ToStr(oTipoUsuarioVM.TipoUsuarioCod);
                    oTipoUsuario.TipoUsuarioDes = SysData.ToStr(oTipoUsuarioVM.TipoUsuarioDes);
                    oTipoUsuario.EstadoId = SysData.ToLong(oTipoUsuarioVM.EstadoId);

                    if (oTipoUsuario.Update())
                    {
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.EstadoId = EstadoList();
                return View(oTipoUsuarioVM);
            }

            catch (Exception exp)
            {
                ViewBag.EstadoId = EstadoList();
                ViewBag.MessageErr = exp.Message;
                return View(oTipoUsuarioVM);
            }
        }

        // GET: TipoUsuario/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsTipoUsuarioVM oTipoUsuarioVM = TipoUsuarioFind(SysData.ToLong(id));

                if (ReferenceEquals(oTipoUsuarioVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                ViewBag.EstadoId = EstadoList();
                return View(oTipoUsuarioVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: TipoUsuario/Delete/5
        [HttpPost()]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsTipoUsuario oTipoUsuario = new clsTipoUsuario(clsAppInfo.Connection);

                oTipoUsuario.WhereFilter = clsTipoUsuario.WhereFilters.PrimaryKey;
                oTipoUsuario.TipoUsuarioId = id;

                if (oTipoUsuario.Delete())
                {
                    return RedirectToAction("Index");
                }

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: TipoUsuario/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsTipoUsuarioVM oTipoUsuarioVM = TipoUsuarioFind(SysData.ToLong(id));

                if (ReferenceEquals(oTipoUsuarioVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                ViewBag.EstadoId = EstadoList();
                return View(oTipoUsuarioVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        public ActionResult ReportList()
        {
            try
            {
                rptTipoUsuario rpt = new rptTipoUsuario();

                this.GetDefaultData();

                rpt.DataSource = TipoUsuarioList();
                rpt.lblCompany.Text = "AMC IMPORTACIONES Y SERVICIOS S.R.L. AV. CRISTO REDENTOR C/A. DURAN CANELAS Nº 125";
                rpt.lblTitle.Text = "Tipos de Usuario Demo";

                return View(rpt);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }







        public List<clsTipoUsuarioVM> TipoUsuarioList()
        {
            clsTipoUsuario oTipoUsuario = new clsTipoUsuario(clsAppInfo.Connection);
            List<clsTipoUsuarioVM> oTipoUsuarioVM = new List<clsTipoUsuarioVM>();

            try
            {
                oTipoUsuario.SelectFilter = clsTipoUsuario.SelectFilters.Grid;
                oTipoUsuario.WhereFilter = clsTipoUsuario.WhereFilters.Grid;
                oTipoUsuario.OrderByFilter = clsTipoUsuario.OrderByFilters.Grid;

                if (oTipoUsuario.Open())
                {
                    foreach (DataRow dr in oTipoUsuario.DataSet.Tables[oTipoUsuario.TableName].Rows)
                    {
                        oTipoUsuarioVM.Add(new clsTipoUsuarioVM()
                        {
                            TipoUsuarioId = SysData.ToLong(dr["TipoUsuarioId"]),
                            TipoUsuarioDes = SysData.ToStr(dr["TipoUsuarioDes"]),
                            TipoUsuarioCod = SysData.ToStr(dr["TipoUsuarioCod"]),
                            EstadoId = SysData.ToLong(dr["EstadoId"]),
                            EstadoDes = SysData.ToStr(dr["EstadoDes"])
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
                oTipoUsuario.Dispose();
            }

            return oTipoUsuarioVM;
        }

        private clsTipoUsuarioVM TipoUsuarioFind(long lngTipoUsuarioId)
        {
            clsTipoUsuario oTipoUsuario = new clsTipoUsuario(clsAppInfo.Connection);
            clsTipoUsuarioVM oTipoUsuarioVM = new clsTipoUsuarioVM();

            try
            {
                oTipoUsuario.TipoUsuarioId = lngTipoUsuarioId;

                if (oTipoUsuario.FindByPK())
                {
                    oTipoUsuarioVM.TipoUsuarioId = oTipoUsuario.TipoUsuarioId;
                    oTipoUsuarioVM.TipoUsuarioDes = oTipoUsuario.TipoUsuarioDes;
                    oTipoUsuarioVM.TipoUsuarioCod = oTipoUsuario.TipoUsuarioCod;
                    oTipoUsuarioVM.EstadoId = oTipoUsuario.EstadoId;

                    return oTipoUsuarioVM;
                }
            }

            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                oTipoUsuario.Dispose();
            }

            return null;
        }

        public IEnumerable<clsEstadoVM> EstadoList()
        {
            clsEstado oEstado = new clsEstado(clsAppInfo.Connection);
            List<clsEstadoVM> oEstadoVM = new List<clsEstadoVM>();

            try
            {
                oEstado.SelectFilter = clsEstado.SelectFilters.ListBox;
                oEstado.WhereFilter = clsEstado.WhereFilters.AplicacionId;
                oEstado.OrderByFilter = clsEstado.OrderByFilters.EstadoDes;
                oEstado.AplicacionId = clsAppInfo.AplicacionId;

                if (oEstado.Open())
                {
                    foreach (DataRow dr in oEstado.DataSet.Tables[oEstado.TableName].Rows)
                    {
                        oEstadoVM.Add(new clsEstadoVM()
                        {
                            EstadoId = SysData.ToLong(dr["EstadoId"]),
                            EstadoDes = SysData.ToStr(dr["EstadoDes"])
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
                oEstado.Dispose();
            }

            return ((IEnumerable<clsEstadoVM>)oEstadoVM);
        }

    }
}