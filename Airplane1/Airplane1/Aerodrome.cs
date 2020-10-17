using System;
using System.Drawing;

namespace Airplane1
{
    public class Aerodrome<T> where T : class, ITransport
    {
        private readonly T[] _places;
        private readonly int pictureWidth;
        private readonly int pictureHeight;
        private readonly int _placeSizeWidth = 170;
        private readonly int _placeSizeHeight = 100;
        private readonly int size;

        public Aerodrome(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _places = new T[width * height];
            size = width * height;
            pictureWidth = picWidth;
            pictureHeight = picHeight;
        }

        public static bool operator +(Aerodrome<T> p, T airplane)
        {
            for (int i = 0; i < p._places.Length; i++)
            {
                if (p.CheckPlace(i))
                {
                    int width = p.pictureWidth / p._placeSizeWidth;
                    p._places[i] = airplane;
                    int shift = 10;
                    p._places[i].SetPosition(i / width * p._placeSizeWidth,
                                 i % width * p._placeSizeHeight + shift, p.pictureWidth,
                                p.pictureHeight);
                    return true;
                }
            }
            return false;
        }

        public static T operator -(Aerodrome<T> p, int index)
        {
            // Прописать логику для вычитания
            if (index < 0 || index > p._places.Length)
            {
                return null;
            }
            if (!p.CheckPlace(index))
            {
                Random rnd = new Random();
                T airplane = p._places[index];
                airplane.SetPosition(rnd.Next(30, 100), rnd.Next(30, 100), p.pictureWidth,
           p.pictureHeight);

                p._places[index] = null;
                return airplane;
            }
            return null;
        }

        private bool CheckPlace(int placeIndex)
        {
            return _places[placeIndex] == null;
        }

        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i]?.DrawTransport(g);
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