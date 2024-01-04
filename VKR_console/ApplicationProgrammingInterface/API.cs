using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationProgrammingInterface
{
    /// <summary>
    /// Класс для вычисления среднего коэффициента выработки...
    /// мощности по действующим СЭС.
    /// </summary>
    public class API
    {
        /// <summary>
        /// СЛоварь средних коэф. выработки мощности для каждого режима.
        /// </summary>
        public static readonly Dictionary<OperatingModes, double> ModesOperating = new()
        {
            [OperatingModes.KWinterMaxAM] = 0.0757,
            [OperatingModes.KWinterMaxPM] = 0.01005,
            [OperatingModes.KWinterMin] = 0,
            [OperatingModes.KSummerMaxAM] = 0.2787,
            [OperatingModes.KSummerMaxPM] = 0.01024,
            [OperatingModes.KSummerMin] = 0.0085,
        };
    }
}
