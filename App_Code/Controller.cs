using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//------------------------------
using System.Resources;
using System.Globalization;
using System.IO;

namespace VNTSellGold.App_Code
{
    class Controller
    {
        #region Members *****************************************
        LinqDataContext memLinq;
        StreamWriter swLog;
        int iCol3Tbl5Max = 9999;

        #region static
        public static string CulName = "vi-VN";
        #endregion static
        #endregion Members -----------------------------------------

        #region Properties *****************************************
        public LinqDataContext MemLinq
        {
            set { memLinq = value; }
            get { return memLinq; }
        }
        #endregion Properties -----------------------------------------

        #region Methods *****************************************
        #region Tbl1
        public List<Tbl1> Tbl1_Gets_OrderBySCol1()
        {
            return (from tbl1s in MemLinq.Tbl1s
                    select tbl1s).OrderBy(t1 => t1.SCol1).ToList();
        }
        #endregion Tbl1 -------------------------------------------- End

        #region Tbl2
        public List<Tbl2> Tbl2_Gets_OrderBySCol1()
        {
            return (from tbl2s in MemLinq.Tbl2s
                    select tbl2s).OrderBy(t2 => t2.SCol1).ToList();
        }
        #endregion Tbl2 -------------------------------------------- End

        #region Tbl3
        public List<ClsTbl3> Tbl3_Gets_Pair(string pCurrentUser)
        {
            return (from tbl3s in MemLinq.Tbl3s
                    where tbl3s.SCol1 != pCurrentUser
                    select new ClsTbl3()
                    {
                        Name = tbl3s.SCol2 + " " + tbl3s.SCol3,
                        Id = tbl3s.Id
                    }).ToList();
        }

        public List<Tbl3> Tbl3_Gets()
        {
            return MemLinq.Tbl3s.ToList();
        }

        public bool Tbl3_Check_SCol1(int pId, string pSCol1)
        {
            try
            {
                string sCol1 = MemLinq.Tbl3s.Where(tbl3 => tbl3.Id == pId).Select(tbl3 => tbl3.SCol1).Single();
                return sCol1 == pSCol1;
            }
            catch (Exception ex) { }
            return false;
        }
        #endregion Tbl3 -------------------------------------------- End

        #region Tbl4

        #endregion Tbl4 -------------------------------------------- End

        #region Tbl5
        /// <summary>
        /// * Nếu chưa giao thì cập nhật ICol2 từ 0 thành 1. Ngược lại thì 2 thành 3(đã giao).
        /// </summary>
        public int Tbl5_Update_ICol2_Tbl5Edit()
        {
            try
            {
                int iResult = MemLinq.ExecuteCommand("Update Tbl5 Set ICol2 = 1 Where ICol2 = 0");
                iResult += MemLinq.ExecuteCommand("Update Tbl5 Set ICol2 = 3 Where ICol2 = 2");
                return iResult;
            }
            catch (Exception ex) { }
            return 0;
        }

        /// <summary>
        /// * Nếu chưa giao thì cập nhật ICol2 từ 10 thành 11. Ngược lại thì 12 thành 13(đã giao).
        /// </summary>
        public int Tbl5_Update_ICol2_Tbl7Edit()
        {
            try
            {
                int iResult = MemLinq.ExecuteCommand("Update Tbl5 Set ICol2 = 11 Where ICol2 = 10");
                iResult += MemLinq.ExecuteCommand("Update Tbl5 Set ICol2 = 13 Where ICol2 = 12");
                return iResult;
            }
            catch (Exception ex) { }
            return 0;
        }

        public void Tbl5_Update_Sell(int pIdTbl5, int pIdTbl3)
        {
            Tbl5 oTbl5 = MemLinq.Tbl5s.Where(tbl5 => tbl5.Id == pIdTbl5).Single();
            if (pIdTbl3 == 0)
            {
                oTbl5.ICol2 = 10;
            }
            else
            {
                oTbl5.ICol2 = 12;
                oTbl5.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).FirstOrDefault().DTCol2 = MtdGetDate();
            }
        }

