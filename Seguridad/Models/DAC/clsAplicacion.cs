using System;
using System.Data.SqlClient;
using System.Data;

namespace Seguridad.Models.DAC
{
    public class clsAplicacion : clsBase, IDisposable
    {
        private long mlngAplicacionId;
        private string mstrAplicacionCod;
        private string mstrAplicacionDes;
        private string mstrAplicacionEsp;
        private long mlngModuloId;
        private long mlngEstadoId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
        public long AplicacionId
        {
            get
            {
                return mlngAplicacionId;
            }

            set
            {
                mlngAplicacionId = value;
            }
        }

        public string AplicacionCod
        {
            get
            {
                return mstrAplicacionCod;
            }

            set
            {
                mstrAplicacionCod = value;
            }
        }

        public string AplicacionDes
        {
            get
            {
                return mstrAplicacionDes;
            }

            set
            {
                mstrAplicacionDes = value;
            }
        }

        public string AplicacionEsp
        {
            get
            {
                return mstrAplicacionEsp;
            }

            set
            {
                mstrAplicacionEsp = value;
            }
        }

        public long ModuloId
        {
            get
            {
                return mlngModuloId;
            }

            set
            {
                mlngModuloId = value;
            }
        }

        public long EstadoId
        {
            get
            {
                return mlngEstadoId;
            }

            set
            {
                mlngEstadoId = value;
            }
        }

        public long Id
        {
            get
            {
                return mlngId;
            }

            set
            {
                mlngId = value;
            }
        }

        //******************************************************
        //* The following enumerations will change for each
        //* data access class
        //******************************************************
        public enum SelectFilters : byte
        {
            All = 0,
            RowCount = 1,
            ListBox = 2,
            Grid = 3,
            GridCheck = 4
        }

        public enum WhereFilters : byte
        {
            None = 0,
            PrimaryKey = 1,
            AplicacionDes = 2,
            Grid = 3,
            GridCheck = 4,
            AplicacionCod = 5,
            GridAplicacionId = 6
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            AplicacionId = 1,
            AplicacionDes = 2,
            Grid = 3,
            GridCheck = 4
        }

        public enum InsertFilters : byte
        {
            All = 0
        }

        public enum UpdateFilters : byte
        {
            All = 0
        }

        public enum DeleteFilters : byte
        {
            All = 0
        }

        public enum RowCountFilters : byte
        {
            All = 0
        }

        //*********************************************************
        //* The following filters will change for each
        //* data access class
        //*********************************************************
        private SelectFilters mintSelectFilter;
        private WhereFilters mintWhereFilter;
        private OrderByFilters mintOrderByFilter;
        private InsertFilters mintInsertFilter;
        private UpdateFilters mintUpdateFilter;
        private DeleteFilters mintDeleteFilter;
        private RowCountFilters mintRowCountFilter;

        public SelectFilters SelectFilter
        {
            get
            {
                return mintSelectFilter;
            }

            set
            {
                mintSelectFilter = value;
            }
        }

        public WhereFilters WhereFilter
        {
            get
            {
                return mintWhereFilter;
            }

            set
            {
                mintWhereFilter = value;
            }
        }

        public OrderByFilters OrderByFilter
        {
            get
            {
                return mintOrderByFilter;
            }

            set
            {
                mintOrderByFilter = value;
            }
        }

        public InsertFilters InsertFilter
        {
            get
            {
                return mintInsertFilter;
            }

            set
            {
                mintInsertFilter = value;
            }
        }

        public UpdateFilters UpdateFilter
        {
            get
            {
                return mintUpdateFilter;
            }

            set
            {
                mintUpdateFilter = value;
            }
        }

        public DeleteFilters DeleteFilter
        {
            get
            {
                return mintDeleteFilter;
            }

            set
            {
                mintDeleteFilter = value;
            }
        }

        public RowCountFilters RowCountFilter
        {
            get
            {
                return mintRowCountFilter;
            }

            set
            {
                mintRowCountFilter = value;
            }
        }

        //************************************************************
        //* Method Name  : New()
        //* Syntax       : Constructor
        //* Parameters   : None
        //*
        //* Description  : This event is called when the object is created.
        //* It can be used to initialize private data variables.
        //*
        //************************************************************
        public clsAplicacion()
        {
            mstrTableName = "segAplicacion";
            mstrClassName = "clsAplicacion";

            PropertyInit();
            FilterInit();
        }

