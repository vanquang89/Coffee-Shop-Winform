using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCoffee.DTO
{
    class Luong
    {
        public Luong(int type, string chucvu, float luongcoban, float hsl, string manv)
        {
            this.Type = type;
            this.ChucVu = chucvu;
            this.LuongCoBan = luongcoban;
            this.HeSoLuong = hsl;
            this.MaNV = manv;
        }

        public Luong(DataRow row)
        {
            this.Type = (int)Convert.ToInt32(row["hsl"].ToString());
            this.ChucVu = row["chucvu"].ToString();
            this.LuongCoBan = (float)Convert.ToDouble(row["luongcoban"].ToString());
            this.HeSoLuong = (float)Convert.ToDouble(row["hsl"].ToString());
            this.MaNV = row["manv"].ToString();
        }

        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private string chucvu;
        public string ChucVu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }

        private float luongcoban;

        public float LuongCoBan
        {
            get { return luongcoban; }
            set { luongcoban = value; }
        }

        private float hsl;

        public float HeSoLuong
        {
            get { return hsl; }
            set { hsl = value; }
        }

        private string manv;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }


    }
}
