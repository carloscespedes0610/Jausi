using Seguridad.Models.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguridad.Models.Modules
{
    public static class AppCode
    {
        public static bool AplicacionFind(long lngAplicacionId)
        {
            bool returnValue = false;
            clsAplicacion oAplicacion = new clsAplicacion(clsAppInfo.Connection);

            clsAppInfo.ModuloId = 0;
            clsAppInfo.AplicacionId = 0;
            clsAppInfo.AplicacionDes = "";

            try
            {
                oAplicacion.AplicacionId = lngAplicacionId;

                if (oAplicacion.FindByPK())
                {
                    if (oAplicacion.EstadoId == Constants.Activo)
                    {
                        clsAppInfo.ModuloId = oAplicacion.ModuloId;
                        clsAppInfo.AplicacionId = oAplicacion.AplicacionId;
                        clsAppInfo.AplicacionDes = oAplicacion.AplicacionDes;

                        returnValue = true;
                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);

            }
            finally
            {
                oAplicacion.Dispose();
            }

            return returnValue;
        }

        public static bool AutorizaFind(long lngTipoUsuarioId, string strTablaDes, long lngTablaId)
        {
            bool returnValue = false;
            clsAutoriza oAutoriza = new clsAutoriza(clsAppInfo.Connection);

            clsAppInfo.AutorizaId = 0;

            try
            {
                oAutoriza.SelectFilter = clsAutoriza.SelectFilters.All;
                oAutoriza.WhereFilter = clsAutoriza.WhereFilters.TipoUsuarioIdTablaDes;
                oAutoriza.TipoUsuarioId = lngTipoUsuarioId;
                oAutoriza.TablaDes = strTablaDes;
                oAutoriza.TablaId = lngTablaId;

                if (oAutoriza.Find())
                {
                    clsAppInfo.AutorizaId = oAutoriza.AutorizaId;

                    returnValue = true;
                }
            }

            catch (Exception exp)
            {
                throw (exp);

            }
            finally
            {
                oAutoriza.Dispose();
            }

            return returnValue;
        }

        public static bool UsuarioCodFind(string strUsuarioCod)
        {
            bool returnValue = false;
            clsUsuario oUsuario = new clsUsuario(clsAppInfo.Connection);

            clsAppInfo.TipoUsuarioId = 0;
            clsAppInfo.UsuarioId = 0;
            clsAppInfo.UsuarioCod = "";
            clsAppInfo.UsuarioDes = "";

            try
            {
                oUsuario.SelectFilter = clsUsuario.SelectFilters.All;
                oUsuario.WhereFilter = clsUsuario.WhereFilters.UsuarioCod;
                oUsuario.UsuarioCod = strUsuarioCod;

                if (oUsuario.Find())
                {
                    if (oUsuario.EstadoId == Constants.Activo)
                    {
                        clsAppInfo.TipoUsuarioId = oUsuario.TipoUsuarioId;
                        clsAppInfo.UsuarioId = oUsuario.UsuarioId;
                        clsAppInfo.UsuarioCod = oUsuario.UsuarioCod;
                        clsAppInfo.UsuarioDes = oUsuario.UsuarioDes;
                        clsAppInfo.UsuarioFotoPath = oUsuario.UsuarioFotoPath;

                        returnValue = true;
                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);

            }
            finally
            {
                oUsuario.Dispose();
            }

            return returnValue;
        }

    }
}