using System;
using System.IO.Ports;
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
namespace Dekstep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        string url = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                SerialPort port = new SerialPort();
                port.BaudRate = 9600;
                port.PortName = "COM5";
                port.Open();

                try
                {
                    while (true)
                    {
                        string oneLine = port.ReadLine();
                        //Console.WriteLine(oneLine);
                        System.Threading.Thread.Sleep(500);
                        if (oneLine == "whatever the arduino output is supposed to be")
                        {
                            if (RadioButtonCloseProgram.IsChecked == true)
                            {
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                startInfo.FileName = "cmd.exe";
                                startInfo.Arguments = "Taskkill /F /IM Chrome.exe"; //add whatever command shell you want here
                                process.StartInfo = startInfo;
                                process.Start();
                            }
                            if (RadioButtonNewDesktop.IsChecked == true)
                            {
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                startInfo.FileName = "cmd.exe";
                                startInfo.Arguments = "echo hello"; //add whatever command shell you want here
                                //keystroke command thingy doesnt work :(
          
                                process.StartInfo = startInfo;
                                process.Start();
                            }
                            if (NewTab.IsChecked == true)
                            {
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                startInfo.FileName = "cmd.exe";
                                if (url == null)
                                {
                                    startInfo.Arguments = "explorer https://google.com";
                                }
                                else 
                                {
                                    startInfo.Arguments = "explorer " + url;
                                } //add whatever command shell you want here
                                                                       //keystroke command thingy doesnt work :(

                                process.StartInfo = startInfo;
                                process.Start();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Encountered error while reading serial port");
                    Console.WriteLine(ex.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Encountered error while opening serial port");
                Console.WriteLine(ex.ToString());
            }
            
        }

   
        private void Url_TextChanged(object sender, TextChangedEventArgs e)
        {
            url = Url.Text;
        }
    }
}
