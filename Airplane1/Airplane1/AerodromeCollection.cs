using System.Collections.Generic;
using System.IO;
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
        /// Разделитель для записи информации в файл
        /// </summary>
        private readonly char separator = ':';

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
        /// Добавление аэродрома
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

        public bool SaveDataDop(string filename, string Key)
        {
            if (Keys.Contains(Key))
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.WriteLine($"AerodromeCollection");
                    //Начинаем выгрузку аэродрома
                    sw.WriteLine($"Aerodrome{separator}{Key}");
                    ITransport airplane = null;
                    for (int i = 0; (airplane = aerodromeStages[Key].GetNext(i)) != null; i++)
                    {
                        if (airplane != null)
                        {
                            //если место не пустое
                            //Записываем тип самолёта
                            if (airplane.GetType().Name == "Airplane")
                            {
                                sw.Write($"Airplane{separator}");
                            }
                            if (airplane.GetType().Name == "Airbus")
                            {
                                sw.Write($"Airbus{separator}");
                            }
                            //Записываемые параметры
                            sw.WriteLine(airplane);
                        }
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Сохранение информации по самолётам на аэродромах в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine($"AerodromeCollection");
                foreach (KeyValuePair<string, Aerodrome<AirTransport>> level in aerodromeStages)
                {
                    //Начинаем выгрузку аэродрома
                    sw.WriteLine($"Aerodrome{separator}{level.Key}");
                    ITransport airplane = null;
                    for (int i = 0; (airplane = level.Value.GetNext(i)) != null; i++)
                    {
                        if (airplane != null)
                        {
                            //если место не пустое
                            //Записываем тип самолёта
                            if (airplane.GetType().Name == "Airplane")
                            {
                                sw.Write($"Airplane{separator}");
                            }
                            if (airplane.GetType().Name == "Airbus")
                            {
                                sw.Write($"Airbus{separator}");
                            }
                            //Записываемые параметры
                            sw.WriteLine(airplane);
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Загрузка информации по самолётам на аэродромах из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                if (line.Contains("AerodromeCollection"))
                {
                    //очищаем записи
                    aerodromeStages.Clear();
                }
                else
                {
                    //если нет такой записи, то это не те данные
                    return false;
                }

                AirTransport airplane = null;
                string key = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    //идем по считанным записям
                    if (line.Contains("Aerodrome"))
                    {
                        //начинаем новый аэродром
                        key = line.Split(separator)[1];
                        aerodromeStages.Add(key, new Aerodrome<AirTransport>(pictureWidth, pictureHeight));
                        continue;
                    }
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    if (line.Split(separator)[0] == "Airplane")
                    {
                        airplane = new Airplane(line.Split(separator)[1]);
                    }
                    else if (line.Split(separator)[0] == "Airbus")
                    {
                        airplane = new Airbus(line.Split(separator)[1]);
                    }
                    bool result = aerodromeStages[key] + airplane;
                    if (!result)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}