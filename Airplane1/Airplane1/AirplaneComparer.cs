using System.Collections.Generic;

namespace Airplane1
{
    internal class AirplaneComparer : IComparer<AirTransport>
    {
        public int Compare(AirTransport x, AirTransport y)
        {
            // Реализовать метод сравнения для объектов
            if (!x.GetType().Name.Equals(y.GetType().Name))
            {
                return x.GetType().Name.CompareTo(y.GetType().Name);
            }
            else
            {
                switch (x.GetType().Name)
                {
                    case "Airplane":
                        return ComparerAirplane((Airplane)x, (Airplane)y);
                    case "Airbus":
                        return ComparerAirbus((Airbus)x, (Airbus)y);
                    default:
                        return 0;
                }
            }
        }

        private int ComparerAirplane(Airplane x, Airplane y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }
        private int ComparerAirbus(Airbus x, Airbus y)
        {
            int res = ComparerAirplane(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.HasBackTurbine != y.HasBackTurbine)
            {
                return x.HasBackTurbine.CompareTo(y.HasBackTurbine);
            }
            if (x.HasSideTurbine != y.HasSideTurbine)
            {
                return x.HasSideTurbine.CompareTo(y.HasSideTurbine);
            }
            if (x.HasRegulTail != y.HasRegulTail)
            {
                return x.HasRegulTail.CompareTo(y.HasRegulTail);
            }
            if (x.HasMarketLine != y.HasMarketLine)
            {
                return x.HasMarketLine.CompareTo(y.HasMarketLine);
            }
            if (x.HasSecondFloor != y.HasSecondFloor)
            {
                return x.HasSecondFloor.CompareTo(y.HasSecondFloor);
            }
            if (x.HasIlluminator != y.HasIlluminator)
            {
                return x.HasIlluminator.CompareTo(y.HasIlluminator);
            }
            return 0;
        }
    }
}
