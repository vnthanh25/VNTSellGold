using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System;

namespace VNTSellGold.App_Code
{
    public partial class ClsTbl5Edit : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id;

        private System.Nullable<int> _IdTbl1;

        private System.Nullable<int> _IdTbl2;

        private System.Nullable<int> _ICol1;

        private System.Nullable<int> _ICol2;

        private System.Nullable<decimal> _MCol1;

        private System.Nullable<decimal> _MCol2;

        private string _SCol1Tbl1;

        private string _SCol1Tbl2;

        private string _SCol1;

        private string _SCol2;

        private string _CreateBy;

        private System.Nullable<System.DateTime> _CreateDate;

        private string _ModifyBy;

        private System.Nullable<System.DateTime> _ModifyDate;

        private EntitySet<Tbl7> _Tbl7s;

        private EntitySet<Tbl6> _Tbl6s;

        private EntityRef<Tbl1> _Tbl1;

        private EntityRef<Tbl2> _Tbl2;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnIdTbl1Changing(System.Nullable<int> value);
        partial void OnIdTbl1Changed();
        partial void OnIdTbl2Changing(System.Nullable<int> value);
        partial void OnIdTbl2Changed();
        partial void OnICol1Changing(System.Nullable<int> value);
        partial void OnICol1Changed();
        partial void OnICol2Changing(System.Nullable<int> value);
        partial void OnICol2Changed();
        partial void OnMCol1Changing(System.Nullable<decimal> value);
        partial void OnMCol1Changed();
        partial void OnMCol2Changing(System.Nullable<decimal> value);
        partial void OnMCol2Changed();
        partial void OnSCol1Tbl1Changing(string value);
        partial void OnSCol1Tbl1Changed();
        partial void OnSCol1Tbl2Changing(string value);
        partial void OnSCol1Tbl2Changed();
        partial void OnSCol1Changing(string value);
        partial void OnSCol1Changed();
        partial void OnSCol2Changing(string value);
        partial void OnSCol2Changed();
        partial void OnCreateByChanging(string value);
        partial void OnCreateByChanged();
        partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
        partial void OnCreateDateChanged();
        partial void OnModifyByChanging(string value);
        partial void OnModifyByChanged();
        partial void OnModifyDateChanging(System.Nullable<System.DateTime> value);
        partial void OnModifyDateChanged();
        #endregion

        public ClsTbl5Edit()
        {
            OnCreated();
        }

