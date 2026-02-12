namespace Lab_rab1_1_UsmanovTR_БПИз_23_02
{
    public class Room
    {
        private double _length;
        private double _width;
        private double _height;

        public double Length
        {
            get { return _length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Длина должна быть положительной");
                _length = value;
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Ширина должна быть положительной");
                _width = value;
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Высота должна быть положительной");
                _height = value;
            }
        }

        public Room(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double CalcArea()
        {
            return 2 * (Length + Width) * Height;
        }

        public double CalcAreaWithoutWindowsAndDoors()
        {
            double wallsArea = CalcArea();

            double windowArea = 2.0 * 15.0;
            double doorArea = 2.0 * 8.0;

            double result = wallsArea - windowArea - doorArea;
            if (result > 0) { return result; }
            else { return 0; }
        }
    }
}