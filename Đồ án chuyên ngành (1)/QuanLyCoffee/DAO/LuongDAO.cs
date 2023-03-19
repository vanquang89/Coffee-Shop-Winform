using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCoffee.DAO
{
    class LuongDAO
    {
        private static LuongDAO instance;

        public static LuongDAO Instance
        {
            get { if (instance == null) instance = new LuongDAO(); return instance; }
            private set { instance = value; }
        }


        public DataTable getListLuong()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Luong");

        }

        public bool InsertLuong(int type, string ChucVu, float lcb, float hsl, string manv, string tennv )
        {
            string query = string.Format("INSERT dbo.Luong ( Type , ChucVu,  LuongCoBan, HeSoLuong, MaNV,TenNV )VALUES  ( {0}, N'{1}', {2} ,{3} ,N'{4}', N'{5}')", type, ChucVu, lcb, hsl,manv,tennv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateLuong(int type, string ChucVu, float lcb, float hsl, string manv, string tennv)
        {
            string query = string.Format("UPDATE dbo.Luong SET Type = {0} ,ChucVu = N'{1}', LuongCoBan = {2} , HeSoLuong  = {3} , MaNV = N'{4}' WHERE TenNV = N'{5}'", type,ChucVu, lcb, hsl, manv, tennv );
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public void InsertLuong(string manv, string tennv)
        {
            DataProvider.Instance.ExecuteNonQuery(" dbo.USP_InsertNhanVien @MaNV , @TenNV", new object[] { manv, tennv });
        }



        public bool DeleteLuong(string tennv)
        {
            string query = string.Format("Delete Luong where TenNV = '{0}'", tennv);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
