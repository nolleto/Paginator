using Paginator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Paginator
{
    public static class Defaults
    {
        /// <summary>
        /// 1
        /// </summary>
        public static int Index { get; set; }
        /// <summary>
        /// 10
        /// </summary>
        public static int PageLength { get; set; }
        
        static Defaults()
        {
            Index = 1;
            PageLength = 10;
        }
    }
}
