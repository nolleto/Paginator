using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paginator.Models
{
    public class Page<TModel>
    {
        public TModel[] Items { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }
        public int Count { get; set; }
    }
}
