using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2.Diagnostics
{
    public class PerformanceAnalysisUtility
    {
        /// <summary>
        /// Invoke a delegate to compute the time elapsed for the task. For example, call it like this:
        ///   PerformanceAnalysisUtility.Time(  () => { code to run });
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TimeSpan Time(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
