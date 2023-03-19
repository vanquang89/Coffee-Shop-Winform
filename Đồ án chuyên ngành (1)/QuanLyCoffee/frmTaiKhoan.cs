using QuanLyCoffee.DAO;
using QuanLyCoffee.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCoffee
{
    public partial class frmTaiKhoan : Form
    {


        public string key = "";
       
        BindingSource accountList = new BindingSource();

        BindingSource NhanVienList = new BindingSource();

        BindingSource LuongList = new BindingSource();
        private Account loginAccount;

        public frmTaiKhoan()
        {
            InitializeComponent();
            Load();
        }


        void Load()
        {
            dgvTaiKhoan.DataSource = accountList;
            dgvNV.DataSource = NhanVienList;
            dgvLuong.DataSource = LuongList;
            LoadAccount();
            AddAccountBinding();
            AddNhanVienBinding();
            LoadNhanVien();
            AddLuongBinding();
            LoadLuong();
        }

        void AddAccountBinding()
        {
            
            txtTaiKhoan.DataBindings.Add(new Binding("Text", dgvTaiKhoan.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtTen.DataBindings.Add(new Binding("Text", dgvTaiKhoan.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txtMatkhau.DataBindings.Add(new Binding("Text", dgvTaiKhoan.DataSource, "PassWord", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dgvTaiKhoan.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void AddLuongBinding()
        {
           
            txtChucVu.DataBindings.Add(new Binding("Text", dgvLuong.DataSource, "ChucVu", true, DataSourceUpdateMode.Never));
            txtLCB.DataBindings.Add(new Binding("Text", dgvLuong.DataSource, "LuongCoBan", true, DataSourceUpdateMode.Never));
            txtHSL.DataBindings.Add(new Binding("Text", dgvLuong.DataSource, "HeSoLuong", true, DataSourceUpdateMode.Never));
            txtMaNV1.DataBindings.Add(new Binding("Text", dgvLuong.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txtTenNV1.DataBindings.Add(new Binding("Text", dgvLuong.DataSource, "TenNV", true, DataSourceUpdateMode.Never));


        }

        void LoadLuong()
        {
            LuongList.DataSource = LuongDAO.Instance.getListLuong();
        }


        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void AddNhanVienBinding()
        {
            
            txtMaNV.DataBindings.Add(new Binding("Text", dgvNV.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txtTenNV.DataBindings.Add(new Binding("Text", dgvNV.DataSource, "TenNV", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvNV.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", dgvNV.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            DateTime today = DateTime.Now;
            dateTimePicker1.Value = new DateTime(today.Year, today.Month, today.Day);
            txtCCCD.DataBindings.Add(new Binding("Text", dgvNV.DataSource, "CCCD", true, DataSourceUpdateMode.Never));

        }

        void LoadNhanVien()
        {
            NhanVienList.DataSource = NhanVienDAO.Instance.GetListNhanVien();
        }


      //Account

        void AddAccount(string userName, string displayName, string password,int type)
        {
            try { 
            if (AccountDAO.Instance.InsertAccount(userName, displayName, password ,type))
            {
                
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            }catch(SqlException ex)
            {
                MessageBox.Show("Bạn đã nhập sai thông tin, vui lòng nhập lại");
            }
            Console.Read();


            LoadAccount();
        }


        void EditAccount(string userName, string displayName, string password ,int type)
        {
            try { 
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, password ,type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
            }catch(SqlException ex)
            {
                MessageBox.Show("Bạn đã nhập sai thông tin, vui lòng nhập lại");
            }
        Console.Read();


            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            try
            {
                if (AccountDAO.Instance.DeleteAccount(userName))
                {
                    MessageBox.Show("Xóa tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Bạn đã nhập sai thông tin, vui lòng nhập lại");
            }
            Console.Read();


            LoadAccount();
        }

          private void btnLuu_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            string displayName = txtTen.Text;
            string password = txtMatkhau.Text;
            int type = (int)numericUpDown1.Value;

            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(password);///mk là biến truyền vào
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }

            EditAccount(userName, displayName, str, type);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            string displayName = txtTen.Text;
            string password = txtMatkhau.Text;
            int type = (int)numericUpDown1.Value;

            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(password);///mk là biến truyền vào
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }



            AddAccount(userName, displayName, str ,type);
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;

            DeleteAccount(userName);
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyQuanCafeDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.quanLyQuanCafeDataSet.NhanVien);

        }



        //NhanVien
        void AddNhanVien(string manv, string tennv, string diachi, string sdt,string ngaysinh, string CCCD)
        {
            try
            {

                if (NhanVienDAO.Instance.InsertNhanVien(manv,tennv,diachi,sdt,ngaysinh,CCCD))
            {

                MessageBox.Show("Thêm thông tin nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Thêm thông tin nhân viên thất bại");
            }
            }catch (SqlException ex)
            {
                Console.WriteLine("Loi: {0}", ex.Message);
                MessageBox.Show("Bạn đã nhập sai thông tin, vui lòng nhập lại");
            }
            Console.Read();

            LoadNhanVien();
        }


        void EditNhanVien(string manv, string tennv, string diachi, string sdt,string ngaysinh, string CCCD)
        {

            try
            {

                if (NhanVienDAO.Instance.UpdateNhanVien(manv, tennv, diachi, sdt, ngaysinh,CCCD))
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công");
            }
            else
            {
                
            }
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message );
            }
            Console.Read();


            LoadNhanVien();
        }

        void DeleteNhanVien(string manv)
        {
            try { 
            if (NhanVienDAO.Instance.DeleteNanhVien(manv))
            {
                MessageBox.Show("Xóa thông tin nhân viên thành công");
            }
            else
            {
                    MessageBox.Show("Xóa thông tin nhân viên thất bại");
                }
            }catch(SqlException ex)
            {
                MessageBox.Show("Xóa thông tin nhân viên thất bại");
            }

            LoadNhanVien();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;
            string tennv = txtTenNV.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string ngaysinh = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy/MM/dd");
            string CCCD = txtCCCD.Text;
                
            AddNhanVien(manv, tennv, diachi, sdt, ngaysinh, CCCD);
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;

            DeleteNhanVien(manv);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;
            string tennv = txtTenNV.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string ngaysinh = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy/MM/dd");

            string CCCD = txtCCCD.Text;



            EditNhanVien(manv, tennv, diachi, sdt, ngaysinh, CCCD);
        }

        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        void DeleteLuong(string tennv)
        {

            if (LuongDAO.Instance.DeleteLuong(tennv))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadLuong();
        }

        void InsertLuong(int type, string ChucVu, float lcb, float hsl, string manv, string tennv)
        {



            if (LuongDAO.Instance.InsertLuong(type,ChucVu,lcb,hsl,manv,tennv))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadLuong();
        }

        void UpdateLuong(int type, string ChucVu, float lcb, float hsl, string manv, string tennv)
        {

            if (LuongDAO.Instance.UpdateLuong(type, ChucVu, lcb, hsl, manv, tennv))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadLuong();
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            string tennv = txtTenNV1.Text;
            DeleteLuong(tennv);
        }

        private void btnAddLuong_Click(object sender, EventArgs e)
        {
            Table table = dgvLuong.Tag as Table;

            int type = (int)numericUpDown2.Value;
            string chucvu = txtChucVu.Text;
            float lcb = float.Parse(txtLCB.Text);
            float hsl = float.Parse(txtHSL.Text);


            string manv = LuongDAO.Instance.getListLuong(table.MaNV);
            string tennv = LuongDAO.Instance.getListLuong(table.TenNV);
            if (manv != null)
            {

                LuongDAO.Instance.InsertLuong(LuongDAO.Instance.GetListNhanVien(), manv, tennv);
            }

            if (idBill == -1)
                {
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                }

                ShowBill(table.ID);

                loadTable();
            }

            InsertLuong(type,chucvu,lcb,hsl,manv, tennv);


           
        }



        private void btnSuaLuong_Click(object sender, EventArgs e)
        {
            int type = (int)numericUpDown2.Value;
            string chucvu = txtChucVu.Text;
            float lcb = float.Parse(txtLCB.Text);
            float hsl = float.Parse(txtHSL.Text);
            string manv = txtMaNV1.Text;
            string tennv = txtTenNV1.Text;



            UpdateLuong(type, chucvu, lcb, hsl, manv, tennv);
        }
    }
}