        public clsAplicacion(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsAplicacion(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsAplicacion(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsAplicacion(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsAplicacion(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngAplicacionId = 0;
            mstrAplicacionCod = "";
            mstrAplicacionDes = "";
            mstrAplicacionEsp = "";
            mlngModuloId = 0;
            mlngEstadoId = 0;
        }

        protected override void SelectParameter()
        {
            Array.Resize(ref moParameters, 3);
            moParameters[0] = new SqlParameter("@SelectFilter", mintSelectFilter);
            moParameters[1] = new SqlParameter("@WhereFilter", mintWhereFilter);
            moParameters[2] = new SqlParameter("@OrderByFilter", mintOrderByFilter);

            switch (mintSelectFilter)
            {
                case SelectFilters.All:
                    mstrStoreProcName = "segAplicacionSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "segAplicacionSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "segAplicacionSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "segAplicacionSelect";
                    break;

                case SelectFilters.GridCheck:
                    break;
            }

            WhereParameter();

            //Call OrderByParameter()
        }

        private void WhereParameter()
        {
            switch (mintWhereFilter)
            {
                case WhereFilters.PrimaryKey:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@AplicacionId", mlngAplicacionId);
                    moParameters[4] = new SqlParameter("@ModuloId", Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.AplicacionDes:
                    break;
                //strSQL = " WHERE  segAplicacion.AplicacionDes = " & StringToField(mstrAplicacionDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@AplicacionId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@ModuloId", Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.AplicacionCod:
                    break;

                case WhereFilters.GridCheck:
                    break;
            }
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "segAplicacionInsert";
                    moParameters = new SqlParameter[7] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@AplicacionCod", mstrAplicacionCod),
                        new SqlParameter("@AplicacionDes", mstrAplicacionDes),
                        new SqlParameter("@AplicacionEsp", mstrAplicacionEsp),
                        new SqlParameter("@ModuloId", mlngModuloId),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
                    moParameters[1].Direction = ParameterDirection.Output;
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "segAplicacionUpdate";
                    moParameters = new SqlParameter[7] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@AplicacionId", mlngAplicacionId),
                        new SqlParameter("@AplicacionCod", mstrAplicacionCod),
                        new SqlParameter("@AplicacionDes", mstrAplicacionDes),
                        new SqlParameter("@AplicacionEsp", mstrAplicacionEsp),
                        new SqlParameter("@ModuloId", mlngModuloId),
                    new SqlParameter("@EstadoId", mlngEstadoId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "segAplicacionDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@AplicacionId", mlngAplicacionId)};
                    break;
            }
        }

        protected override void Retrieve(DataRow oDataRow)
        {
            try
            {
                PropertyInit();

                switch (mintSelectFilter)
                {
                    case SelectFilters.All:
                        mlngAplicacionId = SysData.ToLong(oDataRow["AplicacionId"]);
                        mstrAplicacionCod = SysData.ToStr(oDataRow["AplicacionCod"]);
                        mstrAplicacionDes = SysData.ToStr(oDataRow["AplicacionDes"]);
                        mstrAplicacionEsp = SysData.ToStr(oDataRow["AplicacionEsp"]);
                        mlngModuloId = SysData.ToLong(oDataRow["ModuloId"]);
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        break;

                    case SelectFilters.ListBox:
                        mlngAplicacionId = SysData.ToLong(oDataRow["AplicacionId"]);
                        mstrAplicacionCod = SysData.ToStr(oDataRow["AplicacionCod"]);
                        mstrAplicacionDes = SysData.ToStr(oDataRow["AplicacionDes"]);
                        break;
                }
            }

            catch (Exception exp)
            {
                throw (exp);
            }
        }

        public override bool Validate()
        {
            bool returnValue = false;
            string strMsg = string.Empty;

            if (mstrAplicacionCod.Length == 0)
            {
                strMsg += "Código de la Aplicación es Requerido <br />";
            }

            if (mstrAplicacionDes.Length == 0)
            {
                strMsg += "Descripción de la Aplicación es requerido <br />";
            }

            if (strMsg.Trim() != string.Empty)
            {
                returnValue = false;
                throw (new Exception(strMsg));
            }
            else
            {
                returnValue = true;
            }

            return returnValue;
        }

        public bool FindByPK()
        {
            bool returnValue = false;
            returnValue = false;

            try
            {
                mintSelectFilter = SelectFilters.All;
                mintWhereFilter = WhereFilters.PrimaryKey;
                mintOrderByFilter = OrderByFilters.None;

                if (Open())
                {
                    if (Read())
                    {
                        returnValue = true;
                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);
            }

            return returnValue;
        }

        public void FilterInit()
        {
            mintWhereFilter = 0;
            mintOrderByFilter = 0;
            mintSelectFilter = 0;
            mintInsertFilter = 0;
            mintUpdateFilter = 0;
            mintDeleteFilter = 0;
            mintRowCountFilter = 0;
        }

        virtual public void Dispose()
        {
            //Call CloseConection()
        }

    }
}