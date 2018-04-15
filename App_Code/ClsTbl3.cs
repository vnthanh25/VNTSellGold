using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNTSellGold.App_Code
{
    public class ClsTbl3
    {
        private int _Id;

        private string _Name;

        public ClsTbl3()
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

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

    }
}
