using ApplicationProgrammingInterface;
using Aspose.Cells.Rendering;
using ASTRALib;
using Microsoft.Office.Interop.Excel;
using Model;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace Calculation
{
    /// <summary>
    /// Класс для расчёта перспективных режимов работы с учётом...
    /// мощностей вводимых СЭС.
    /// </summary>
    public class PerspectiveModesOperation
    {
        /// <summary>
        /// Метод получения строки из файла Excel  с необходимой ЭС.
        /// </summary>
        /// <param name="_pathFile">Файл, в котором производится поиск.</param>
        /// <param name="textToFind">Искомое слово.</param>
        /// <returns>Строка в котором находится исхомое слово.</returns>
        public int FindExcelRowPS(string _pathFile, string textToFind)
        {
            // Excel
            Application xlApp = new();

            //рабочая книга
            Workbook xlWB;

            //лист Excel
            Worksheet xlSht;

            //диапазон ячеек
            Excel.Range Rng;

            //название файла Excel
            xlWB = xlApp.Workbooks.Open(_pathFile);

            //название листа или 1-й лист в книге xlSht = xlWB.Worksheets[1];
            xlSht = xlWB.Worksheets[1];

            textToFind = textToFind.Length > 6
                ? textToFind.Remove(textToFind.Length - 4)
                : textToFind.Remove(textToFind.Length - 2);

            // осуществляем поиск на листе
            Rng = xlSht.Cells.Find(textToFind, Type.Missing, XlFindLookIn.xlValues, XlLookAt.xlPart);

            int rowExcel = Convert.ToInt32(Regex.Replace(Rng.Address, @"[^\d]+", ""));

            return rowExcel;
        }

        /// <summary>
        /// Получение массива коэффициенты зависимости изменения максимума...
        /// потребления мощности территориальных энергосистем при изменении...
        /// температуры наружного воздуха.
        /// </summary>
        /// <param name="textToFind">искомая ЭС.</param>
        /// <returns>массив коэффициентов.</returns>
        public double[,] FindExcelArray(string textToFind)
        {
            // Excel
            Application xlApp = new();

            //рабочая книга
            Workbook xlWB;

            //лист Excel
            Worksheet xlSht;

            //диапазон ячеек
            Excel.Range Rng;

            //название файла Excel
            xlWB = xlApp.Workbooks.Open(@"C:\Users\Дарья\Desktop\1. ВКР\ИТ\Excel\power_consum_max_coefficient_2023_140623.xlsx");
            
            //название листа или 1-й лист в книге xlSht = xlWB.Worksheets[1];
            xlSht = xlWB.Worksheets[1];

            textToFind = textToFind.Length > 6 
                ? textToFind.Remove(textToFind.Length - 4) 
                : textToFind.Remove(textToFind.Length - 2);

            // осуществляем поиск на листе
            Rng = xlSht.Cells.Find(textToFind, Type.Missing, XlFindLookIn.xlValues, XlLookAt.xlPart);

            int rowExcel = new();

            double[,] arrayExcel = new double[3, 6];

            if (Rng != null)
            {
                rowExcel = Convert.ToInt32(Regex.Replace(Rng.Address, @"[^\d]+", ""));

                for (int i = 0; i < arrayExcel.GetLength(0); i++)
                {
                    for (int j = 0; j < arrayExcel.GetLength(1); j++)
                    {
                        if (xlSht.Cells[rowExcel + i, 3 + j].Value != null)
                        {
                            arrayExcel[i, j] = xlSht.Cells[rowExcel + i, 3 + j].Value;
                        }
                        else
                        {
                            arrayExcel[i, j] = 0;
                        }
                    }
                }
                xlApp.Workbooks.Close();
            }
            else
            {
                Console.WriteLine($"Текст {textToFind} на листе не найден!");
            }

            // добавление закрытия excel.xml
            xlApp.Workbooks.Close();
            xlApp.Quit();

            return arrayExcel;
        }

        /// <summary>
        /// Определение коэффициентов и расчётных температур наружного...
        /// воздуха ЭС, по наименованию ЭС.
        /// </summary>
        /// <param name="textToFind">Наименование ЭС.</param>
        /// <returns>словарь коэффициентов и температур.</returns>
        public Dictionary<string, double> GetkoefToES(string textToFind)
        {
            // Excel
            Application xlApp = new();

            //рабочая книга
            Workbook xlWB;

            //лист Excel
            Worksheet xlSht;

            //диапазон ячеек
            Excel.Range Rng;

            //название файла Excel
            xlWB = xlApp.Workbooks.Open(@"C:\Users\Дарья\Desktop\1. ВКР\ИТ\Excel\temp_coefficient_2023_140623.xlsx");

            //название листа или 1-й лист в книге xlSht = xlWB.Worksheets[1];
            xlSht = xlWB.Worksheets[1];

            textToFind = textToFind.Length > 6
                ? textToFind.Remove(textToFind.Length - 4)
                : textToFind.Remove(textToFind.Length - 2);

            // осуществляем поиск на листе
            Rng = xlSht.Cells.Find(textToFind, Type.Missing, XlFindLookIn.xlValues, XlLookAt.xlPart);

            int rowExcel = new();

            Dictionary<string, double> dictionaryKoef = new();

            if (Rng != null)
            {
                rowExcel = Convert.ToInt32(Regex.Replace(Rng.Address, @"[^\d]+", ""));
                dictionaryKoef.Add("kZimaMinMax", xlSht.Cells[rowExcel, 3].Value);
                dictionaryKoef.Add("kLetoMinMax", xlSht.Cells[rowExcel, 4].Value);
                dictionaryKoef.Add("kLZMax", xlSht.Cells[rowExcel, 6].Value);
                dictionaryKoef.Add("tsrSIPR", xlSht.Cells[rowExcel, 38].Value);
                dictionaryKoef.Add("tLeto0.98", xlSht.Cells[rowExcel, 37].Value);
                dictionaryKoef.Add("tZima0.92", xlSht.Cells[rowExcel, 36].Value);
                dictionaryKoef.Add("tGOST", xlSht.Cells[rowExcel, 40].Value);
                dictionaryKoef.Add("tLetoNorm", xlSht.Cells[rowExcel, 39].Value);
            }
            else
            {
                Console.WriteLine($"Текст {textToFind} на листе не найден!");
            }

            // добавление закрытия excel.xml
            xlWB.Close(false);
            xlApp.Workbooks.Close();
            xlApp.Quit();
            xlApp = null;
            xlWB = null;
            xlSht = null;
            Rng = null;

            return dictionaryKoef;
        }

        /// <summary>
        /// Метод расчёта потребления мощности в зависимости от наружного воздуха.
        /// </summary>
        /// <param name="excelarray">массив коэффициентов зависимости изменения температур.</param>
        /// <param name="tempCalcul">расчётное значение температуры.</param>
        /// <param name="tempInit">исходное значение температуры.</param>
        /// <param name="pInit">исходное значение мощности.</param>
        public static double GetPowerMax(double[,] excelarray, double tempCalcul,
            double tempInit, double pInit)
        {
            double pCalaul = pInit;

            for (int j = 0; j < excelarray.GetLength(1); j++)
            {
                double koef = excelarray[2, j];
                if (tempCalcul > excelarray[0, j] && tempCalcul < excelarray[1, j])
                {
                    pCalaul = Calculate(pCalaul, tempCalcul, excelarray[0, j], koef);
                    break;
                }
                else
                {
                    pCalaul = Calculate(pCalaul, excelarray[1, j], tempInit, koef);
                    tempInit = excelarray[0, j + 1];
                }
            }

            return pCalaul;
        }

        /// <summary>
        /// Расчёт потребления мощности. 
        /// </summary>
        /// <param name="pInit">Исходная мощность потребления ЭС.</param>
        /// <param name="TempRasch">расчётное значение температуры.</param>
        /// <param name="TempIsx">значение температуры исходных условий.</param>
        /// <param name="k">коэффициент знависимости изменения потребления мощности.</param>
        /// <returns>Расчётное значение мощности.</returns>
        public static double Calculate(double pInit, double TempRasch, double TempIsx, double k)
        {
            return pInit * (1 + k / 100 * (TempRasch - TempIsx));
        }


    }
}
