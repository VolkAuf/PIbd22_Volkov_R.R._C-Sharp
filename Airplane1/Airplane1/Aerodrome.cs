using System.Collections.Generic;
using System.Drawing;

namespace Airplane1
{
    public class Aerodrome<T> where T : class, ITransport
    {
        private readonly List<T> _places;
        private readonly int pictureWidth;
        private readonly int pictureHeight;
        private readonly int _placeSizeWidth = 170;
        private readonly int _placeSizeHeight = 100;
        private readonly int size;

        public Aerodrome(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _places = new List<T>();
            size = width * height;
            pictureWidth = picWidth;
            pictureHeight = picHeight;
        }

        public static bool operator +(Aerodrome<T> a, T airplane)
        {
            if (a._places.Count >= a.size)
            {
                return false;
            }
            a._places.Add(airplane);
            return true;
        }

        public static T operator -(Aerodrome<T> p, int index)
        {
            // Прописать логику для вычитания
            if (index < -1 || index >= p._places.Count)
            {
                return null;
            }
            T airtransport = p._places[index];
            p._places.RemoveAt(index);
            return airtransport;
        }

        private bool CheckPlace(int placeIndex)
        {
            return _places[placeIndex] == null;
        }

        public void Draw(Graphics g)
        {
            int marginY = 10;
            DrawMarking(g);
            for (int i = 0; i < _places.Count; ++i) 
            {
                _places[i].SetPosition(i / 4 * _placeSizeWidth, i % 4 * _placeSizeHeight + marginY, pictureWidth, pictureHeight);
                _places[i].DrawTransport(g);
            }
        }

        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);

            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {//линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i * _placeSizeWidth + _placeSizeWidth / 2, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }
    }
}