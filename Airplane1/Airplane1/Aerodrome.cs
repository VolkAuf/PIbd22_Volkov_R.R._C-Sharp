using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Airplane1
{
    public class Aerodrome<T> : IEnumerator<T>, IEnumerable<T>
        where T : class, ITransport
    {
        /// <summary>
        /// Список объектов, которые храним
        /// </summary>
        private readonly List<T> _places;
        /// <summary>
        /// Максимальное количество мест на аэродроме
        /// </summary>
        private readonly int _maxCount;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private readonly int _placeSizeWidth = 170;
        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private readonly int _placeSizeHeight = 100;
        /// <summary>
        /// Текущий элемент для вывода через IEnumerator 
        /// (будет обращаться по своему индексу к ключу словаря, по которму будет возвращаться запись)
        /// </summary>
        private int _currentIndex;

        public T Current => _places[_currentIndex];
        object IEnumerator.Current => _places[_currentIndex];
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Рамзер аэродрома - ширина</param>
        /// <param name="picHeight">Рамзер аэродрома - высота</param>
        public Aerodrome(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxCount = width * height;
            pictureWidth = picWidth;
            pictureHeight = picHeight;
            _places = new List<T>();
            _currentIndex = -1;
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на аэродром добавляется самолёт
        /// </summary>
        /// <param name="a">аэродром</param>
        /// <param name="airplane">Добавляемый самолёт</param>
        /// <returns></returns>
        public static bool operator +(Aerodrome<T> a, T airplane)
        {
            if (a._places.Count >= a._maxCount)
            {
                throw new AerodromeOverflowException();
            }
            if (a._places.Contains(airplane))
            {
                throw new AerodromeAlreadyHaveException();
            }
            a._places.Add(airplane);
            return true;
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с аэродрома забираем самолёт
        /// </summary>
        /// <param name="a">Аэродром</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь объект</param>
        /// <returns></returns>
        public static T operator -(Aerodrome<T> a, int index)
        {
            if (index < 0 || index >= a._places.Count)
            {
                throw new AerodromeNotFoundException(index);
            }
            T airplane = a._places[index];
            a._places.RemoveAt(index);
            return airplane;
        }

        /// <summary>
        /// Функция получения элементы из списка
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetNext(int index)
        {
            if (index < 0 || index >= _places.Count)
            {
                return null;
            }
            return _places[index];
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

        /// <summary>
        /// Сортировка самолётов на аэродроме
        /// </summary>
        public void Sort()
        {
            _places.Sort((IComparer<T>)new AirplaneComparer());
        }

        /// <summary>
        /// Метод интерфейса IEnumerator, вызываемый при удалении объекта
        /// </summary>
        public void Dispose()
        {
        }
        /// <summary>
        /// Метод интерфейса IEnumerator для перехода к следующему элементу или началу коллекции
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            // Реализовать логику
            if (_currentIndex < _places.Count - 1)
            {
                _currentIndex++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для сброса и возврата к началу коллекции
        /// </summary>
        public void Reset()
        {
            _currentIndex = -1;
        }
        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}