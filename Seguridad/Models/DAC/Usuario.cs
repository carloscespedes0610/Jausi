using System;
using System.Data.SqlClient;
using System.Data;

namespace Seguridad.Models.DAC
{
    public class clsUsuario : clsBase, IDisposable
    {
        private long mlngUsuarioId;
        private string mstrUsuarioCod;
        private string mstrUsuarioDes;
        private long mlngTipoUsuarioId;
        private string mstrUsuarioDocPath;
        private string mstrUsuarioFotoPath;
        private string mstrUsuarioMaxSes;
        private long mlngEstadoId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
        public long UsuarioId
        {
            get
            {
                return mlngUsuarioId;
            }

            set
            {
                mlngUsuarioId = value;
            }
        }

        public string UsuarioCod
        {
            get
            {
                return mstrUsuarioCod;
            }

            set
            {
                mstrUsuarioCod = value;
            }
        }

        public string UsuarioDes
        {
            get
            {
                return mstrUsuarioDes;
            }

            set
            {
                mstrUsuarioDes = value;
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

        public string UsuarioDocPath
        {
            get
            {
                return mstrUsuarioDocPath;
            }

            set
            {
                mstrUsuarioDocPath = value;
            }
        }

        public string UsuarioFotoPath
        {
            get
            {
                return mstrUsuarioFotoPath;
            }

            set
            {
                mstrUsuarioFotoPath = value;
            }
        }

        public string UsuarioMaxSes
        {
            get
            {
                return mstrUsuarioMaxSes;
            }

            set
            {
                mstrUsuarioMaxSes = value;
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
            UsuarioDes = 2,
            Grid = 3,
            GridCheck = 4,
            UsuarioCod = 5,
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            UsuarioId = 1,
            UsuarioDes = 2,
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
        public clsUsuario()
        {
            mstrTableName = "segUsuario";
            mstrClassName = "clsUsuario";

            PropertyInit();
            FilterInit();
        }

        public clsUsuario(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsUsuario(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsUsuario(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsUsuario(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsUsuario(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngUsuarioId = 0;
            mstrUsuarioCod = "";
            mstrUsuarioDes = "";
            mlngTipoUsuarioId = 0;
            mstrUsuarioDocPath = "";
            mstrUsuarioFotoPath = "";
            mstrUsuarioMaxSes = "";
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
                    mstrStoreProcName = "segUsuarioSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "segUsuarioSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "segUsuarioSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "segUsuarioSelect";
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
                    moParameters[3] = new SqlParameter("@UsuarioId", mlngUsuarioId);
                    moParameters[4] = new SqlParameter("@UsuarioCod", "");
                    moParameters[5] = new SqlParameter("@TipoUsuarioId", Convert.ToInt32(0));
                    moParameters[6] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.UsuarioDes:
                    break;
                //strSQL = " WHERE  segUsuario.UsuarioDes = " & StringToField(mstrUsuarioDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 4);
                    moParameters[3] = new SqlParameter("@UsuarioId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@UsuarioCod", "");
                    moParameters[5] = new SqlParameter("@TipoUsuarioId", Convert.ToInt32(0));
                    moParameters[6] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.UsuarioCod:
                    Array.Resize(ref moParameters, moParameters.Length + 4);
                    moParameters[3] = new SqlParameter("@UsuarioId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@UsuarioCod", mstrUsuarioCod);
                    moParameters[5] = new SqlParameter("@TipoUsuarioId", Convert.ToInt32(0));
                    moParameters[6] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
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
                    mstrStoreProcName = "segUsuarioInsert";
                    moParameters = new SqlParameter[9] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@UsuarioCod", mstrUsuarioCod),
                        new SqlParameter("@UsuarioDes", mstrUsuarioDes),
                        new SqlParameter("@TipoUsuarioId", mlngTipoUsuarioId),
                        new SqlParameter("@UsuarioDocPath", mstrUsuarioDocPath),
                        new SqlParameter("@UsuarioFotoPath", mstrUsuarioFotoPath),
                        new SqlParameter("@UsuarioMaxSes", mstrUsuarioMaxSes),
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
                    mstrStoreProcName = "segUsuarioUpdate";
                    moParameters = new SqlParameter[9] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@UsuarioId", mlngUsuarioId),
                        new SqlParameter("@UsuarioCod", mstrUsuarioCod),
                        new SqlParameter("@UsuarioDes", mstrUsuarioDes),
                        new SqlParameter("@TipoUsuarioId", mlngTipoUsuarioId),
                        new SqlParameter("@UsuarioDocPath", mstrUsuarioDocPath),
                        new SqlParameter("@UsuarioFotoPath", mstrUsuarioFotoPath),
                        new SqlParameter("@UsuarioMaxSes", mstrUsuarioMaxSes),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "segUsuarioDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@UsuarioId", mlngUsuarioId)};
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
                        mlngUsuarioId = SysData.ToLong(oDataRow["UsuarioId"]);
                        mstrUsuarioCod = SysData.ToStr(oDataRow["UsuarioCod"]);
                        mstrUsuarioDes = SysData.ToStr(oDataRow["UsuarioDes"]);
                        mlngTipoUsuarioId = SysData.ToLong(oDataRow["TipoUsuarioId"]);
                        mstrUsuarioDocPath = SysData.ToStr(oDataRow["UsuarioDocPath"]);
                        mstrUsuarioFotoPath = SysData.ToStr(oDataRow["UsuarioFotoPath"]);
                        mstrUsuarioMaxSes = SysData.ToStr(oDataRow["UsuarioMaxSes"]);
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        break;

                    case SelectFilters.ListBox:
                        mlngUsuarioId = SysData.ToLong(oDataRow["UsuarioId"]);
                        mstrUsuarioCod = SysData.ToStr(oDataRow["UsuarioCod"]);
                        mstrUsuarioDes = SysData.ToStr(oDataRow["UsuarioDes"]);
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

            if (mstrUsuarioCod.Length == 0)
            {
                strMsg += "Código es Requerido <br />";
            }

            if (mstrUsuarioDes.Length == 0)
            {
                strMsg += "Usuario es Requerido <br />";
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