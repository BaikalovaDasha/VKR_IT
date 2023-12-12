using ASTRALib;

namespace Model
{
    /// <summary>
    /// Класс для взаимодействия с RastrWin.
    /// </summary>
    public class CalculationRastr
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
        private static readonly string _pathFilerg = "C:\\Users\\Дарья\\Desktop" +
            "\\1. ВКР\\ИТ\\РМ\\14-00 new(1.1).rg2";

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
        /// СЛоварь средних коэф. выработки мощности для каждого режима.
        /// </summary>
        internal static readonly Dictionary<OperatingModes, double> _modesOperating = new()
        {
            [OperatingModes.KWinterMaxAM] = 0.0757,
            [OperatingModes.KWinterMaxPM] = 0.01005,
            [OperatingModes.KWinterMin] = 0,
            [OperatingModes.KSummerMaxAM] = 0.2787,
            [OperatingModes.KSummerMaxPM] = 0.01024,
            [OperatingModes.KSummerMin] = 0.0085,
        };

        /// <summary>
        /// Метод расчёта мощности вводимых СЭС.
        /// </summary>
        /// <param name="n">номер агрегата.</param>
        /// <param name="listSPP">список СЭС.</param>
        /// <returns>вводимая мощность.</returns>
        public static List<double> GetInputPower(int n,
            List<SolarPowerPlant> listSPP)
        {
            List<double> capacityInstall = new();

            foreach (SolarPowerPlant spp in listSPP)
            {
                // изменить
                if (n == spp.SPPNum)
                {
                    capacityInstall.Add(spp.InstallCapacity *
                        _modesOperating[OperatingModes.KWinterMaxAM]);
                }

            }

            return capacityInstall;
        }

        /// <summary>
        /// Метод записывающий значение мощности вводимых СЭС.
        /// </summary>
        /// <param name="listSPP">список СЭС.</param>
        public static void SettingPowerGeneratorsSPP(List<SolarPowerPlant> listSPP)
        {
            LoadFile(_pathFile, _pathSablon);

            foreach (int num in GetNumSPP(listSPP))
            {
                foreach (double Pinput in GetInputPower(num, listSPP))
                {
                    SetValue("Generator", "Num", num, "P", Pinput);
                    Console.WriteLine($"Установленная мощность: {Pinput}.");
                }

               Console.Write($"Номер агрегата: {num}. \n");
            }

            SaveRegime(_pathFilerg, _pathSablon);
        }
}
}