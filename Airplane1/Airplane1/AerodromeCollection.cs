using System.Collections.Generic;
using System.Linq;

namespace Airplane1
{
    public class AerodromeCollection
    {
        /// <summary>
        /// Словарь (хранилище) с аэродромами
        /// </summary>
        private readonly Dictionary<string, Aerodrome<AirTransport>> aerodromeStages;
        /// <summary>
        /// Возвращение списка названий аэродромов
        /// </summary>
        public List<string> Keys => aerodromeStages.Keys.ToList();
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public AerodromeCollection(int pictureWidth, int pictureHeight)
        {
            aerodromeStages = new Dictionary<string, Aerodrome<AirTransport>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }
        /// <summary>
        /// Добавление аэродроме
        /// </summary>
        /// <param name="name">Название аэродрома</param>
        public void AddAerodrome(string name)
        {
            if (Keys.Contains(name))
            {
                return;
            }
            aerodromeStages.Add(name, new Aerodrome<AirTransport>(pictureWidth, pictureHeight));
        }
        /// <summary>
        /// Удаление аэродрома
        /// </summary>
        /// <param name="name">Название аэродрома</param>
        public void DeleteAerodrome(string name)
        {
            if (aerodromeStages.ContainsKey(name))
            {
                aerodromeStages.Remove(name);
            }
        }
        /// <summary>
        /// Доступ к аэродрому
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Aerodrome<AirTransport> this[string ind]
        {
            get
            {
                if (aerodromeStages.ContainsKey(ind))
                {
                    return aerodromeStages[ind];
                }
                return null;
            }
        }
    }
}
