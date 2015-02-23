using System;
using System.IO;
using System.Windows;

namespace HostsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// hold hosts file path
        /// </summary>
        private string hostsFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // get hosts file path
            hostsFilePath = Path.Combine(Environment.SystemDirectory, "drivers\\etc\\hosts");

            // read all content into textbox
            txtEditor.Text = File.ReadAllText(hostsFilePath);

            // put cursor to the end
            txtEditor.Focus();
            txtEditor.CaretIndex = txtEditor.Text.Length - 1;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // close app
            Application.Current.Shutdown();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // write it out
                File.WriteAllText(hostsFilePath, txtEditor.Text);

                // message
                MessageBox.Show("File updated.");
            }
            catch (Exception ex)
            {
                // failed
                MessageBox.Show(ex.Message, "Update hosts file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
