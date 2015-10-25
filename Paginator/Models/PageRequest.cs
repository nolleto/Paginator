using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paginator.Models
{
    public class PageRequest
    {
        public int Index { get; set; }
        public int Length { get; set; }

        public PageRequest()
        {
            Index = Defaults.Index;
            Length = Defaults.PageLength;
        }
    }
}
