using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace Animator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Generated with Avalonia.NameGenerator
            InitializeComponent();
        }

        public void button1_Click(object sender, RoutedEventArgs e)
        {
            // Change button text when button is clicked.
            var button = (Button)sender;
            Console.WriteLine("Button 1 Clicked!");
        }
        
        public void button2_Click(object sender, RoutedEventArgs e)
        {
            // Change button text when button is clicked.
            var button = (Button)sender;
            Console.WriteLine("Button 2 Clicked!");
        }
    }
}