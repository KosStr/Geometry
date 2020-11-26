namespace Graphics2
{
    public class Planet
    {
        public double Radius { get;  set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Speed { get; set; }
        public double DistanceToSun { get; set; }

        public Planet() {}

        public Planet(int _radius, int _coordinateX, int _coordinateY, int _speed, int _distanceToSun)
        {
            Radius = _radius;
            X = _coordinateX;
            Y = _coordinateY;
            Speed = _speed;
            DistanceToSun = _distanceToSun;
        }
    }
}
