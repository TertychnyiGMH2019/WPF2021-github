using System;
using System.Windows;
using System.Windows.Controls;


namespace AngryBirds
{
    class Trajectory
    {
            public double X, Y, MomentSpeed;                  // MomentSpeed = v(t) == скорость в момент t
            public readonly double TimeStep;
            private readonly double _angle, _speed;
            private const double G = 9.81;
    }
}
