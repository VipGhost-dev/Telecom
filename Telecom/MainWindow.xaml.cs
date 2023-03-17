using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;
using Telecom.Classes;

namespace Telecom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string code; // Сгенерированный код
        int countTime; // Время до окончания действия кода
        DispatcherTimer disTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            ClassBase.BASE = new Entities();
            PasswordB.IsEnabled = false;
            CodeBox.IsEnabled = false;
            LoginBTN.IsEnabled = false;
            disTimer.Interval = new TimeSpan(0, 0, 1);
            disTimer.Tick += new EventHandler(DisTimer_Tick);
        }

        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            PhoneBox.Text = "";
            PasswordB.Password = "";
            CodeBox.Text = "";
            disTimer.Stop();
            code = "";
            RemainingTimeBox.Text = "";
            PasswordB.IsEnabled = false;
            CodeBox.IsEnabled = false;
            LoginBTN.IsEnabled = false;
        }

        private void PhoneBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Если нажата клавиша Enter
            {
                Employees employee = ClassBase.BASE.Employees.FirstOrDefault(x => x.Phone == PhoneBox.Text); // Сотрудник по номеру
                if (employee != null)
                {
                    PasswordB.IsEnabled = true;
                    PasswordB.Focus();
                }
                else
                {
                    PasswordB.IsEnabled = false;
                    PasswordB.Password = "";
                    MessageBox.Show("Произошла ошибка! Сотрудник  с таким номером не найден!");
                }
            }
        }

        private void PasswordB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                GetNewCode();
            }
        }
        private void DisTimer_Tick(object sender, EventArgs e)
        {
            if (countTime == 0) // Если 10 секунд закончились
            {
                disTimer.Stop();
                code = "";
                RemainingTimeBox.Text = "Код не действителен. Запросите повторную отправку кода";

            }
            else
            {
                RemainingTimeBox.Text = "Код перестанет быть действительным через " + countTime;
            }
            countTime--;
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void CodeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }
        /// <summary>
        /// Метод для автормазции, проверяет введённые данные
        /// </summary>
        private void Login()
        {
            if (code != "")
            {
                if (CodeBox.Text == code)
                {
                    disTimer.Stop();
                    RemainingTimeBox.Text = "";
                    code = "";
                    Employees employee = ClassBase.BASE.Employees.FirstOrDefault(x => x.Phone == PhoneBox.Text && x.Password == PasswordB.Password);
                    if (employee != null)
                    {
                        MessageBox.Show("Вы успешно авторизовались с ролью " + employee.Roles.Role);
                    }
                    else
                    {
                        MessageBox.Show("Сотрудник с таким номером и паролем не найден!");
                    }
                }
                else
                {
                    MessageBox.Show("Код введён не верно!");
                }
            }
            else
            {
                MessageBox.Show("Код утратил свою действительность!");
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetNewCode();
        }

        /// <summary>
        /// Метод для генерации нового кода, согласно заданным критериям
        /// </summary>
        private void GetNewCode()
        {
            Employees employee = ClassBase.BASE.Employees.FirstOrDefault(x => x.Phone == PhoneBox.Text && x.Password == PasswordB.Password); // Получение сотрудника по номеру и паролю
            if (employee != null)
            {
                Random rand = new Random();
                Regex regex = new Regex($"^[0-9a-zA-Z`~!@#$%^&*()_\\-+={{}}\\[\\]\\|:;\"'<>,.?\\/]{{8}}$"); // Регулярное выражение для проверки корректности сгенерированого кода
                while (true)
                {
                    code = "";
                    for (int i = 0; i < 8; i++)
                    {
                        int j = rand.Next(4); // Выбор 0 - число; 1, 2 - буква; 2 - спецсимвол
                        if (j == 0)
                        {
                            code = code + rand.Next(9).ToString();
                        }
                        else if (j == 1 || j == 2)
                        {
                            int l = rand.Next(2); // Выбор 0 - заглавная; 1 - маленькая буква
                            if (l == 0)
                            {
                                code = code + (char)rand.Next('A', 'Z' + 1);
                            }
                            else
                            {
                                code = code + (char)rand.Next('a', 'z' + 1);
                            }
                        }
                        else
                        {
                            int l = rand.Next(4); // Выбор диапозона
                            if (l == 0)
                            {
                                code = code + (char)rand.Next(33, 48);
                            }
                            else if (l == 1)
                            {
                                code = code + (char)rand.Next(58, 65);
                            }
                            else if (l == 2)
                            {
                                code = code + (char)rand.Next(91, 97);
                            }
                            else if (l == 3)
                            {
                                code = code + (char)rand.Next(123, 127);
                            }
                        }
                    }

                    if (regex.IsMatch(code))
                    {
                        break;
                    }
                }
                MessageBox.Show("Код для доступа " + code + "\nУ вас будет дано 10 секунд, чтобы ввести код");
                CodeBox.IsEnabled = true;
                CodeBox.Text = "";
                LoginBTN.IsEnabled = true;
                CodeBox.Focus();
                countTime = 10;
                disTimer.Start();
            }
            else
            {
                MessageBox.Show("Сотрудник с таким номером и паролем не найден!");
                disTimer.Stop();
                code = "";
                RemainingTimeBox.Text = "";
                CodeBox.IsEnabled = false;
                CodeBox.Text = "";
            }
        }
    }
}

