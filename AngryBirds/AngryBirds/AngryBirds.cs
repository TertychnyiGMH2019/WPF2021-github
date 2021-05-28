using System;
using System.IO;
namespace AngryBirds
{
    class Trajectory
    {
        double ang, vel, mass;

        public Trajectory(double a, double v, double m)
        {
            ang = (Math.PI * a) / 180;
            vel = v;
            mass = m;
        }
        public void WriteToConsole()
        {
            double v_x = vel * Math.Cos(ang);
            double v_y = vel * Math.Sin(ang);
            double x = 0, y = 0, t = 0.01;

            Console.WriteLine("{0},   |||   {1}", x, y);

            do
            {
                x = x + (0.01 * v_x);
                y = y + (0.01 * v_y);

                if (y < 0)
                    y = 0;

                v_x = VelX(t, v_x, mass, 0.01);
                v_y = VelY(t, v_x, mass, 0.01);

                Console.WriteLine("{0},   |||   {1}", x, y);

                t += 0.01;
            }
            while (y > 0);
        }

        public void WriteToFile(string path = @"..\..\Chtoto.csv")
        {


            using (StreamWriter in_File = new StreamWriter(path))
            {
                in_File.WriteLine("angle= {0}; velocity= {1}; mass= {2}", (ang * 180 / Math.PI), vel, mass);
                in_File.WriteLine("       t;       x;       y;");

                double v_x = vel * Math.Cos(ang);
                double v_y = vel * Math.Sin(ang);
                double x = 0, y = 0, t = 0.01;

                in_File.WriteLine("0; {0};  {1}", x, y);

                do
                {
                    x = x + (0.01 * v_x);
                    y = y + (0.01 * v_y);

                    if (y < 0)
                        y = 0;

                    v_x = VelX(t, v_x, mass, 0.01);
                    v_y = VelY(t, v_x, mass, 0.01);

                    in_File.WriteLine("{0}; {1}; {2}", t, x, y);

                    t += 0.01;
                }
                while (y > 0);
            }

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

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine(args[i]);
            double angle, vel, mass;
            angle = Convert.ToDouble(Console.ReadLine());
            vel = Convert.ToDouble(Console.ReadLine());
            mass = Convert.ToDouble(Console.ReadLine());


            if (angle >= 90 || vel <= 0 || mass <= 0)
            {
                Console.WriteLine("Ошибка ввода данных, координаты полёта тела будут найденны неверно");
            }

            Trajectory Obj = new Trajectory(angle, vel, mass);
            if (args.Length == 0)
                Obj.WriteToFile();
            else
                Obj.WriteToFile(args[0]);
            Obj.WriteToConsole();

        }
    }
}