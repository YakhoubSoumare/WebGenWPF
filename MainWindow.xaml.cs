using System;
using System.Collections.Generic;
using System.IO;
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

namespace WebGen
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

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.html)|*.html"; // Filter files by ex
                                                        // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                myTextBox.Text = File.ReadAllText(filename);
            }

            //myTextBox.Text = File.ReadAllText();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg2 = new Microsoft.Win32.SaveFileDialog();
            dlg2.FileName = "Index";
            dlg2.DefaultExt = ".html";
            dlg2.Filter = "Text documents (.html)|*.html";

            Nullable<bool> result = dlg2.ShowDialog();
            if(result == true)
            {
                string fileName = dlg2.FileName;
                File.WriteAllText(fileName, myTextBox.Text);
                myTextBox.Clear();
            }
        }

        private void managerButton_Click(object sender, RoutedEventArgs e)
        {
            string klass = classText.Text;
            string[] messages = messTextBox.Text.Split('\n');
            string [] Technologies = techTextBox.Text.Split('\n');
            string colour = "";

            //if(RadioButton.CheckedEvent == whiteRadio

        }
    }
}
