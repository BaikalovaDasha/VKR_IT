using ApplicationProgrammingInterface;
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
    public partial class PromisingModesOperation
    {

        /// <summary>
        /// Получение необходимой строки по искомой ЭС.
        /// </summary>
        /// <param name="textToFind">искомая ЭС.</param>
        /// <returns>строку из excel с указанной ЭС.</returns>
        public double[,] FindExcelRow(string textToFind)
        {

            Application xlApp = new(); // Excel
            Workbook xlWB; //рабочая книга              
            Worksheet xlSht; //лист Excel
            Excel.Range Rng; //диапазон ячеек

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
                rowExcel = Convert.ToInt32(RegexToInt().Replace(Rng.Address, ""));

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
                        Console.Write($"{arrayExcel[i, j]} \t");
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine($"Текст {textToFind} на листе не найден!");
            }

            xlApp.Quit();

            return arrayExcel;
        }

        /// <summary>
        /// Формирование строки в Excel с необходимым поиском по ЭС.
        /// </summary>
        /// <returns>int строки в excel.</returns>
        [GeneratedRegex("[^\\d]+")]
        private static partial Regex RegexToInt();
    }
}
