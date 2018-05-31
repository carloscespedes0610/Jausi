using System;
using System.Data.SqlClient;
using System.Data;

namespace Seguridad.Models.DAC
{
    public class clsModulo : clsBase, IDisposable
    {
        private long mlngModuloId;
        private string mstrModuloCod;
        private string mstrModuloDes;
        private string mstrModuloEsp;
        private long mlngEstadoId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
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

        public string ModuloCod
        {
            get
            {
                return mstrModuloCod;
            }

            set
            {
                mstrModuloCod = value;
            }
        }

        public string ModuloDes
        {
            get
            {
                return mstrModuloDes;
            }

            set
            {
                mstrModuloDes = value;
            }
        }

        public string ModuloEsp
        {
            get
            {
                return mstrModuloEsp;
            }

            set
            {
                mstrModuloEsp = value;
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
            ModuloDes = 2,
            Grid = 3,
            GridCheck = 4,
            ModuloCod = 5,
            GridModuloId = 6
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            ModuloId = 1,
            ModuloDes = 2,
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
        public clsModulo()
        {
            mstrTableName = "segModulo";
            mstrClassName = "clsModulo";

            PropertyInit();
            FilterInit();
        }

        public clsModulo(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsModulo(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsModulo(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsModulo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsModulo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngModuloId = 0;
            mstrModuloCod = "";
            mstrModuloDes = "";
            mstrModuloEsp = "";
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
                    mstrStoreProcName = "segModuloSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "segModuloSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "segModuloSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "segModuloSelect";
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
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter("@ModuloId", mlngModuloId);
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.ModuloDes:
                    break;
                //strSQL = " WHERE  segModulo.ModuloDes = " & StringToField(mstrModuloDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter("@ModuloId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.ModuloCod:
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
                    mstrStoreProcName = "segModuloInsert";
                    moParameters = new SqlParameter[6] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@ModuloCod", mstrModuloCod),
                        new SqlParameter("@ModuloDes", mstrModuloDes),
                        new SqlParameter("@ModuloEsp", mstrModuloEsp),
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
                    mstrStoreProcName = "segModuloUpdate";
                    moParameters = new SqlParameter[6] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@ModuloId", mlngModuloId),
                        new SqlParameter("@ModuloCod", mstrModuloCod),
                        new SqlParameter("@ModuloDes", mstrModuloDes),
                        new SqlParameter("@ModuloEsp", mstrModuloEsp),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "segModuloDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@ModuloId", mlngModuloId)};
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
                        mlngModuloId = SysData.ToLong(oDataRow["ModuloId"]);
                        mstrModuloCod = SysData.ToStr(oDataRow["ModuloCod"]);
                        mstrModuloDes = SysData.ToStr(oDataRow["ModuloDes"]);
                        mstrModuloEsp = SysData.ToStr(oDataRow["ModuloEsp"]);
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        break;

                    case SelectFilters.ListBox:
                        mlngModuloId = SysData.ToLong(oDataRow["ModuloId"]);
                        mstrModuloCod = SysData.ToStr(oDataRow["ModuloCod"]);
                        mstrModuloDes = SysData.ToStr(oDataRow["ModuloDes"]);
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

            if (mstrModuloCod.Length == 0)
            {
                strMsg += "Código es Requerido <br />";
            }

            if (mstrModuloDes.Length == 0)
            {
                strMsg += "Descripción del Módulo es Requerido <br />";
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