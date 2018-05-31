using System;
using System.Data.SqlClient;
using System.Data;

namespace Seguridad.Models.DAC
{
    public class clsEstado : clsBase, IDisposable
    {
        private long mlngEstadoId;
        private string mstrEstadoCod;
        private string mstrEstadoDes;
        private long mlngAplicacionId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
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

        public string EstadoCod
        {
            get
            {
                return mstrEstadoCod;
            }

            set
            {
                mstrEstadoCod = value;
            }
        }

        public string EstadoDes
        {
            get
            {
                return mstrEstadoDes;
            }

            set
            {
                mstrEstadoDes = value;
            }
        }

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
            EstadoDes = 2,
            Grid = 3,
            GridCheck = 4,
            EstadoCod = 5,
            GridEstadoId = 6,
            AplicacionId = 7
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            EstadoId = 1,
            EstadoDes = 2,
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
        public clsEstado()
        {
            mstrTableName = "parEstado";
            mstrClassName = "clsEstado";

            PropertyInit();
            FilterInit();
        }

        public clsEstado(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsEstado(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsEstado(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsEstado(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsEstado(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngEstadoId = 0;
            mstrEstadoCod = "";
            mstrEstadoDes = "";
            mlngAplicacionId = 0;
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
                    mstrStoreProcName = "parEstadoSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "parEstadoSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "parEstadoSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "parEstadoSelect";
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
                    moParameters[3] = new SqlParameter("@EstadoId", mlngEstadoId);
                    moParameters[4] = new SqlParameter("@AplicacionId", Convert.ToInt32(0));
                    break;

                case WhereFilters.EstadoDes:
                    break;
                //strSQL = " WHERE  parEstado.EstadoDes = " & StringToField(mstrEstadoDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@AplicacionId", Convert.ToInt32(0));
                    break;

                case WhereFilters.EstadoCod:
                    break;

                case WhereFilters.GridCheck:
                    break;

                case WhereFilters.GridEstadoId:
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter("@EstadoId", mlngEstadoId);
                    moParameters[4] = new SqlParameter("@AplicacionId", Convert.ToInt32(0));
                    break;

                case WhereFilters.AplicacionId:
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@AplicacionId", mlngAplicacionId);
                    break;
            }
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "parEstadoInsert";
                    moParameters = new SqlParameter[5] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@EstadoCod", mstrEstadoCod),
                        new SqlParameter("@EstadoDes", mstrEstadoDes),
                        new SqlParameter("@AplicacionId", mlngAplicacionId)};
                    moParameters[1].Direction = ParameterDirection.Output;
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "parEstadoUpdate";
                    moParameters = new SqlParameter[5] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@EstadoId", mlngEstadoId),
                        new SqlParameter("@EstadoCod", mstrEstadoCod),
                        new SqlParameter("@EstadoDes", mstrEstadoDes),
                        new SqlParameter("@AplicacionId", mlngAplicacionId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "parEstadoDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
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
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        mstrEstadoCod = SysData.ToStr(oDataRow["EstadoCod"]);
                        mstrEstadoDes = SysData.ToStr(oDataRow["EstadoDes"]);
                        mlngAplicacionId = SysData.ToLong(oDataRow["AplicacionId"]);
                        break;

                    case SelectFilters.ListBox:
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        mstrEstadoCod = SysData.ToStr(oDataRow["EstadoCod"]);
                        mstrEstadoDes = SysData.ToStr(oDataRow["EstadoDes"]);
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

            if (mstrEstadoCod.Length == 0)
            {
                strMsg += "Código es Requerido <br />";
            }

            if (mstrEstadoDes.Length == 0)
            {
                strMsg += "Descripción del Estado es Requerido <br />";
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