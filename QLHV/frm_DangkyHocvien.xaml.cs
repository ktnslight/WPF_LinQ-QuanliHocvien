using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLHV
{
    /// <summary>
    /// Interaction logic for frm_DangkyHocvien.xaml
    /// </summary>
    public partial class frm_DangkyHocvien : Window
    {
        string gioitinh;
        public frm_DangkyHocvien()
        {
            InitializeComponent();
        }
        private void ch_nam_Checked(object sender, RoutedEventArgs e)
        {
            ch_nu.IsChecked = false;
            gioitinh = "true";
        }

        private void ch_nu_Checked(object sender, RoutedEventArgs e)
        {
            ch_nam.IsChecked = false;
            gioitinh = "false";
        }
        DataDataContext data = new DataDataContext();
        private void btn_dangki_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_taomoi_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (txt_username.Text == "" || pwe_password.Password == "" || pwe_confirmpass.Password == "")
            {
                tb_thongbao.Text = "Vui lòng nhập đầy đủ thông tin tài khoản!";
                return;
            }
            try
            {
                var account = data.NGUOIDUNGs.Where(u => u.TAIKHOAN == txt_username.Text.Trim()).SingleOrDefault<NGUOIDUNG>();
                if (account != null)
                {
                    tb_thongbao.Text = "Tên Tài khoản đã tồn tại.";
                    return;
                }
                if(pwe_password.Password != pwe_confirmpass.Password)
                {
                    tb_thongbao.Text = "Mật khẩu không khớp!";
                    return;
                }
                if(data.NGUOIDUNGs)
            }
            catch
            {

            }
        }
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            txt_username.Text = "";
            pwe_password.Text = "";
            pwe_confirmpass.Text = "";
        }
        private void AddNew()
        {
            HOCVIEN hv = new HOCVIEN();
            hv.ID_HV = txt_id.Text;
            hv.HOTEN = txt_ten.Text;
            hv.NGAYSINH = DateTime.Parse(d_ngaysinh.ToString());
            hv.DIACHI = txt_diachi.Text;
            hv.EMAIL = txt_email.Text;
            hv.NGAYDANGKY = DateTime.Parse(d_ngaydangky.ToString());
            hv.SDT = txt_phone.Text;
            hv.NGHENGHIEP = txt_nghenghiep.Text;
            hv.TAIKHOAN = txt_username.Text;
            hv.GIOITINH = bool.Parse(gioitinh);
        }
        private void AddUser()
        {
            NGUOIDUNG acc = new NGUOIDUNG();
            acc.TAIKHOAN = txt_username.Text;
            acc.MATKHAU = pwe_password.Text;
            acc.ID_LOAI = "SV";
        }
        private void Refresh()
        {
            //Thong tin hoc vien
            txt_id.Text = "";
            txt_ten.Text = "";
            txt_diachi.Text = "";
            txt_email.Text = "";
            txt_nghenghiep.Text = "";
            txt_phone.Text = "";
            d_ngaysinh.Text = "";
            ch_nam.IsChecked = false;
            ch_nu.IsChecked = false;
            //Thong tin khoa hoc
            cbe_khoahoc.Text = "";
            cbe_lop.Text = "";
            tb_ngaybd.Text = "";
            tb_ngaykt.Text = "";
            //Thong tin tai khoan
            txt_username.Text = "";
            pwe_password.Text = "";
            pwe_confirmpass.Text = "";
        }
        private void GetAccountData()
        {
            DataDataContext data = new DataDataContext();
            var hocvien = from username in data.GetTable<NGUOIDUNG>() select username.TAIKHOAN;
        }
        private void CheckAccount()
        {

        }
    }
}