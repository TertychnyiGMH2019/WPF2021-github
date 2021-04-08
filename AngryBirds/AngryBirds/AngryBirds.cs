using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;


namespace AngryBirds
{
    class Trajectory
    {
            public double X, Y, MomentSpeed; // MomentSpeed = v(t) = скорость в момент t
            public readonly double TimeStep;
            private readonly double _angle, _speed;
            private const double G = 9.8;
        public Trajectory (double timeStep, double x = 0, double y = 0, double speed = 0, double angle = 0)
        {
            X = x;
            Y = y;
            _speed = speed;
            _angle = ConvertToRadians(angle);  // Будем использовать sin и cos
            TimeStep = timeStep;
        }
        private static double Square(double value) { return value * value; } //считаем квадрат введенного числа
        private static double ConvertToRadians(double a) { return a * Math.PI / 180; } //переводим радианы
        public double GetFlyTime() { return 2 * _speed * Math.Sin(_angle) / G; } //функция для подсчета время полета
        //вводим функции счета кооординат x, y
        private double CalculateX(double time) { return _speed * Math.Cos(_angle) * time; }
        private double CalculateY(double time) { return _speed * Math.Sin(_angle) * time - (G * Square(time) / 2); }
        private double CalculateSpeed(double time) //считаем скорость от времени
        {
            double speedX = _speed * Math.Cos(_angle),
                   speedY = _speed * Math.Sin(_angle);
            return Math.Sqrt((speedY - G * time) * (speedY - G * time) + GetSquare(speedX));
        }
    }

}