        [Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

        [Column(Storage = "_IdTbl1", DbType = "Int")]
        public System.Nullable<int> IdTbl1
        {
            get
            {
                return this._IdTbl1;
            }
            set
            {
                if ((this._IdTbl1 != value))
                {
                    if (this._Tbl1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnIdTbl1Changing(value);
                    this.SendPropertyChanging();
                    this._IdTbl1 = value;
                    this.SendPropertyChanged("IdTbl1");
                    this.OnIdTbl1Changed();
                }
            }
        }

        [Column(Storage = "_IdTbl2", DbType = "Int")]
        public System.Nullable<int> IdTbl2
        {
            get
            {
                return this._IdTbl2;
            }
            set
            {
                if ((this._IdTbl2 != value))
                {
                    if (this._Tbl2.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnIdTbl2Changing(value);
                    this.SendPropertyChanging();
                    this._IdTbl2 = value;
                    this.SendPropertyChanged("IdTbl2");
                    this.OnIdTbl2Changed();
                }
            }
        }

        [Column(Storage = "_ICol1", DbType = "Int")]
        public System.Nullable<int> ICol1
        {
            get
            {
                return this._ICol1;
            }
            set
            {
                if ((this._ICol1 != value))
                {
                    this.OnICol1Changing(value);
                    this.SendPropertyChanging();
                    this._ICol1 = value;
                    this.SendPropertyChanged("ICol1");
                    this.OnICol1Changed();
                }
            }
        }

        [Column(Storage = "_ICol2", DbType = "Int")]
        public System.Nullable<int> ICol2
        {
            get
            {
                return this._ICol2;
            }
            set
            {
                if ((this._ICol2 != value))
                {
                    this.OnICol2Changing(value);
                    this.SendPropertyChanging();
                    this._ICol2 = value;
                    this.SendPropertyChanged("ICol2");
                    this.OnICol2Changed();
                }
            }
        }

        [Column(Storage = "_MCol1", DbType = "Money")]
        public System.Nullable<decimal> MCol1
        {
            get
            {
                return this._MCol1;
            }
            set
            {
                if ((this._MCol1 != value))
                {
                    this.OnMCol1Changing(value);
                    this.SendPropertyChanging();
                    this._MCol1 = value;
                    this.SendPropertyChanged("MCol1");
                    this.OnMCol1Changed();
                }
            }
        }

        [Column(Storage = "_MCol2", DbType = "Money")]
        public System.Nullable<decimal> MCol2
        {
            get
            {
                return this._MCol2;
            }
            set
            {
                if ((this._MCol2 != value))
                {
                    this.OnMCol2Changing(value);
                    this.SendPropertyChanging();
                    this._MCol2 = value;
                    this.SendPropertyChanged("MCol2");
                    this.OnMCol2Changed();
                }
            }
        }

        [Column(Storage = "_SCol1Tbl1", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string SCol1Tbl1
        {
            get
            {
                return this._SCol1Tbl1;
            }
            set
            {
                if ((this._SCol1Tbl1 != value))
                {
                    this.OnSCol1Tbl1Changing(value);
                    this.SendPropertyChanging();
                    this._SCol1Tbl1 = value;
                    this.SendPropertyChanged("SCol1Tbl1");
                    this.OnSCol1Tbl1Changed();
                }
            }
        }

        [Column(Storage = "_SCol1Tbl2", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string SCol1Tbl2
        {
            get
            {
                return this._SCol1Tbl2;
            }
            set
            {
                if ((this._SCol1Tbl2 != value))
                {
                    this.OnSCol1Tbl2Changing(value);
                    this.SendPropertyChanging();
                    this._SCol1Tbl2 = value;
                    this.SendPropertyChanged("SCol1Tbl2");
                    this.OnSCol1Tbl2Changed();
                }
            }
        }

        [Column(Storage = "_SCol1", DbType = "NVarChar(500)")]
        public string SCol1
        {
            get
            {
                return this._SCol1;
            }
            set
            {
                if ((this._SCol1 != value))
                {
                    this.OnSCol1Changing(value);
                    this.SendPropertyChanging();
                    this._SCol1 = value;
                    this.SendPropertyChanged("SCol1");
                    this.OnSCol1Changed();
                }
            }
        }

        [Column(Storage = "_SCol2", DbType = "NVarChar(1000)")]
        public string SCol2
        {
            get
            {
                return this._SCol2;
            }
            set
            {
                if ((this._SCol2 != value))
                {
                    this.OnSCol2Changing(value);
                    this.SendPropertyChanging();
                    this._SCol2 = value;
                    this.SendPropertyChanged("SCol2");
                    this.OnSCol2Changed();
                }
            }
        }

        [Column(Storage = "_CreateBy", DbType = "NVarChar(50)")]
        public string CreateBy
        {
            get
            {
                return this._CreateBy;
            }
            set
            {
                if ((this._CreateBy != value))
                {
                    this.OnCreateByChanging(value);
                    this.SendPropertyChanging();
                    this._CreateBy = value;
                    this.SendPropertyChanged("CreateBy");
                    this.OnCreateByChanged();
                }
            }
        }

        [Column(Storage = "_CreateDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                if ((this._CreateDate != value))
                {
                    this.OnCreateDateChanging(value);
                    this.SendPropertyChanging();
                    this._CreateDate = value;
                    this.SendPropertyChanged("CreateDate");
                    this.OnCreateDateChanged();
                }
            }
        }

        [Column(Storage = "_ModifyBy", DbType = "NVarChar(50)")]
        public string ModifyBy
        {
            get
            {
                return this._ModifyBy;
            }
            set
            {
                if ((this._ModifyBy != value))
                {
                    this.OnModifyByChanging(value);
                    this.SendPropertyChanging();
                    this._ModifyBy = value;
                    this.SendPropertyChanged("ModifyBy");
                    this.OnModifyByChanged();
                }
            }
        }

        [Column(Storage = "_ModifyDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ModifyDate
        {
            get
            {
                return this._ModifyDate;
            }
            set
            {
                if ((this._ModifyDate != value))
                {
                    this.OnModifyDateChanging(value);
                    this.SendPropertyChanging();
                    this._ModifyDate = value;
                    this.SendPropertyChanged("ModifyDate");
                    this.OnModifyDateChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
