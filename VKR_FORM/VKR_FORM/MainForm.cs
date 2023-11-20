using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKRFORM
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        private  List<SolarPowerPlant> SPPList = new();
        BindingSource sppSource = new();

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            sppSource.DataSource = SPPList;
            dataGridView1.DataSource = sppSource;
        }

        /// <summary>
        /// Автозаполнение текстового поля в столбцах...
        /// ...Энергосистема и Статус СЭС.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var colIndex = dataGridView1.CurrentCell.ColumnIndex;
            var colName = dataGridView1.Columns[colIndex].Name;

            TextBox textBox = (TextBox)e.Control;
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (colName == "PowerSystem")
            {
                textBox.AutoCompleteCustomSource = GetPowerSystemNames();
            }
            if (colName == "StatusSPP")
            {
                textBox.AutoCompleteCustomSource = GetStatusSPPNames();
            }

        }

        /// <summary>
        /// Коллекция наименования ЭС.
        /// </summary>
        /// <returns></returns>
        private static AutoCompleteStringCollection GetPowerSystemNames()
        {
            AutoCompleteStringCollection collection = new();

            collection.AddRange(new string[] { "Забайкальская", "Бурятская", "Хакасская" });

            return collection;
        }

        /// <summary>
        /// Коллекция наименования Статуса СЭС.
        /// </summary>
        /// <returns></returns>
        private static AutoCompleteStringCollection GetStatusSPPNames()
        {
            AutoCompleteStringCollection collection = new();

            collection.AddRange(new string[] { "Действующая", "Вводимая" });

            return collection;
        }

        private void Save_TableSPP_Click(object sender, EventArgs e)
        {

        }

        ///// <summary>
        ///// Метод загрузки вкладки.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void TabControl_Load(object sender, EventArgs e)
        //{
        //tabControl1.TabPages.Remove(tabPage_tableSPP);
        //tabControl1.TabPages.Remove(tabPage_resultsCalculation);
        //}

        ///// <summary>
        ///// Открытие Таблицы СЭС.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Open_tableSPP_Click(object sender, EventArgs e)
        //{
        //tabControl1.TabPages.Add(tabPage_tableSPP);
        //}

        ///// <summary>
        ///// Открытие результатов расчёта.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Open_ResultsCuculation_Click(object sender, EventArgs e)
        //{
        //tabControl1.TabPages.Add(tabPage_resultsCalculation);
        //}
    }
}
