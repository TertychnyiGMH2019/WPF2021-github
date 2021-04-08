using System;
using System.IO;

namespace AngryBirds
{
    class Trajectory
    {
        private const double g = 9.8;
        private double[] X;
        private double[] Y;
        private int t;
        public Trajectory(double ang, double v)
        {
            ang = (ang * Math.PI) / 180; 
            double t1 = (2 * v * Math.Sin(ang)) / g;
            int l = (int)Math.Round(t1) * 10;

            t = l;
            X= new double[l];
            Y = new double[l];

            double k;
            for (int i = 0; i < l; i++)
            {
                k = i;
                X[i] = v * Math.Cos(ang) * (k / 10);
                Y[i] = (v * Math.Sin(ang) * (k / 10)) - (g * (k / 10) * (k / 10)) / 2;
                if (Y[i] < 0)
                {
                    Y[i] = 0;
                }
            }


        }

        public void WriteToFile()
        {
            string path = @"..\..\..\Chtoto.csv";
            using (StreamWriter in_File = new StreamWriter(path))
            {

                in_File.Write("t:");
                in_File.Write(';');
                for (int i = 0; i < t; i++)
                {
                    in_File.Write(i);
                    in_File.Write(';');
                }

                in_File.WriteLine(" ");

                in_File.Write("x:");
                in_File.Write(';');
                for (int i = 0; i < t; i++)
                {
                    in_File.Write(Y[i]);
                    in_File.Write(';');
                }

                in_File.WriteLine(" ");

                in_File.Write("y:");
                in_File.Write(';');
                for (int i = 0; i < t; i++)
                {
                    in_File.Write(Y[i]);
                    in_File.Write(';');
                }
            }
        }

        public void WriteCoordinates()
        {
            Console.WriteLine("t:   x:   y:");
            for (int i = 0; i < t; i++)
            {
                Console.WriteLine("{0}:   {1}   {2}", i, X[i], Y[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double ang, v;
            ang = Convert.ToDouble(Console.ReadLine());
            v = Convert.ToDouble(Console.ReadLine());

            if (ang >= 90 || v <= 0)
            {
                Console.WriteLine("Кидайте под углом не больше pi/2, с положительной скоростью");
            }

            Trajectory myPoint = new Trajectory(ang, v);

            myPoint.WriteToFile();

        }
    }
}