using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ------------------------------
using System.Collections;

namespace VNTSellGold.App_Code
{
    class ClsProperty
    {
        public Hashtable Properties = new Hashtable();

        public static Hashtable MtdGetHastble(int pColCount)
        {
            Hashtable oHashtable = new Hashtable();
            pColCount++;
            for (int i = 1; i < pColCount; i++)
            {
                oHashtable.Add("Col" + i.ToString(), "Col" + i.ToString());
            }
            return oHashtable;
        }

        
    }
}
