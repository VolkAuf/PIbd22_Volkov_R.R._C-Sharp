using System;

namespace Airplane1
{
    /// <summary>
    /// Класс-ошибка "Если на аэродроме уже есть самолёт с такими же характеристиками"
    /// </summary>
    internal class AerodromeAlreadyHaveException : Exception
    {
        public AerodromeAlreadyHaveException() : base("There is already such an airplane at the aerodrome!") { }
    }
}
