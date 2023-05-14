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
using System.Windows.Navigation;
using System.Windows.Shapes;
using popytka4.AplpicationData;
using popytka4.Pages;

namespace popytka4.Pages
{
    /// <summary>
    /// Логика взаимодействия для Avtorization.xaml
    /// </summary>
    public partial class Avtorization : Page
    {
        public Avtorization()
        {
            InitializeComponent();
        }

        private void ButtonAvtorization_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text != "" || PasswordBoxLogin.Password != "") 
            {
                if (TextBoxLogin.Text == "")
                {
                    MessageBox.Show("Запольните поле логина", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (PasswordBoxLogin.Password == "")
                {
                    MessageBox.Show("Запольните поле логина", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                try
                {
                    var Userobj = bd_flowersEntities.GetContext().User.FirstOrDefault(p => p.UserLogin == TextBoxLogin.Text && p.UserPassword == PasswordBoxLogin.Password);
                    HelpClass.id = Userobj.UserID;
                    HelpClass.FIO = Userobj.UserSurname + " "+ Userobj.UserName + " " + Userobj.UserPatronymic;
                    switch (Userobj.UserRole)
                    {
                        case 1:
                            MessageBox.Show($"Здраствуйте администратор {HelpClass.FIO}","Уведомления",MessageBoxButton.OK,MessageBoxImage.Information);
                            AppFrame.frameClass.Navigate(new AdminPage());
                            break;
                        case 2:
                            MessageBox.Show($"Здраствуйте {HelpClass.FIO}", "Уведомления", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frameClass.Navigate(new UserPage());
                            break;
                        case 3:
                            MessageBox.Show($"Здраствуйте мененджер {HelpClass.FIO}", "Уведомления", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frameClass.Navigate(new UserPage());
                            break;
                        default:
                            MessageBox.Show("Такого пользователя нету","Внимание",MessageBoxButton.OK,MessageBoxImage.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("aaa ");

                }
            }
            else
            {
                MessageBox.Show("Запоните поля авторизации","Внимания",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
