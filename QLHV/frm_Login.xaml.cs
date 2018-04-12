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
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace QLHV
{
    using setting = Properties.Settings;
    /// <summary>
    /// Interaction logic for frm_Login.xaml
    /// </summary>
    public partial class frm_Login : Window
    {
        public static string username = "";
        public frm_Login()
        {
            InitializeComponent();
        }
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
                if (cbe_user.Text.Length == 0)
                {
                    tb_goiy.Text = "Xin lỗi! Bạn phải nhập Tên đăng nhập vào";
                }
                else if (pwe_password.Password.Length == 0)
                {
                    tb_goiy.Text = "Xin lỗi! Bạn phải nhập Mật khẩu vào.";
                }
                else if (IsvaildUser(cbe_user.Text,pwe_password.Text))
                {
                    frm_Main main = new frm_Main();
                    main.Show();
                    this.Close();
                }
                else
                {
                    tb_goiy.Text = "Vui lòng nhập đúng Tài khoản và Mật khẩu!";
                }
        }
        private bool IsvaildUser(string userName,string password)
        {
            DataDataContext data = new DataDataContext();
            var q = from p in data.NGUOIDUNGs
                    where p.TAIKHOAN == cbe_user.Text
                    && p.MATKHAU == pwe_password.Text
                    select p;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
