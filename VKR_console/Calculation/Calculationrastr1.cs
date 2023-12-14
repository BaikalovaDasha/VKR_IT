using ASTRALib;
using Model;
using ApplicationProgrammingInterface;

namespace Calculation
{
    /// <summary>
    /// Метод для расчёта в растре.
    /// </summary>
    public class Calculationrastr1
    {
        /// <summary>
        /// Загрузка файла .rg2.
        /// </summary>
        private static readonly string _pathFile = "C:\\Users\\Дарья\\Desktop" +
            "\\1. ВКР\\ИТ\\РМ\\14-00 new.rg2";

        /// <summary>
        /// Шаблон .rg2.
        /// </summary>
        private static readonly string _pathSablon = "C:\\Program Files\\" +
            "RastrWin3\\RastrWin3\\SHABLON\\режим.rg2";

        /// <summary>
        /// Создание указателя на экземпляр RastrWin и его запуск.
        /// </summary>
        private static IRastr _rastr = new Rastr();

        /// <summary>
        /// Загрузка файла с данными.
        /// </summary>
        /// <param name="pathFile">файл .rg2.</param>
        /// <param name="pathSablon">шаблон .rg2.</param>
        public static void LoadFile(string pathFile, string pathSablon)
        {
            _rastr.Load(RG_KOD.RG_REPL, pathFile, pathSablon);
        }

        /// <summary>
        /// Рассчитывает режим.
        /// </summary>
        public static void Regime()
        {
            _rastr.rgm("");
        }

        /// <summary>
        /// Сохранение файла .rg2.
        /// </summary>
        private static readonly Dictionary<int, string> _pathFileRG = new()
        {
            [1] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\14-00.(1.1)Зима_max_утро.rg2",
            [2] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\14-00.(1.3)Зима_max_вечер.rg2",
            [3] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\14-00.(1.5)Зима_min.rg2",
            [4] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\14-00.(2.1)Лето_max_утро.rg2",
            [5] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\14-00.(2.3)Лето_max_вечер.rg2",
            [6] = "C:\\Users\\Дарья\\Desktop\\1. ВКР\\ИТ\\РМ\\14-00.(2.5)Лето_min.rg2",
        };

        /// <summary>
        /// Сохранение режима.
        /// </summary>
        /// <param name="pathFile">Загружаемый файл режима.</param>
        /// <param name="pathSablon">Режим шаблона.</param>
        public static void SaveRegime(string pathFile, string pathSablon)
        {
            _rastr.Save(pathFile, pathSablon);
        }

        /// <summary>
        /// Узнать индекс из любой таблицы по номеру (узела, агрегата, сечения).
        /// </summary>
        /// <param name="tableName">наименование таблицы.</param>
        /// <param name="columnName">наименование столбца.</param>
        /// <param name="number">номер агрегата/узла.</param>
        /// <returns>индекс строки в растре.</returns>
        public static int GetIndexByNumber(string tableName, string columnName, int number)
        {
            ITable Table = (ITable)_rastr.Tables.Item(tableName);
            ICol СolumnTable = (ICol)Table.Cols.Item(columnName);

            for (int index = 0; index < Table.Count; index++)
            {
                if ((int)СolumnTable.get_ZN(index) == number)
                {
                    return index;
                }
            }

            throw new Exception($"Агргеат с номером {number} не найден.");
        }

        /// <summary>
        /// Метод записывает значение в любую ячейку таблицы.
        /// </summary>
        /// <param name="tableName">наименование таблицы.</param>
        /// <param name="columnName">наименование столбца, где...
        /// происходит поиск параметра.</param>
        /// <param name="number">значения параметра.</param>
        /// <param name="chosenColumn">столбец в котором будут...
        /// меняться значения.</param>
        /// <param name="value">величина.</param>
        public static void SetValue(string tableName, string columnName, int number,
            string chosenColumn, double value)
        {
            ITable table = (ITable)_rastr.Tables.Item(tableName);
            ICol ColumnTable = (ICol)table.Cols.Item(chosenColumn);

            int index = GetIndexByNumber(tableName, columnName, number);
            ColumnTable.set_ZN(index, value);
        }

        /// <summary>
        /// Метод расчёта мощности вводимых СЭС.
        /// </summary>
        /// <param name="listSPP">список СЭС.</param>
        /// <param name="num">номера агрегатов СЭС.</param>
        /// <returns>вводимая мощность.</returns>
        public static List<double> GetInputPower(List<SolarPowerPlant> listSPP, int num)
        {
            List<double> capacityInstall = new();

            foreach (var item in ApplicationProgrammingInterface.API.ModesOperating)
            {
                var sppItem = listSPP.FirstOrDefault(x => x.SPPNum == num);
                capacityInstall.Add(sppItem.InstallCapacity * item.Value);
            }

            return capacityInstall;
        }

        /// <summary>
        /// Метод получение номеров агрегатов СЭС из списка.
        /// </summary>
        /// <param name="solarPowerPlant">Список СЭС.</param>
        /// <returns>Номера агрегатов.</returns>
        public static List<int> GetNumSPP(List<SolarPowerPlant> solarPowerPlant)
        {
            List<int> listNumSPP = new();

            foreach (SolarPowerPlant spp in solarPowerPlant)
            {
                listNumSPP.Add(spp.SPPNum);
            }

            return listNumSPP;
        }

        /// <summary>
        /// Метод записывающий значение мощности вводимых СЭС.
        /// </summary>
        /// <param name="listSPP">список СЭС.</param>
        public static void SettingPowerGeneratorsSPP(List<SolarPowerPlant> listSPP)
        {
            LoadFile(_pathFile, _pathSablon);

            foreach (var pathfile in _pathFileRG)
            {
                Console.WriteLine(pathfile.Value);

                foreach (var num in GetNumSPP(listSPP))
                {
                    Console.WriteLine(num);

                    foreach (double Pinput in GetInputPower(listSPP, num))
                    {
                        Console.WriteLine(Pinput);

                        // SetValue("Generator", "Num", num, "P", item);
                        // SaveRegime(pathfile.Value, _pathSablon);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
