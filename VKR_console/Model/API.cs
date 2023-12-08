using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class API
    {
        /// <summary>
        /// Словарь режимов работы ЭС.
        /// </summary>
        public readonly Dictionary<OperatingModes, double> _modesOperating =
            new()
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
