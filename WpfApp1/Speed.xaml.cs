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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Speed.xaml 的交互逻辑
    /// </summary>
    public partial class Speed : Window
    {
        public Speed()
        {
            InitializeComponent();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            Tools tools = new Tools();
            tools.Show();
            this.Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            RotateTransform rotateTransform = new RotateTransform();
            this.Click.RenderTransform = rotateTransform;
            storyboard.RepeatBehavior = RepeatBehavior.Forever;
            storyboard.SpeedRatio = 3;
            doubleAnimation.From = 0;
            doubleAnimation.To = 360;
            doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 10));
            Storyboard.SetTarget(doubleAnimation, this.Click);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("RenderTransform.Angle"));
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin(this.Click);
        }
    }
}
