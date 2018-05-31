using System;
using System.Data.SqlClient;
using System.Data;

namespace Seguridad.Models.DAC
{
    public class clsAutoriza : clsBase, IDisposable
    {
        private long mlngAutorizaId;
        private long mlngModuloId;
        private long mlngTipoUsuarioId;
        private string mstrTablaDes;
        private long mlngTablaId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
        public long AutorizaId
        {
            get
            {
                return mlngAutorizaId;
            }

            set
            {
                mlngAutorizaId = value;
            }
        }

        public long moduloId
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

        public long TipoUsuarioId
        {
            get
            {
                return mlngTipoUsuarioId;
            }

            set
            {
                mlngTipoUsuarioId = value;
            }
        }

        public string TablaDes
        {
            get
            {
                return mstrTablaDes;
            }

            set
            {
                mstrTablaDes = value;
            }
        }

        public long TablaId
        {
            get
            {
                return mlngTablaId;
            }

            set
            {
                mlngTablaId = value;
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
            TablaDes = 2,
            Grid = 3,
            GridCheck = 4,
            //AutorizaCod = 5,
            GridAutorizaId = 6,
            TipoUsuarioIdTablaDes = 7
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            AutorizaId = 1,
            TablaDes = 2,
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
        public clsAutoriza()
        {
            mstrTableName = "segAutoriza";
            mstrClassName = "clsAutoriza";

            PropertyInit();
            FilterInit();
        }

        public clsAutoriza(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsAutoriza(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsAutoriza(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsAutoriza(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsAutoriza(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngAutorizaId = 0;
            mlngModuloId = 0;
            mlngTipoUsuarioId = 0;
            mstrTablaDes = "";
            mlngTablaId = 0;
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
                    mstrStoreProcName = "segAutorizaSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "segAutorizaSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "segAutorizaSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "segAutorizaSelect";
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
                    Array.Resize(ref moParameters, moParameters.Length + 4);
                    moParameters[3] = new SqlParameter("@AutorizaId", mlngAutorizaId);
                    moParameters[4] = new SqlParameter("@TipoUsuarioId", Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter("@TablaDes", "");
                    moParameters[6] = new SqlParameter("@TablaId", Convert.ToInt32(0));
                    break;

                case WhereFilters.TablaDes:
                    break;
                //strSQL = " WHERE  segAutoriza.TablaDes = " & StringToField(mstrTablaDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 4);
                    moParameters[3] = new SqlParameter("@AutorizaId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@TipoUsuarioId", Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter("@TablaDes", "");
                    moParameters[6] = new SqlParameter("@TablaId", Convert.ToInt32(0));
                    break;

                case WhereFilters.GridCheck:
                    break;

                case WhereFilters.GridAutorizaId:
                    Array.Resize(ref moParameters, moParameters.Length + 4);
                    moParameters[3] = new SqlParameter("@AutorizaId", mlngAutorizaId);
                    moParameters[4] = new SqlParameter("@TipoUsuarioId", Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter("@TablaDes", "");
                    moParameters[6] = new SqlParameter("@TablaId", Convert.ToInt32(0));
                    break;

                case WhereFilters.TipoUsuarioIdTablaDes:
                    Array.Resize(ref moParameters, moParameters.Length + 4);
                    moParameters[3] = new SqlParameter("@AutorizaId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@TipoUsuarioId", mlngTipoUsuarioId);
                    moParameters[5] = new SqlParameter("@TablaDes", mstrTablaDes);
                    moParameters[6] = new SqlParameter("@TablaId", mlngTablaId);
                    break;
            }
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "segAutorizaInsert";
                    moParameters = new SqlParameter[6] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@ModuloId", mlngModuloId),
                        new SqlParameter("@TipoUsuarioId", mlngTipoUsuarioId),
                        new SqlParameter("@TablaDes", mstrTablaDes),
                        new SqlParameter("@TablaId", mlngTablaId)};
                    moParameters[1].Direction = ParameterDirection.Output;
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "segAutorizaUpdate";
                    moParameters = new SqlParameter[6] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@AutorizaId", mlngAutorizaId),
                        new SqlParameter("@ModuloId", mlngModuloId),
                        new SqlParameter("@TipoUsuarioId", mlngTipoUsuarioId),
                        new SqlParameter("@TablaDes", mstrTablaDes),
                        new SqlParameter("@TablaId", mlngTablaId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "segAutorizaDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@AutorizaId", mlngAutorizaId)};
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
                        mlngAutorizaId = SysData.ToLong(oDataRow["AutorizaId"]);
                        mlngModuloId = SysData.ToLong(oDataRow["ModuloId"]);
                        mlngTipoUsuarioId = SysData.ToLong(oDataRow["TipoUsuarioId"]);
                        mstrTablaDes = SysData.ToStr(oDataRow["TablaDes"]);
                        mlngTablaId = SysData.ToLong(oDataRow["TablaId"]);
                        break;

                    case SelectFilters.ListBox:
                        mlngAutorizaId = SysData.ToLong(oDataRow["AutorizaId"]);
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

            //if (mstrTablaDes.Length == 0)
            //{
            //    strMsg += "es Requerido <br />";
            //}

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