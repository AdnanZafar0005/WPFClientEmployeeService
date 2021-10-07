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

namespace WPFClientEmployeeService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetEmployee_Click(object sender, RoutedEventArgs e)
        {

            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
            if (txtBoxId.Text.ToString() != "")
            {
                EmployeeService.Employee employee = client.GetEmployee(Convert.ToInt32(txtBoxId.Text));

                if (employee == null)
                {
                    //  lblMessage.Foreground = Color;

                    txtBlockMessage.Foreground = Brushes.Red;

                    txtBoxName.Text = txtBoxId.Text = txtBoxDOB.Text = txtBoxGender.Text = "";

                    txtBlockMessage.Text = "Employee does not found.".ToString();
                    return;
                }


                txtBoxName.Text = employee.Name;

                txtBoxGender.Text = employee.Gender;
                txtBoxDOB.Text = employee.DateOfBirth.ToShortDateString();
                // lblMessage.ForeColor = Color.Green;
                txtBlockMessage.Foreground = Brushes.Green;

                txtBlockMessage.Text = "Employee retrieved";
            }
            else
            {
                // txtBlockMessage.Foreground = Color.Add(C);
                txtBlockMessage.Foreground = Brushes.Red;

                txtBlockMessage.Text = "Invalid Id. Please enter correct id.";
            }
        }

        private void btnsaveEmployee_Click(object sender, RoutedEventArgs e)
        {

            EmployeeService.Employee employee = new EmployeeService.Employee();



            if (txtBoxId.Text != "" && txtBoxName.Text != "" && txtBoxDOB.Text != "" && txtBoxGender.Text != "")
            {

                employee.Id = Convert.ToInt32(txtBoxId.Text);
                employee.Name = txtBoxName.Text;
                employee.Gender = txtBoxGender.Text;
                employee.DateOfBirth = Convert.ToDateTime(txtBoxDOB.Text);
                EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient();
                client.SaveEmployee(employee);
                /// TxtBlockMessage.ForeColor = Color.Green;
               txtBlockMessage.Foreground = Brushes.Green;

                txtBlockMessage.Text = "Employee saved";

            }
            else
            {
                //txtBlockMessage.ForeColor = Color.Red;
                txtBlockMessage.Foreground = Brushes.Red;
                txtBlockMessage.Text = "Please check your all fields are corect.";

            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtBoxDOB.Text = txtBoxId.Text = txtBoxName.Text = txtBoxGender.Text = txtBlockMessage.Text = "";

        }

        private void ComboBoxItem_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
