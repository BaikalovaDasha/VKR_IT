namespace Model
{
    /// <summary>
    /// Класс СЭС.
    /// </summary>
    public class SolarPowerPlant
    {
        /// <summary>
        /// Номер СЭС.
        /// </summary>
        private int _numberSPP;

        /// <summary>
        /// Нименование СЭС.
        /// </summary>
        private string _nameSPP;

        /// <summary>
        /// Чтение и запись статуса СЭС.
        /// </summary>
        public StatusSPP StatusSPP { get; set; }

        /// <summary>
        /// Узел СЭС в РМ.
        /// </summary>
        private int _nodeSPP;

        /// <summary>
        /// Энрегосистема.
        /// </summary>
        public PowerSystem PowerSystem;

        /// <summary>
        /// Установленная мощность.
        /// </summary>
        private double _installedCapacity;

        /// <summary>
        /// Чтение и запись номера СЭС.
        /// </summary>
        public int NumberSPP
        {
            get
            {
                return _numberSPP;
            }
            set
            {
                _numberSPP = CheckingNumber(value);
            }
        }

        /// <summary>
        /// Чтение и запись наименование СЭС.
        /// </summary>
        public string NameSPP
        {
            get
            {
                return _nameSPP;
            }
            set
            {
                _nameSPP = value;
            }
        }

        /// <summary>
        /// Чтение и запись узла в РМ.
        /// </summary>
        public int NodeSPP
        {
            get
            {
                return _nodeSPP;
            }
            set
            {
                _nodeSPP = CheckingNumber(value);
            }
        }

        /// <summary>
        /// Чтение и запись номера СЭС.
        /// </summary>
        public double InstalledCapacity
        {
            get
            {
                return _installedCapacity;
            }
            set
            {
                _installedCapacity = CheckingNumber((int)value);
            }
        }

        /// <summary>
        /// Проверка параметра.
        /// </summary>
        /// <param name="number">Число для проверки.</param>
        /// <returns>проверенное число.</returns>
        /// <exception cref="ArgumentException">отбрасывает отрицательные...
        /// ...числа</exception>
        private static int CheckingNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Параметр должен быть" +
                    " положительным!");
            }
            return number;
        }
    }
}
