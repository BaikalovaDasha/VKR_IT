using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Windows.Forms;

namespace VKRFORM
{
    /// <summary>
    /// Основная форма.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список СЭС для теста.
        /// </summary>
        private List<SolarPowerPlant> ListSPP;

        private BindingList<SolarPowerPlant> SPPDataList;

        /// <summary>
        /// Запуск основной формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            ListSPP = new List<SolarPowerPlant>();

            SPPDataList = new BindingList<SolarPowerPlant>(ListSPP);
            dataGridView1.DataSource = SPPDataList;
        }

        /// <summary>
        /// Автозаполнение текстового поля в столбцах...
        /// ...Энергосистема и Статус СЭС.
        /// </summary>
        /// <param name="sender">объект.</param>
        /// <param name="e">datagridView.</param>
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
        /// <returns>Наименование СЭС.</returns>
        private static AutoCompleteStringCollection GetPowerSystemNames()
        {
            AutoCompleteStringCollection collection = new();

            collection.AddRange(new string[] { "Забайкальская", "Бурятская", "Хакасская" });

            return collection;
        }

        /// <summary>
        /// Коллекция наименования Статуса СЭС.
        /// </summary>
        /// <returns>Наименование статусов СЭС.</returns>
        private static AutoCompleteStringCollection GetStatusSPPNames()
        {
            AutoCompleteStringCollection collection = new();

            collection.AddRange(new string[] { "Действующая", "Вводимая" });

            return collection;
        }

        /// <summary>
        /// Сохранение таблицы СЭС в JSON.
        /// </summary>
        /// <param name="sender">объект.</param>
        /// <param name="e">аргумент.</param>
        private void Save_TableSPP_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Json files (*.json)|*.json";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.InitialDirectory = @"C:\Users\Дарья\Desktop\1. ВКР\json файлы";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "json_File";
            saveFileDialog1.Title = "json_Export";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var json = JsonSerializer.Serialize(ListSPP);

                File.WriteAllText(saveFileDialog1.FileName, json);

                MessageBox.Show("Файл успешно сохранен!", "Сохранение файла",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Загрузить таблицу СЭС.
        /// </summary>
        /// <param name="sender">объект.</param>
        /// <param name="e">аргумент.</param>
        private void Download_TableSPP_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                string jsonString = File.ReadAllText(filename);
                List<SolarPowerPlant> listFromJson =
                    JsonSerializer.Deserialize<List<SolarPowerPlant>>(jsonString);

                SPPDataList = new BindingList<SolarPowerPlant>(listFromJson);
                dataGridView1.DataSource = SPPDataList;
            }
        }

        /// <summary>
        /// Событие добавление новой строки или изменение...
        /// какой-либо ячейки в строке.
        /// </summary>
        /// <param name="sender">объект.</param>
        /// <param name="e">аргумент.</param>
        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Console.WriteLine("DataBindingComplete");
            Console.WriteLine(e.ListChangedType);
        }
    }
}
