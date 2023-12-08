using ASTRALib;
using System;
using System.Collections.Generic;

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
        public static IRastr _rastr = new Rastr();

        /// <summary>
        /// Загрузка файла с данными 
        /// </summary>
        /// <param name="pathFile">файл .rg2.</param>
        /// <param name="pathSablon">шаблон .rg2.</param>
        public static void LoadFile(string pathFile, string pathSablon)
        {
            _rastr.Load(RG_KOD.RG_REPL, pathFile, pathSablon);
        }

        /// <summary>
        /// Рассчитывает режим
        /// </summary>
        public static void Regime()
        {
            _rastr.rgm("");
        }

        /// <summary>
        /// Метод получение номеров агрегатов СЭС из списка.
        /// </summary>
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
        /// <returns></returns>
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
            throw new Exception($"Узел с номером {number} не найден.");
        }

        /// <summary>
        /// Метод записывает значение в любую ячейку таблицы.
        /// </summary>
        /// <param name="tableName">наименование таблицы.</param>
        /// <param name="columnName"></param>
        /// <param name="number"></param>
        /// <param name="chosenColumn"></param>
        /// <param name="value"></param>
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
        public static void GetInputPower(List<SolarPowerPlant> listSPP)
        {  
            Dictionary<OperatingModes, double> _modesOperating = new()
            {
                [OperatingModes.KWinterMaxAM] = 0.0757,
                [OperatingModes.KWinterMaxPM] = 0.01005,
                [OperatingModes.KWinterMin] = 0,
                [OperatingModes.KSummerMaxAM] = 0.2787,
                [OperatingModes.KSummerMaxPM] = 0.01024,
                [OperatingModes.KSummerMin] = 0.0085,
            };

            List<double> capacityInstall = new();

            foreach (SolarPowerPlant spp in listSPP)
            {
                capacityInstall.Add(spp.InstallCapacity * _modesOperating[OperatingModes.KWinterMaxAM]);
            }

            LoadFile(_pathFile, _pathSablon);

            //foreach (int num in GetNumSPP(listSPP))
            //{
            //    SetValue("Generator", "Num", num, "P", 2);
            //    Console.WriteLine($"работа программы завершена: {num}");
            //}

            _rastr.Save(_pathFile, "");
        }


        




    }
}