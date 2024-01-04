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
        /// Получение необходимой строки по ЭС.
        /// </summary>
        /// <returns>строку из excel с указанной ЭС.</returns>
        public int FindExcelPS(string textToFind)
        {
            Application xlApp = new(); //Excel
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

            if (Rng != null)
            {
                rowExcel = Convert.ToInt32(RegexToInt().Replace(Rng.Address, ""));
                Console.WriteLine($"{rowExcel} - {xlSht.Cells[rowExcel, 3].Value}");
                Rng.Select();

            }
            else
            {
                Console.WriteLine($"Текст {textToFind} на листе не найден!");
            }

            xlApp.Quit();

            return rowExcel;
        }

        /// <summary>
        /// Формирование строки в Excel с необходимым поиском по ЭС.
        /// </summary>
        /// <returns>int строки в excel.</returns>
        [GeneratedRegex("[^\\d]+")]
        private static partial Regex RegexToInt();



    }
}
