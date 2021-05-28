using System;
using System.Windows;
using System.Windows.Controls;

namespace AngryBirdsNew
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double a;
        double v;
        double m;

        private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(Ang.Text);
            v = Convert.ToDouble(Vel.Text);
            m = Convert.ToDouble(Mass.Text);

            Trajectory Obj = new Trajectory(a, v, m);

            Obj.Output();

        }
    }
    class Trajectory
    {
        double ang, vel, mass;

        public Trajectory(double a, double v, double m)
        {
            ang = (Math.PI * a) / 180;
            vel = v;
            mass = m;
        }

        public void Output()
        {
            double max_y = 0, max_x = 0;

            double v_x = vel * Math.Cos(ang);
            double v_y = vel * Math.Sin(ang);
            double x = 0, y = 0, t = 0.01;

            do
            {
                x = x + (0.01 * v_x);
                y = y + (0.01 * v_y);

                if (y > max_y)
                    max_y = y;

                if (x > max_x)
                    max_x = x;

                if (y < 0)
                    y = 0;

                v_x = VelX(t, v_x, mass, 0.01);
                v_y = VelY(t, v_x, mass, 0.01);

                t += 0.01;
            }
            while (y > 0);

            MessageBox.Show(Convert.ToString(max_x), "Дальность полета");
            MessageBox.Show(Convert.ToString(max_y), "Максимальная высота полета");

        }
     
        private const double g = 9.8;
        public double WindY(double time)
        {
            return 7 * Math.Cos(2.5 * time);
        }
        public double WindX(double time)
        {
            return 9 * Math.Sin(5 * time);
        }
        public double VelY(double time, double vel, double mass, double delta)
        {
            return vel - ((g + (delta * WindY(time) * vel)) / mass);
        }
        public double VelX(double time, double vel, double mass, double delta)
        {
            return vel - (delta * WindX(time) * vel / mass);
        }

    }
}