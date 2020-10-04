﻿using System.Drawing;

namespace Airplane1
{
    class Airbus : Airplane
    {
        public Color DopColor { private set; get; }
        public bool BackTurbine { private set; get; }
        public bool SideTurbine { private set; get; }
        public bool ReclamLine { private set; get; }
        public bool RegulTail { private set; get; }
        public bool Illuminator { private set; get; }
        public bool SecondFloor { private set; get; }

        public Airbus(int maxSpeed, float weight, Color mainColor, Color dopColor, bool backTurbine, bool sideTurbine,
            bool reclamLine, bool regulTail, bool illuminator, bool secondFloor)
                : base(maxSpeed, weight, mainColor, 150, 80)
        {
            DopColor = dopColor;
            BackTurbine = backTurbine;
            SideTurbine = sideTurbine;
            ReclamLine = reclamLine;
            RegulTail = regulTail;
            Illuminator = illuminator;
            SecondFloor = secondFloor;
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

            if (BackTurbine)
            {
                g.FillEllipse(turbin, (float)(_startPosX + airplaneWidth * 0.1), (float)(_startPosY + airplaneHeight * 0.4), (float)(airplaneWidth * 0.2), (float)(airplaneHeight * 0.2));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.1), (float)(_startPosY + airplaneHeight * 0.5), (float)(_startPosX + airplaneWidth * 0.3), (float)(_startPosY + airplaneHeight * 0.5));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.2), (float)(_startPosY + airplaneHeight * 0.4), (float)(_startPosX + airplaneWidth * 0.2), (float)(_startPosY + airplaneHeight * 0.6));
            }
            if (SideTurbine)
            {
                g.FillEllipse(turbin, (float)(_startPosX + airplaneWidth * 0.4), (float)(_startPosY + airplaneHeight * 0.01), (float)(airplaneWidth * 0.1), (float)(airplaneHeight * 0.1));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.4), (float)(_startPosY + airplaneHeight * 0.06), (float)(_startPosX + airplaneWidth * 0.5), (float)(_startPosY + airplaneHeight * 0.06));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.45), (float)(_startPosY + airplaneHeight * 0.01), (float)(_startPosX + airplaneWidth * 0.45), (float)(_startPosY + airplaneHeight * 0.11));
                g.FillEllipse(turbin, (float)(_startPosX + airplaneWidth * 0.4), (float)(_startPosY + airplaneHeight * 0.87), (float)(airplaneWidth * 0.1), (float)(airplaneHeight * 0.1));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.4), (float)(_startPosY + airplaneHeight * 0.92), (float)(_startPosX + airplaneWidth * 0.5), (float)(_startPosY + airplaneHeight * 0.92));
                g.DrawLine(shestern, (float)(_startPosX + airplaneWidth * 0.45), (float)(_startPosY + airplaneHeight * 0.87), (float)(_startPosX + airplaneWidth * 0.45), (float)(_startPosY + airplaneHeight * 0.97));
            }
            if (RegulTail)
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
            if (SecondFloor)
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

                if (Illuminator)
                {
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.2), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.3), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.4), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.5), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                    g.FillEllipse(illuminator, (int)(_startPosX + airplaneWidth * 0.6), (int)(_startPosY + airplaneHeight * 0.4), (int)(airplaneWidth * 0.04), (int)(airplaneWidth * 0.04));
                }
            }

            base.DrawTransport(g);

            if (ReclamLine)
            {
                Point[] pointSportLine =
            {
            new Point((int)(_startPosX+airplaneWidth*0.15),(int)( _startPosY+airplaneHeight*0.47)),
            new Point((int)(_startPosX+airplaneWidth*0.64),(int)( _startPosY+airplaneHeight*0.63)),
            new Point((int)(_startPosX+airplaneWidth*0.9),(int)( _startPosY+airplaneHeight*0.63)),
            new Point((int)(_startPosX+airplaneWidth*0.37),(int)( _startPosY+airplaneHeight*0.47))
            };
                g.FillPolygon(reklamLine, pointSportLine);// SLine

            }
            if (Illuminator)
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
