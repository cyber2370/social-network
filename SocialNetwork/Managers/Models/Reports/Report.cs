using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Models.Reports
{
    public class Report<T>
    {
        public T Key { get; set; }
        public int CountKey { get; set; }
    }
}
