using System.Drawing;

namespace Airplane1
{
    internal class Airbus : Airplane
    {
        public Color DopColor { private set; get; }
        public bool HasBackTurbine { private set; get; }
        public bool HasSideTurbine { private set; get; }
        public bool HasMarketLine { private set; get; }
        public bool HasRegulTail { private set; get; }
        public bool HasIlluminator { private set; get; }
        public bool HasSecondFloor { private set; get; }

        public Airbus(int maxSpeed, float weight, Color mainColor, Color dopColor, bool hasBackTurbine, bool hasSideTurbine,
            bool hasMarketLine, bool hasRegulTail, bool hasIlluminator, bool hasSecondFloor)
                : base(maxSpeed, weight, mainColor, 150, 80)
        {
            DopColor = dopColor;
            HasBackTurbine = hasBackTurbine;
            HasSideTurbine = hasSideTurbine;
            HasMarketLine = hasMarketLine;
            HasRegulTail = hasRegulTail;
            HasIlluminator = hasIlluminator;
            HasSecondFloor = hasSecondFloor;
        }

        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen shestern = new Pen(Color.White);
            Brush korpus = new SolidBrush(MainColor);
            Brush turbin = new SolidBrush(Color.Black);
            Brush illuminator = new SolidBrush(Color.FloralWhite);
            Brush reklamLine = new SolidBrush(DopColor);
            Brush dno = new SolidBrush(Color.White);
            Brush steclo = new SolidBrush(Color.Black);

            if (HasBackTurbine)
            {
                g.FillEllipse(turbin, (float)(_startPosX + airplaneWidth * 0.1), (float)(_startPosY + airplaneHeight * 0.4), (float)(airplaneWidth * 0.2), (float)(airplaneHeight * 0.2));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.1), (float)(_startPosY + airplaneHeight * 0.5), (float)(_startPosX + airplaneWidth * 0.3), (float)(_startPosY + airplaneHeight * 0.5));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.2), (float)(_startPosY + airplaneHeight * 0.4), (float)(_startPosX + airplaneWidth * 0.2), (float)(_startPosY + airplaneHeight * 0.6));
            }
            if (HasSideTurbine)
            {
                g.FillEllipse(turbin, (float)(_startPosX + airplaneWidth * 0.4), (float)(_startPosY + airplaneHeight * 0.01), (float)(airplaneWidth * 0.1), (float)(airplaneHeight * 0.1));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.4), (float)(_startPosY + airplaneHeight * 0.06), (float)(_startPosX + airplaneWidth * 0.5), (float)(_startPosY + airplaneHeight * 0.06));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.45), (float)(_startPosY + airplaneHeight * 0.01), (float)(_startPosX + airplaneWidth * 0.45), (float)(_startPosY + airplaneHeight * 0.11));
                g.FillEllipse(turbin, (float)(_startPosX + airplaneWidth * 0.4), (float)(_startPosY + airplaneHeight * 0.87), (float)(airplaneWidth * 0.1), (float)(airplaneHeight * 0.1));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.4), (float)(_startPosY + airplaneHeight * 0.92), (float)(_startPosX + airplaneWidth * 0.5), (float)(_startPosY + airplaneHeight * 0.92));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.45), (float)(_startPosY + airplaneHeight * 0.87), (float)(_startPosX + airplaneWidth * 0.45), (float)(_startPosY + airplaneHeight * 0.97));
            }
            if (HasRegulTail)
            {
                Point[] pointSportTail =
            {
            new Point((int)(_startPosX + airplaneWidth* 0.18), (int) (_startPosY + airplaneHeight* 0.19)),
            new Point((int)(_startPosX + airplaneWidth* 0.1), (int) (_startPosY + airplaneHeight* 0.21)),
            new Point((int)(_startPosX + airplaneWidth* 0.13), (int) (_startPosY + airplaneHeight* 0.24)),
            new Point((int)(_startPosX + airplaneWidth* 0.2), (int) (_startPosY + airplaneHeight* 0.28)),
            new Point((int)(_startPosX + airplaneWidth * 0.25), (int)(_startPosY + airplaneHeight * 0.26)),
            new Point((int)(_startPosX + airplaneWidth * 0.35), (int)(_startPosY + airplaneHeight * 0.2)),
            new Point((int)(_startPosX + airplaneWidth * 0.33), (int)(_startPosY + airplaneHeight * 0.17)),
            new Point((int)(_startPosX + airplaneWidth * 0.23), (int)(_startPosY + airplaneHeight * 0.19)),
            };
                g.FillPolygon(korpus, pointSportTail);// STail
            }

            base.DrawTransport(g);

            if (HasSecondFloor)
            {
                Point[] pointSecondFloor =
                {
            new Point((int)(_startPosX+airplaneWidth*0.15),(int)( _startPosY+airplaneHeight*0.47)),
            new Point((int)(_startPosX+airplaneWidth*0.1),(int)( _startPosY+airplaneHeight*0.33)),
            new Point((int)(_startPosX+airplaneWidth*0.8),(int)( _startPosY+airplaneHeight*0.33)),
            new Point((int)(_startPosX+airplaneWidth*0.9),(int)( _startPosY+airplaneHeight*0.47))
            };
                g.FillPolygon(korpus, pointSecondFloor);// Korpus

                //Door
                g.DrawLine(pen, (int)(_startPosX + airplaneWidth * 0.72), (int)(_startPosY + airplaneHeight * 0.47), (int)(_startPosX + airplaneWidth * 0.72), (int)(_startPosY + airplaneHeight * 0.37));
                g.DrawLine(pen, (int)(_startPosX + airplaneWidth * 0.72), (int)(_startPosY + airplaneHeight * 0.37), (int)(_startPosX + airplaneWidth * 0.75), (int)(_startPosY + airplaneHeight * 0.37));
                g.DrawLine(pen, (int)(_startPosX + airplaneWidth * 0.75), (int)(_startPosY + airplaneHeight * 0.37), (int)(_startPosX + airplaneWidth * 0.75), (int)(_startPosY + airplaneHeight * 0.47));
                g.DrawLine(pen, (int)(_startPosX + airplaneWidth * 0.75), (int)(_startPosY + airplaneHeight * 0.47), (int)(_startPosX + airplaneWidth * 0.72), (int)(_startPosY + airplaneHeight * 0.47));

                if (HasIlluminator)
                {
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.2), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.3), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.4), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.5), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.6), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                }
            }

            if (HasMarketLine)
            {
                Point[] pointMarketLine =
            {
            new Point((int)(_startPosX+airplaneWidth*0.15),(int)( _startPosY+airplaneHeight*0.47)),
            new Point((int)(_startPosX+airplaneWidth*0.64),(int)( _startPosY+airplaneHeight*0.63)),
            new Point((int)(_startPosX+airplaneWidth*0.9),(int)( _startPosY+airplaneHeight*0.63)),
            new Point((int)(_startPosX+airplaneWidth*0.37),(int)( _startPosY+airplaneHeight*0.47))
            };
                g.FillPolygon(reklamLine, pointMarketLine);// SLine

            }
            if (HasIlluminator)
            {
                g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.2), (int)(_startPosY + airplaneHeight * 0.5), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.3), (int)(_startPosY + airplaneHeight * 0.5), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.4), (int)(_startPosY + airplaneHeight * 0.5), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.5), (int)(_startPosY + airplaneHeight * 0.5), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.6), (int)(_startPosY + airplaneHeight * 0.5), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.7), (int)(_startPosY + airplaneHeight * 0.5), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
            }
        }
    }
}
