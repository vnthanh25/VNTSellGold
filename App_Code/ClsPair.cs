using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNTSellGold.App_Code
{
    public class ClsPair
    {
        private int _Id;

        private string _Name;

        public ClsPair()
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
