using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VedSoft.Utility
{
    public static class PagingUtils
    {
        //public static IEnumerable<T> Page<T>(this IEnumerable<T> en, int pageSize, int page)
        //{
        //    return en.Skip(page * pageSize).Take(pageSize);
        //}
        public static IQueryable<T> Page<T>(this IQueryable<T> en, int pageSize, int page)
        {
            return en.Skip((page-1) * pageSize).Take(pageSize);
        }

        public static int MySQLStartLimit(int PageNumber, int pageSize)
        {
            return ((PageNumber - 1) * pageSize);
        }
    }
}