        public int Tbl5_SumICol1_Sell(int pIdTbl3)
        {
            try
            {
                return MemLinq.Tbl5s.Where(tbl5 => (pIdTbl3 == 0 && tbl5.ICol2 == 10) // Chưa giao mới được bán.
                    || (pIdTbl3 > 0 && tbl5.ICol2 == 12 && tbl5.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).First().IdTbl3 == pIdTbl3)).Sum(tbl5 => tbl5.ICol1).Value;
            }
            catch (Exception ex) { }
            return 0;
        }

        public int Tbl5_SumICol1(int pIdTbl3)
        {
            try
            {
                return
                    (from t5s in MemLinq.Tbl5s
                     where (pIdTbl3 == 0 && t5s.ICol2 < 2) // Chưa Giao
                     || (pIdTbl3 > 0 && t5s.ICol2 > 1 && t5s.ICol2 < 10 && t5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3)
                     orderby t5s.CreateDate descending
                     select t5s).Sum(tbl5 => tbl5.ICol1).Value;
            }
            catch (Exception ex) { }
            return 0;
        }

        public int Tbl5_SumICol1_New(int pIdTbl3)
        {
            try
            {
                return
                    (from t5s in MemLinq.Tbl5s
                     where (pIdTbl3 == 0 && t5s.ICol2 == 0) // Chưa Giao
                     || (pIdTbl3 > 0 && t5s.ICol2 == 2 && t5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3)
                     select t5s).Sum(tbl5 => tbl5.ICol1).Value;
            }
            catch (Exception ex) { }
            return 0;
        }

        public int Tbl5_SumICol1_Buy()
        {
            try
            {
                return
                    (from t5s in MemLinq.Tbl5s
                     where t5s.ICol2 < 10
                     select t5s).Sum(tbl5 => tbl5.ICol1).Value;
            }
            catch (Exception ex) { }
            return 0;
        }

        public decimal Tbl5_SumMCol1_Buy()
        {
            try
            {
                return MemLinq.Tbl5s.Where(tbl5 => tbl5.ICol2 < 10).Sum(tbl5 => tbl5.MCol2).Value;
            }
            catch (Exception ex) { }
            return 0;
        }

        public int Tbl5_SumICol1_Sell()
        {
            try
            {
                return
                    (from t5s in MemLinq.Tbl5s
                     where t5s.ICol2 > 9
                     select t5s).Sum(tbl5 => tbl5.ICol1).Value;
            }
            catch (Exception ex) { }
            return 0;
        }

        public int Tbl5_Count()
        {
            try
            {
                return (from t5s in MemLinq.Tbl5s
                        select t5s).Count();
            }
            catch (Exception ex) { }
            return 0;
        }

        public List<ClsTbl14Col> Tbl5_Gets_OrderDesByCreateDate(int pPageIndex, int pPageSize, int pIdTbl3)
        {
            CultureInfo cul = MtdGetCulture();
            List<ClsTbl14Col> lstTbl5Edit =
                (from t5s in MemLinq.Tbl5s
                 where (pIdTbl3 == 0 && t5s.ICol2 < 2) // Chưa Giao
                 || (pIdTbl3 > 0 && t5s.ICol2 > 1 && t5s.ICol2 < 10 && t5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3)
                 orderby t5s.CreateDate descending
                 //where t5s.ICol2 < 7 // Không phải bán.
                 //&& ((pIdTbl3 == 0 && t5s.Tbl6s.Where(t6 => t6.DTCol2 == null).Count() == 0) 
                 //|| t5s.Tbl6s.Where(t6 => t6.DTCol2 == null && t6.IdTbl3 == pIdTbl3).Count() > 0)
                 //&& (t5s.Tbl6s.Count == 0 || t5s.Tbl6s.Where(t6 => t6.DTCol2 == null).Count() == 0)
                 select new
                 {
                     Col1 = t5s.Id,
                     Col2 = t5s.ICol3,
                     Col3 = t5s.IdTbl1,
                     Col4 = t5s.IdTbl2,
                     Col5 = t5s.Tbl1.SCol1,
                     Col6 = t5s.Tbl2.SCol1,
                     Col7 = t5s.ICol1,
                     Col8 = t5s.MCol1,
                     Col9 = t5s.MCol2,
                     Col10 = t5s.SCol1,
                     Col11 = t5s.CreateDate,
                     Col12 = t5s.ICol2 == 0 || t5s.ICol2 == 2 ? "Mới Nhập" : t5s.ICol2 == 1 ? "Chưa Giao" : "Đã Có",
                     Col13 = t5s.SCol2,
                     Col14 = t5s.Tbl6s.Count == 1 ? t5s.Tbl6s.Single().IdTbl3.ToString() : "0"
                 }).Skip(pPageIndex).AsEnumerable().TakeWhile((t5, idx) => pPageSize == -1 ? true : idx < pPageSize).ToList()
                 .Select(t5 => new ClsTbl14Col()
                 {
                     Col1 = t5.Col1.ToString(),
                     Col2 = t5.Col2.ToString(),
                     Col3 = t5.Col3.ToString(),
                     Col4 = t5.Col4.ToString(),
                     Col5 = t5.Col5,
                     Col6 = t5.Col6,
                     Col7 = t5.Col7.GetValueOrDefault(0) == 0 ? "0" : t5.Col7.GetValueOrDefault(0).ToString("#,#", cul),
                     Col8 = t5.Col8.GetValueOrDefault(0) == 0 ? "0" : t5.Col8.GetValueOrDefault(0).ToString("#,#", cul),
                     Col9 = t5.Col9.GetValueOrDefault(0) == 0 ? "0" : t5.Col9.GetValueOrDefault(0).ToString("#,#", cul),
                     Col10 = t5.Col10,
                     Col11 = t5.Col11.HasValue ? t5.Col11.Value.ToString("dd/MM/yyyy") : "",
                     Col12 = t5.Col12,
                     Col13 = t5.Col13,
                     Col14 = t5.Col14
                 }).ToList<ClsTbl14Col>();

            return lstTbl5Edit;
        }

        public int Tbl5_Gets_OrderDesByCreateDate_Count(int pIdTbl3)
        {
            try
            {
                return
                    (from t5s in MemLinq.Tbl5s
                     where (pIdTbl3 == 0 && t5s.ICol2 < 2) // Chưa Giao
                     || (pIdTbl3 > 0 && t5s.ICol2 > 1 && t5s.ICol2 < 10 && t5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3)
                     select t5s).Count();
            }
            catch (Exception ex) { }
            return 0;
        }

        public int Tbl5_Gets_OrderDesByCreateDate_NewCount(int pIdTbl3)
        {
            try
            {
                return
                    (from t5s in MemLinq.Tbl5s
                     where (pIdTbl3 == 0 && t5s.ICol2 == 0) // Chưa Giao mới nhập.
                     || (pIdTbl3 > 0 && t5s.ICol2 == 2 && t5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3)// Đã giao mới nhập.
                     select t5s).Count();
            }
            catch (Exception ex) { }
            return 0;
        }

        public List<int> Tbl5_Gets_ICol3_OrderDesByCreateDate(int pPageIndex, int pPageSize, int pIdTbl3)
        {
            List<int> lstTbl5ICol3 =
                (from t5s in MemLinq.Tbl5s
                 where (pIdTbl3 == 0 && t5s.ICol2 < 2) // Chưa Giao
                 || (pIdTbl3 > 0 && t5s.ICol2 > 1 && t5s.ICol2 < 10 && t5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3) // đã giao chưa bán (cho ai).
                 select new
                 {
                     t5s.ICol3,
                     t5s.CreateDate
                 }).OrderByDescending(t5 => t5.CreateDate).Skip(pPageIndex).AsEnumerable().TakeWhile((t5, idx) => pPageSize == -1 ? true : idx < pPageSize)
                 .Select(t5 => t5.ICol3.Value).AsEnumerable().ToList();
            return lstTbl5ICol3;
        }

        public int Tbl5_Get_ICol3()
        {
            int iCol3 = 1;
            var vICol3 =
                (from tbl5 in MemLinq.Tbl5s
                 where tbl5.ICol2 < 10
                 orderby tbl5.ICol3 descending
                 select new
                     {
                         tbl5.ICol3
                     }).FirstOrDefault();
            if (vICol3 != null)
            {
                iCol3 = vICol3.ICol3.Value + 1;
                // Nếu đạt tới mã số lớn nhất thì quay lại tìm mã số còn trống, bắt đầu từ 1.
                if (iCol3 - 1 == iCol3Tbl5Max)
                {
                    iCol3 = 0;
                    var lstICol3 =
                        (from tbl5 in MemLinq.Tbl5s
                         where tbl5.ICol2 < 10
                         orderby tbl5.ICol3
                         select new
                             {
                                 tbl5.ICol3
                             }).ToList();
                    int i;
                    for (i = 0; i < lstICol3.Count(); i++)
                    {
                        iCol3++;
                        if (iCol3 != lstICol3[i].ICol3)
                            break;
                    }
                    // Nếu không còn mã số nào trống thì trả về -1.
                    if (i == lstICol3.Count)
                        return -1;
                }
            }
            return iCol3;
        }

        public Tbl5 Tbl5_Get_ById(int pId)
        {
            return (from t5s in MemLinq.Tbl5s
                    where t5s.Id == pId
                    select t5s).FirstOrDefault();
        }
        /// <summary>
        /// * Lấy ra những Trang sức trong Tbl5 nhưng không có trong Tbl6 (DTCol2=null) và Tbl7.
        /// </summary>
        /// <returns></returns>
        public List<Tbl5> Tbl5_Gets_ByCreateBy(string pCreateBy)
        {
            return (from tbl5s in MemLinq.Tbl5s
                    where tbl5s.CreateBy == pCreateBy
                    && tbl5s.ICol2 < 2 // Chưa giao.
                    //&& tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).FirstOrDefault() == null
                    //&& tbl5s.Tbl7s.FirstOrDefault() == null
                    select tbl5s).ToList();
        }

        public List<Tbl5> Tbl5_Gets_ByIdTbl3(int pIdTbl3)
        {
            return (from t5s in MemLinq.Tbl5s
                    where (pIdTbl3 == 0 && t5s.ICol2 < 2) // Chưa Giao
                    || (pIdTbl3 > 0 && t5s.ICol2 > 1 && t5s.ICol2 < 10 && t5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3) // đã giao chưa bán (cho ai).
                    select t5s).ToList();
        }
        #endregion Tbl5 -------------------------------------------- End

        #region Tbl6
        public List<Tbl6> Tbl6_Gets_ByIdTbl3(int pIdTbl3)
        {
            return (from tbl6s in MemLinq.Tbl6s
                    where tbl6s.DTCol2 == null && tbl6s.IdTbl3 == pIdTbl3
                    //&& oCtrLer.MemLinq.Tbl7s.Where(tbl7 => tbl7.IdTbl5 == tbl6s.IdTbl5).FirstOrDefault() == null
                    select tbl6s).ToList();
        }
        #endregion Tbl6 -------------------------------------------- End

        #region Tbl7
        public int Tbl7_Count()
        {
            try
            {
                return (from t7s in MemLinq.Tbl7s
                        select t7s).Count();
            }
            catch (Exception ex) { }
            return 0;
        }

        public int Tbl7_Count_Sell(int pIdTbl3)
        {
            try
            {
                return
                    MemLinq.Tbl7s.Where(tbl7 => (pIdTbl3 == 0 && tbl7.Tbl5.ICol2 == 10) // Chưa giao mới được bán.
                    || (pIdTbl3 > 0 && tbl7.Tbl5.ICol2 == 12 && tbl7.Tbl5.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).First().IdTbl3 == pIdTbl3)).Count();
            }
            catch (Exception ex) { }
            return 0;
        }

        public decimal Tbl7_SumMCol1(int pIdTbl3)
        {
            try
            {
                return MemLinq.Tbl7s.Where(tbl7 => (pIdTbl3 == 0 && tbl7.Tbl5.ICol2 == 10) // Chưa giao mới được bán.
                    || (pIdTbl3 > 0 && tbl7.Tbl5.ICol2 == 12 && tbl7.Tbl5.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).First().IdTbl3 == pIdTbl3)).Sum(tbl7 => tbl7.MCol1).Value;
            }
            catch (Exception ex) { }
            return 0;
        }

        public decimal Tbl7_SumMCol1_Sell()
        {
            try
            {
                return MemLinq.Tbl7s.Where(tbl7 => tbl7.Tbl5.ICol2 > 9).Sum(tbl7 => tbl7.MCol1).Value;
            }
            catch (Exception ex) { }
            return 0;
        }

        public List<ClsTbl7Edit> Tbl7_Gets_OrderDesByCreateDate(int pPageIndex, int pPageSize, int pIdTbl3)
        {
            CultureInfo cul = MtdGetCulture();
            List<ClsTbl7Edit> lstClsTbl7Edit =
             (from tbl7s in MemLinq.Tbl7s
              where (pIdTbl3 == 0 && tbl7s.Tbl5.ICol2 == 10) // Chưa giao mới nhập.
              || (pIdTbl3 > 0 && tbl7s.Tbl5.ICol2 == 12 && tbl7s.Tbl5.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).First().IdTbl3 == pIdTbl3) // Đã giao mới nhập (cho ai).
              select new ClsTbl7Edit()
              {
                  Id = tbl7s.Tbl5.Id,
                  ICol3 = tbl7s.Tbl5.ICol3,
                  IdTbl1 = tbl7s.Tbl5.IdTbl1,
                  IdTbl2 = tbl7s.Tbl5.IdTbl2,
                  SCol1Tbl1 = tbl7s.Tbl5.Tbl1.SCol1,
                  SCol1Tbl2 = tbl7s.Tbl5.Tbl2.SCol1,
                  ICol1 = tbl7s.Tbl5.ICol1,
                  SCol1Tbl3 = pIdTbl3 == 0 ? "Chưa Giao" : tbl7s.Tbl5.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).FirstOrDefault().Tbl3.SCol2 + " " + tbl7s.Tbl5.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).FirstOrDefault().Tbl3.SCol3,
                  MCol1 = tbl7s.Tbl5.MCol1,
                  MCol2 = tbl7s.Tbl5.MCol2,
                  MCol1Tbl7 = tbl7s.MCol1,
                  SCol1 = tbl7s.SCol1,
                  CreateDate = tbl7s.DTCol1
              }).OrderByDescending(t5 => t5.CreateDate).Skip(pPageIndex).AsEnumerable().TakeWhile((t5, idx) => pPageSize == -1 ? true : idx < pPageSize).ToList();
            return lstClsTbl7Edit;
        }
        #endregion Tbl7 -------------------------------------------- End

        #region ClsTbl
        public List<ClsTbl9Col> Tbl6_Gets_DesCreateDate(int pPageIndex, int pPageSize, int pIdTbl1, int pIdTbl2, int pIdTbl3, bool pAll, DateTime pFromDate, DateTime pToDate)
        {
            CultureInfo cul = MtdGetCulture();
            return (from tbl5s in MemLinq.Tbl5s
                    where ((pIdTbl3 == -1 || pIdTbl3 == 0) && tbl5s.ICol2 < 2 // chưa giao đang giư
                    && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                    && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                    && (pAll ? true : (tbl5s.CreateDate.Value.Date >= pFromDate.Date && tbl5s.CreateDate.Value.Date <= pToDate)))

                    || ((pIdTbl3 == -1 || pIdTbl3 > 0) && tbl5s.ICol2 > 1 && tbl5s.ICol2 < 4 && (pIdTbl3 == -1 || tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3)
                    && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                    && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                    && (pAll ? true : (tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().DTCol1.Value.Date >= pFromDate.Date && tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().DTCol1.Value.Date <= pToDate)))
                    select new
                    {
                        Col1 = tbl5s.ICol3,
                        Col2 = tbl5s.Tbl1.SCol1,
                        Col3 = tbl5s.Tbl2.SCol1,
                        Col4 = tbl5s.ICol1,
                        Col5 = tbl5s.MCol1,
                        Col6 = tbl5s.MCol2,
                        Col7 = (pIdTbl3 == -1 || pIdTbl3 == 0) ? tbl5s.CreateDate : tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().DTCol1,
                        Col8 = tbl5s.ICol2,
                        Col9 = tbl5s.Id
                    }).OrderByDescending(tbl5 => tbl5.Col7).Skip(pPageIndex).AsEnumerable().TakeWhile((t5, idx) => pPageSize == -1 ? true : idx < pPageSize).ToList()
                    .Select(tbl6 => new ClsTbl9Col()
                        {
                            Col1 = tbl6.Col1.ToString(),
                            Col2 = tbl6.Col2.ToString(),
                            Col3 = tbl6.Col3.ToString(),
                            Col4 = tbl6.Col4.GetValueOrDefault(0) == 0 ? "0" : tbl6.Col4.GetValueOrDefault(0).ToString("#,#", cul),
                            Col5 = tbl6.Col5.GetValueOrDefault(0) == 0 ? "0" : tbl6.Col5.GetValueOrDefault(0).ToString("#,#", cul),
                            Col6 = tbl6.Col6.GetValueOrDefault(0) == 0 ? "0" : tbl6.Col6.GetValueOrDefault(0).ToString("#,#", cul),
                            Col7 = tbl6.Col7.HasValue ? tbl6.Col7.Value.ToString("dd/MM/yyyy") : "",
                            Col8 = tbl6.Col8 < 2 ? "Chưa Giao" : tbl6.Col8 < 10 ? "Đã Có" : "Đã Bán",
                            Col9 = tbl6.Col9.ToString()
                        }).ToList<ClsTbl9Col>();

        }

        public int Tbl6_Gets_DesCreateDate_Count(int pIdTbl1, int pIdTbl2, int pIdTbl3, bool pAll, DateTime pFromDate, DateTime pToDate)
        {
            try
            {
                return (from tbl5s in MemLinq.Tbl5s
                        where ((pIdTbl3 == -1 || pIdTbl3 == 0) && tbl5s.ICol2 < 2 // chưa giao đang giư
                        && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                        && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                        && (pAll ? true : (tbl5s.CreateDate.Value.Date >= pFromDate.Date && tbl5s.CreateDate.Value.Date <= pToDate)))

                        || ((pIdTbl3 == -1 || pIdTbl3 > 0) && tbl5s.ICol2 > 1 && tbl5s.ICol2 < 4 && (pIdTbl3 == -1 || tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3)
                        && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                        && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                        && (pAll ? true : (tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().DTCol1.Value.Date >= pFromDate.Date && tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().DTCol1.Value.Date <= pToDate)))
                        select tbl5s).Count();
            }
            catch (Exception ex) { }
            return 0;
        }

        public int Tbl6_Gets_DesCreateDate_ICol1(int pIdTbl1, int pIdTbl2, int pIdTbl3, bool pAll, DateTime pFromDate, DateTime pToDate)
        {
            try
            {
                return
                    (from tbl5s in MemLinq.Tbl5s
                     where ((pIdTbl3 == -1 || pIdTbl3 == 0) && tbl5s.ICol2 < 2 // chưa giao đang giư
                     && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                     && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                     && (pAll ? true : (tbl5s.CreateDate.Value.Date >= pFromDate.Date && tbl5s.CreateDate.Value.Date <= pToDate)))

                     || ((pIdTbl3 == -1 || pIdTbl3 > 0) && tbl5s.ICol2 > 1 && tbl5s.ICol2 < 4 && (pIdTbl3 == -1 || tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3)
                     && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                     && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                     && (pAll ? true : (tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().DTCol1.Value.Date >= pFromDate.Date && tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().DTCol1.Value.Date <= pToDate)))
                     select tbl5s.ICol1).Sum(tbl5 => tbl5.Value);
            }
            catch (Exception ex) { }
            return 0;
        }

        public decimal Tbl6_Gets_DesCreateDate_ICol1_Sell(int pIdTbl1, int pIdTbl2, int pIdTbl3, bool pAll, DateTime pFromDate, DateTime pToDate)
        {
            try
            {
                return
                    (from tbl5s in MemLinq.Tbl5s
                     where ((pIdTbl3 == -1 || pIdTbl3 == 0) && tbl5s.ICol2 < 2 // chưa giao đang giư
                     && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                     && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                     && (pAll ? true : (tbl5s.CreateDate.Value.Date >= pFromDate.Date && tbl5s.CreateDate.Value.Date <= pToDate)))

                     || ((pIdTbl3 == -1 || pIdTbl3 > 0) && tbl5s.ICol2 > 1 && tbl5s.ICol2 < 4 && (pIdTbl3 == -1 || tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().IdTbl3 == pIdTbl3)
                     && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                     && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                     && (pAll ? true : (tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().DTCol1.Value.Date >= pFromDate.Date && tbl5s.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).First().DTCol1.Value.Date <= pToDate)))
                     select tbl5s.MCol2).Sum(tbl5 => tbl5.Value);
            }
            catch (Exception ex) { }
            return 0;
        }

        public List<ClsTbl9Col> Tbl7_Gets_DesCreateDate(int pPageIndex, int pPageSize, int pIdTbl1, int pIdTbl2, int pIdTbl3, bool pAll, DateTime pFromDate, DateTime pToDate)
        {
            CultureInfo cul = MtdGetCulture();
            return (from tbl5s in MemLinq.Tbl5s
                    where ((pIdTbl3 == -1 || pIdTbl3 == 0) && tbl5s.ICol2 > 9 && tbl5s.ICol2 < 12 // chưa giao đang giư
                    && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                    && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                    && (pAll ? true : (tbl5s.Tbl7s.Single().DTCol1 >= pFromDate.Date && tbl5s.Tbl7s.Single().DTCol1 <= pToDate)))

                    || ((pIdTbl3 == -1 || pIdTbl3 > 0) && tbl5s.ICol2 > 11 && tbl5s.ICol2 < 14 && (pIdTbl3 == -1 || tbl5s.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).First().IdTbl3 == pIdTbl3)
                    && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                    && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                    && (pAll ? true : (tbl5s.Tbl7s.Single().DTCol1 >= pFromDate.Date && tbl5s.Tbl7s.Single().DTCol1 <= pToDate)))
                    select new
                    {
                        Col1 = tbl5s.ICol3,
                        Col2 = tbl5s.Tbl1.SCol1,
                        Col3 = tbl5s.Tbl2.SCol1,
                        Col4 = tbl5s.ICol1,
                        Col5 = tbl5s.MCol1,
                        Col6 = tbl5s.Tbl7s.OrderByDescending(tbl7 => tbl7.DTCol1).Select(tbl71 => tbl71.MCol1).FirstOrDefault(),
                        Col7 = tbl5s.Tbl7s.OrderByDescending(tbl7 => tbl7.DTCol1).Select(tbl71 => tbl71.DTCol1).FirstOrDefault(),
                        Col8 = tbl5s.ICol2,
                        Col9 = tbl5s.Id
                    }).OrderByDescending(tbl5 => tbl5.Col7).Skip(pPageIndex).AsEnumerable().TakeWhile((t5, idx) => pPageSize == -1 ? true : idx < pPageSize).ToList()
                    .Select(tbl5 => new ClsTbl9Col()
                    {
                        Col1 = tbl5.Col1.ToString(),
                        Col2 = tbl5.Col2.ToString(),
                        Col3 = tbl5.Col3.ToString(),
                        Col4 = tbl5.Col4.GetValueOrDefault(0) == 0 ? "0" : tbl5.Col4.GetValueOrDefault(0).ToString("#,#", cul),
                        Col5 = tbl5.Col5.GetValueOrDefault(0) == 0 ? "0" : tbl5.Col5.GetValueOrDefault(0).ToString("#,#", cul),
                        Col6 = tbl5.Col6.GetValueOrDefault(0) == 0 ? "0" : tbl5.Col6.GetValueOrDefault(0).ToString("#,#", cul),
                        Col7 = tbl5.Col7.HasValue ? tbl5.Col7.Value.ToString("dd/MM/yyyy") : "",
                        Col8 = tbl5.Col8 < 2 ? "Chưa Giao" : tbl5.Col8 < 10 ? "Đã Có" : "Đã Bán",
                        Col9 = tbl5.Col9.ToString()
                    }).ToList<ClsTbl9Col>();
        }

        public int Tbl7_Gets_DesCreateDate_Count(int pIdTbl1, int pIdTbl2, int pIdTbl3, bool pAll, DateTime pFromDate, DateTime pToDate)
        {
            try
            {
                return
                  (from tbl5s in MemLinq.Tbl5s
                   where ((pIdTbl3 == -1 || pIdTbl3 == 0) && tbl5s.ICol2 > 9 && tbl5s.ICol2 < 12 // chưa giao đang giư
                   && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                   && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                   && (pAll ? true : (tbl5s.Tbl7s.Single().DTCol1 >= pFromDate.Date && tbl5s.Tbl7s.Single().DTCol1 <= pToDate)))

                   || ((pIdTbl3 == -1 || pIdTbl3 > 0) && tbl5s.ICol2 > 11 && tbl5s.ICol2 < 14 && (pIdTbl3 == -1 || tbl5s.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).First().IdTbl3 == pIdTbl3)
                   && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                   && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                   && (pAll ? true : (tbl5s.Tbl7s.Single().DTCol1 >= pFromDate.Date && tbl5s.Tbl7s.Single().DTCol1 <= pToDate)))
                   select tbl5s).Count();
            }
            catch (Exception ex) { }
            return 0;
        }

        public int Tbl7_Gets_DesCreateDate_ICol1(int pIdTbl1, int pIdTbl2, int pIdTbl3, bool pAll, DateTime pFromDate, DateTime pToDate)
        {
            try
            {
                return
                    (from tbl5s in MemLinq.Tbl5s
                     where ((pIdTbl3 == -1 || pIdTbl3 == 0) && tbl5s.ICol2 > 9 && tbl5s.ICol2 < 12 // chưa giao đang giư
                     && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                     && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                     && (pAll ? true : (tbl5s.Tbl7s.Single().DTCol1 >= pFromDate.Date && tbl5s.Tbl7s.Single().DTCol1 <= pToDate)))

                     || ((pIdTbl3 == -1 || pIdTbl3 > 0) && tbl5s.ICol2 > 11 && tbl5s.ICol2 < 14 && (pIdTbl3 == -1 || tbl5s.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).First().IdTbl3 == pIdTbl3)
                     && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                     && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                     && (pAll ? true : (tbl5s.Tbl7s.Single().DTCol1 >= pFromDate.Date && tbl5s.Tbl7s.Single().DTCol1 <= pToDate)))
                     select tbl5s.ICol1).Sum(tbl5 => tbl5.Value);
            }
            catch (Exception ex) { }
            return 0;
        }

        public decimal Tbl7_Gets_DesCreateDate_Sell(int pIdTbl1, int pIdTbl2, int pIdTbl3, bool pAll, DateTime pFromDate, DateTime pToDate)
        {
            try
            {
                return
                    (from tbl5s in MemLinq.Tbl5s
                     where ((pIdTbl3 == -1 || pIdTbl3 == 0) && tbl5s.ICol2 > 9 && tbl5s.ICol2 < 12 // chưa giao đang giư
                     && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                     && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                     && (pAll ? true : (tbl5s.Tbl7s.Single().DTCol1 >= pFromDate.Date && tbl5s.Tbl7s.Single().DTCol1 <= pToDate)))

                     || ((pIdTbl3 == -1 || pIdTbl3 > 0) && tbl5s.ICol2 > 11 && tbl5s.ICol2 < 14 && (pIdTbl3 == -1 || tbl5s.Tbl6s.OrderByDescending(tbl6 => tbl6.DTCol2).First().IdTbl3 == pIdTbl3)
                     && (pIdTbl1 == 0 ? true : tbl5s.IdTbl1 == pIdTbl1)// Chọn loai trang sức.
                     && (pIdTbl2 == 0 ? true : tbl5s.IdTbl2 == pIdTbl2)// Chọn loai vàng.
                     && (pAll ? true : (tbl5s.Tbl7s.Single().DTCol1 >= pFromDate.Date && tbl5s.Tbl7s.Single().DTCol1 <= pToDate)))
                     select tbl5s.Tbl7s.Single().MCol1).Sum(tbl7 => tbl7.Value);
            }
            catch (Exception ex) { }
            return 0;
        }
        #endregion ClsTbl

        public int MtdBackupDatabase(string pFullName)
        {
            try
            {
                string sCmd = string.Format("Backup Database VNTSellGold TO Disk='{0}'", pFullName);
                return MemLinq.ExecuteCommand(sCmd);
            }
            catch (Exception ex) { throw ex; }
            return -1;
        }

        public DateTime MtdGetDate()
        {
            return MemLinq.ExecuteQuery<DateTime>("SELECT GETDATE()").First();
        }

        public void MtdWriteLog(bool pAppend)
        {
            string sPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\VNTSellGold.log";
            MemLinq.Log = new System.IO.StreamWriter(sPath, pAppend);
        }

        public void MtdCloseLog()
        {
            if (MemLinq.Log != swLog)
            {
                MemLinq.Log.Close();
                MemLinq.Log = swLog;
            }
        }
        #region static
        public static string MtdIntToString(int pI)
        {
            string s = pI.ToString("#,#", Controller.MtdGetCulture());
            if (s == "")
                s = "0";
            return s;
        }

        public static string MtdDecimalToString(decimal pD)
        {
            string s = pD.ToString("#,#", Controller.MtdGetCulture());
            if (s == "")
                s = "0";
            return s;
        }

        /// <summary>
        /// * Get Index of date format.
        /// * Return list of int have 3 element : firt is index of day, next is index of month, finish is index of year.
        /// </summary>
        /// <returns></returns>
        public static List<int> MtdGetIndexDateFormat()
        {
            List<int> lstIndex = new List<int>();
            string[] aDateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.Split('/');
            IOrderedEnumerable<string> iOrderDate = aDateFormat.OrderBy(day => day);
            List<string> lstDateFormat = aDateFormat.AsEnumerable().ToList();
            lstIndex.Add(lstDateFormat.IndexOf(iOrderDate.ElementAt(0)));
            lstIndex.Add(lstDateFormat.IndexOf(iOrderDate.ElementAt(1)));
            lstIndex.Add(lstDateFormat.IndexOf(iOrderDate.ElementAt(2)));
            return lstIndex;
        }

        public static string MtdGetResourceValue(Type pType, string pName)
        {
            ResourceManager rm = new ResourceManager(pType);
            return rm.GetString(pName);
        }

        /// <summary>
        /// * Method for reading a value from a resource file
        /// (.resx file)
        /// </summary>
        /// <param name="file">file to read from</param>
        /// <param name="key">key to get the value for</param>
        /// <returns>a string value</returns>
        public static string MtdGetResourceValue(string pFile, string pName)
        {
            //value for our return value
            string resourceValue = string.Empty;
            try
            {
                // specify your resource file name 
                string resourceFile = pFile;
                // get the path of your file
                string filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                //filePath = filePath.Replace("bin", "obj");
                // create a resource manager for reading from
                //the resx file
                ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager(resourceFile, filePath, null);
                // retrieve the value of the specified key
                resourceValue = resourceManager.GetString(pName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resourceValue = string.Empty;
            }
            return resourceValue;
            //ResXResourceReader r = new ResXResourceReader("FrmTbl3Edit.resx");
            //System.Collections.IDictionaryEnumerator en = r.GetEnumerator();
        }

        public static CultureInfo MtdGetCulture()
        {
            return new CultureInfo(Controller.CulName);
        }
        #endregion static End
        #endregion Methods -----------------------------------------

        #region Dotnet Methods *****************************************
        public Controller()
        {
            memLinq = new LinqDataContext();
            swLog = MemLinq.Log as StreamWriter;
            string sICol3Max = global::VNTSellGold.Properties.Resources.ICol3Max;
            if (!string.IsNullOrEmpty(sICol3Max))
                iCol3Tbl5Max = Convert.ToInt32(sICol3Max);
        }
        #endregion Dotnet Methods -----------------------------------------
    }
}
