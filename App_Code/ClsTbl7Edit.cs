using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNTSellGold.App_Code
{
    public partial class ClsTbl7Edit
    {
        private int _Id;

        private System.Nullable<int> _IdTbl1;

        private System.Nullable<int> _IdTbl2;

        private System.Nullable<int> _ICol1;

        private System.Nullable<int> _ICol3;

        private System.Nullable<decimal> _MCol1;

        private System.Nullable<decimal> _MCol2;

        private System.Nullable<decimal> _MCol1Tbl7;

        private string _SCol1Tbl1;

        private string _SCol1Tbl2;

        private string _SCol1Tbl3;

        private string _SCol1;


        private System.Nullable<System.DateTime> _CreateDate;

        public ClsTbl7Edit()
        {
        }

        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                    this._Id = value;
            }
        }

        public System.Nullable<int> IdTbl1
        {
            get
            {
                return this._IdTbl1;
            }
            set
            {
                    this._IdTbl1 = value;
            }
        }

        public System.Nullable<int> IdTbl2
        {
            get
            {
                return this._IdTbl2;
            }
            set
            {
                    this._IdTbl2 = value;
            }
        }

        public System.Nullable<int> ICol1
        {
            get
            {
                return this._ICol1;
            }
            set
            {
                this._ICol1 = value;
            }
        }

        public System.Nullable<int> ICol3
        {
            get
            {
                return this._ICol3;
            }
            set
            {
                    this._ICol3 = value;
            }
        }

        public System.Nullable<decimal> MCol1
        {
            get
            {
                return this._MCol1;
            }
            set
            {
                    this._MCol1 = value;
            }
        }

        public System.Nullable<decimal> MCol2
        {
            get
            {
                return this._MCol2;
            }
            set
            {
                    this._MCol2 = value;
            }
        }

        public System.Nullable<decimal> MCol1Tbl7
        {
            get
            {
                return this._MCol1Tbl7;
            }
            set
            {
                this._MCol1Tbl7 = value;
            }
        }

        public string SCol1Tbl1
        {
            get
            {
                return this._SCol1Tbl1;
            }
            set
            {
                    this._SCol1Tbl1 = value;
            }
        }

        public string SCol1Tbl2
        {
            get
            {
                return this._SCol1Tbl2;
            }
            set
            {
                this._SCol1Tbl2 = value;
            }
        }

        public string SCol1Tbl3
        {
            get
            {
                return this._SCol1Tbl3;
            }
            set
            {
                this._SCol1Tbl3 = value;
            }
        }

        public string SCol1
        {
            get
            {
                return this._SCol1;
            }
            set
            {
                    this._SCol1 = value;
            }
        }

        public System.Nullable<System.DateTime> CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                    this._CreateDate = value;
            }
        }

    }
}
