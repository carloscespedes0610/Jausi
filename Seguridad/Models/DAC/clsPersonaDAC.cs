using p01.Valores;
using Seguridad.Models.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Seguridad.Models.DAC
{
    public class clsPersonaDAC : clsBase
    {

        public long PersonaID { get; set; }
        public string PersonaNombre { get; set; }
        public string PersonaSexo { get; set; }
        public string PersonaEstadoCivil { get; set; }
        public DateTime PersonaFechaNacimiento { get; set; }
        public string PersonaTelefono { get; set; }

        // procedimientos
        public static string proce_select_Persona = "PersonaSelect";

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
            PersonaNombre = 2,
            Grid = 3,
            GridCheck = 4,
            PersonaTelefono = 5,

        }

        public enum OrderByFilters : byte
        {
            None = 0,
            PersonaId = 1,
            PersonaNombre = 2,
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
            get { return mintSelectFilter; }
            set { mintSelectFilter = value; }
        }

        public WhereFilters WhereFilter
        {
            get { return mintWhereFilter; }
            set { mintWhereFilter = value; }
        }

        public OrderByFilters OrderByFilter
        {
            get { return mintOrderByFilter; }
            set { mintOrderByFilter = value; }
        }

        public InsertFilters InsertFilter
        {
            get { return mintInsertFilter; }
            set { mintInsertFilter = value; }
        }

        public UpdateFilters UpdateFilter
        {
            get { return mintUpdateFilter; }
            set { mintUpdateFilter = value; }
        }

        public DeleteFilters DeleteFilter
        {
            get { return mintDeleteFilter; }
            set { mintDeleteFilter = value; }
        }

        public RowCountFilters RowCountFilter
        {
            get { return mintRowCountFilter; }
            set { mintRowCountFilter = value; }
        }


        public clsPersonaDAC()
        {
            mstrTableName = "Persona";
            mstrClassName = "clsPersonaDAC";

            PropertyInit();
            FilterInit();
        }

        private void FilterInit()
        {
            mintWhereFilter = 0;
            mintOrderByFilter = 0;
            mintSelectFilter = 0;
            mintInsertFilter = 0;
            mintUpdateFilter = 0;
            mintDeleteFilter = 0;
            mintRowCountFilter = 0;
        }

        private void PropertyInit()
        {
            this.PersonaID = 0;
            this.PersonaNombre = string.Empty;
            this.PersonaSexo = string.Empty;
            this.PersonaTelefono = string.Empty;
            this.PersonaEstadoCivil = string.Empty;
            this.PersonaFechaNacimiento= DateTime.Now;
        }

        public clsPersonaDAC(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsPersonaDAC(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsPersonaDAC(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsPersonaDAC(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsPersonaDAC(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }



        public override bool Validate()
        {
            bool returnValue = false;
            string strMsg = string.Empty;

            if (this.PersonaNombre.Length == 0)
            {
                strMsg += "Nombre es Requerido <br />";
            }

            if (this.PersonaSexo.Length == 0)
            {
                strMsg += "Sexo es Requerido <br />";
            }

            if (this.PersonaEstadoCivil.Length == 0)
            {
                strMsg += "EstadoCivil es Requerido <br />";
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

        protected override void DeleteParameter()
        {
            throw new NotImplementedException();
        }

        protected override void InsertParameter()
        {
            throw new NotImplementedException();
        }

        protected override void Retrieve(DataRow oDataRow)
        {
            throw new NotImplementedException();
        }

        protected override void SelectParameter()
        {
            Array.Resize(ref moParameters, 3);
            moParameters[0] = new SqlParameter(ValoresSql.select_filter, mintSelectFilter);
            moParameters[1] = new SqlParameter(ValoresSql.where_filter, mintWhereFilter);
            moParameters[2] = new SqlParameter(ValoresSql.order_filter, mintOrderByFilter);

            switch (this.mintSelectFilter)
            {
                case SelectFilters.All:
                    mstrStoreProcName = proce_select_Persona;
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = proce_select_Persona;
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = proce_select_Persona;
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = proce_select_Persona;
                    break;

                case SelectFilters.GridCheck:
                    break;
            }

            WhereParameter();
        }

        private void WhereParameter()
        {
            string varPersonaId = "@" + clsPersonaVM.varPersonaId;
            string varPersonaNombre = "@" + clsPersonaVM.varPersonaNombre;

            switch (this.mintWhereFilter)
            {
                case WhereFilters.PrimaryKey:
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter(varPersonaId, this.PersonaID); 
                    moParameters[4] = new SqlParameter(varPersonaNombre, string.Empty);
                    break;

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter(varPersonaId, Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter(varPersonaNombre, Convert.ToInt32(0));
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            throw new NotImplementedException();
        }
    }
}