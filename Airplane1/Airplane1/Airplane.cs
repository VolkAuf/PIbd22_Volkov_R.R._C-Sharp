using System;
using System.Drawing;

namespace Airplane1
{
    public class Airplane : AirTransport, IEquatable<Airplane>
    {
        protected readonly int airplaneWidth = 130;
        protected readonly int airplaneHeight = 90;
        protected readonly char separator = ';';

        public Airplane(int maxSpeed, float weigth, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weigth;
            MainColor = mainColor;
        }

        protected Airplane(int maxSpeed, float weigth, Color mainColor, int airplaneWidth, int airplaneHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weigth;
            MainColor = mainColor;
            this.airplaneWidth = airplaneWidth;
            this.airplaneHeight = airplaneHeight;
        }

        public Airplane(string info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - airplaneWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    else
                    {
                        _startPosX = 0;
                    }
                    break;
                case Direction.Up:
                    if (_startPosY - step > 0
                        )
                    {
                        _startPosY -= step;
                    }
                    else
                    {
                        _startPosY = 0;
                    }
                    break;
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - airplaneHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
        }

        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush korpus = new SolidBrush(MainColor);
            Brush dno = new SolidBrush(Color.White);
            Brush steclo = new SolidBrush(Color.Black);

            Point[] pointKorpus =
            {
            new Point((int)(_startPosX+airplaneWidth*0.15),(int)( _startPosY+airplaneHeight*0.47)),
            new Point((int)(_startPosX+airplaneWidth*0.2),(int)( _startPosY+airplaneHeight*0.63)),
            new Point((int)(_startPosX+airplaneWidth*0.9),(int)( _startPosY+airplaneHeight*0.63)),
            new Point((int)(_startPosX+airplaneWidth*0.8),(int)( _startPosY+airplaneHeight*0.47))
            };
            g.FillPolygon(korpus, pointKorpus);// Korpus

            //Door
            g.DrawLine(pen, (int)(_startPosX + airplaneWidth * 0.78), (int)(_startPosY + airplaneHeight * 0.63), (int)(_startPosX + airplaneWidth * 0.78), (int)(_startPosY + airplaneHeight * 0.5));
            g.DrawLine(pen, (int)(_startPosX + airplaneWidth * 0.78), (int)(_startPosY + airplaneHeight * 0.5), (int)(_startPosX + airplaneWidth * 0.81), (int)(_startPosY + airplaneHeight * 0.5));
            g.DrawLine(pen, (int)(_startPosX + airplaneWidth * 0.81), (int)(_startPosY + airplaneHeight * 0.5), (int)(_startPosX + airplaneWidth * 0.81), (int)(_startPosY + airplaneHeight * 0.63));

            Point[] pointDno =
            {
            new Point((int)(_startPosX+airplaneWidth*0.20),(int)( _startPosY+airplaneHeight*0.63)),
            new Point((int)(_startPosX+airplaneWidth*0.25),(int)( _startPosY+airplaneHeight*0.70)),
            new Point((int)(_startPosX+airplaneWidth*0.9),(int)( _startPosY+airplaneHeight*0.70)),
            new Point((int)(_startPosX+airplaneWidth),(int)( _startPosY+airplaneHeight*0.63))
            };
            g.FillPolygon(dno, pointDno);// Dno

            Point[] pointRightWing =
            {
            new Point((int)(_startPosX+airplaneWidth*0.55),(int)( _startPosY+airplaneHeight*0.50)),
            new Point((int)(_startPosX+airplaneWidth*0.4),(int)( _startPosY+airplaneHeight*0.05)),
            new Point((int)(_startPosX+airplaneWidth*0.5),(int)( _startPosY+airplaneHeight*0.05)),
            new Point((int)(_startPosX+airplaneWidth*0.7),(int)( _startPosY+airplaneHeight*0.50))
            };
            g.FillPolygon(korpus, pointRightWing);// Krilo

            Point[] pointLeftWing =
            {
            new Point((int)(_startPosX+airplaneWidth*0.55),(int)( _startPosY+airplaneHeight*0.6)),
            new Point((int)(_startPosX+airplaneWidth*0.4),(int)( _startPosY+airplaneHeight-10)),
            new Point((int)(_startPosX+airplaneWidth*0.5),(int)( _startPosY+airplaneHeight-10)),
            new Point((int)(_startPosX+airplaneWidth*0.7),(int)( _startPosY+airplaneHeight*0.6))
            };
            g.FillPolygon(korpus, pointLeftWing);// Krilo

            Point[] pointBamper =
            {
            new Point((int)(_startPosX+airplaneWidth),(int)( _startPosY+airplaneHeight*0.63)),
            new Point((int)(_startPosX+airplaneWidth*0.9),(int)( _startPosY+airplaneHeight*0.47)),
            new Point((int)(_startPosX+airplaneWidth*0.8),(int)( _startPosY+airplaneHeight*0.47)),
            new Point((int)(_startPosX+airplaneWidth*0.9),(int)( _startPosY+airplaneHeight*0.63))
            };
            g.FillPolygon(steclo, pointBamper);// bamper

            Point[] pointTail =
            {
            new Point((int)(_startPosX+airplaneWidth*0.30),(int)( _startPosY+airplaneHeight*0.5)),
            new Point((int)(_startPosX + airplaneWidth * 0.15), (int)(_startPosY + airplaneHeight * 0.01)),
            new Point((int)(_startPosX + airplaneWidth * 0.13), (int)(_startPosY + airplaneHeight * 0.01)),
            new Point((int)(_startPosX+airplaneWidth*0.25),(int)( _startPosY+airplaneHeight*0.5))
            };
            g.FillPolygon(korpus, pointTail);// Tail
        }

        /// <summary>
        /// Метод интерфейса IEquatable для класса Airplane
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Airplane other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Airplane airplaneObj))
            {
                return false;
            }
            else
            {
                return Equals(airplaneObj);
            }
        }
    }
}

