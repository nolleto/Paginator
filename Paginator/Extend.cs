using Paginator;
using Paginator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class Extend
    {
        public static Page<TModel> Page<TModel>(this IOrderedQueryable<TModel> query)
        {
            return Page(query, Defaults.Index, Defaults.PageLength);
        }

        public static Page<TModel> Page<TModel>(this IOrderedQueryable<TModel> query, PageRequest pageRequest)
        {
            return Page(query, pageRequest.Index, pageRequest.Length);
        }

        public static Page<TModel> Page<TModel>(this IOrderedQueryable<TModel> query, int index)
        {
            return Page(query, index, Defaults.PageLength);
        }

        public static Page<TModel> Page<TModel>(this IOrderedQueryable<TModel> query, int index, int pageLength)
        {
            int count = 0;
            TModel[] itens;
            IQueryable<TModel> q;

            count = query.Count();
            q = query.Skip((index - 1) * pageLength)
                .Take(pageLength);
            itens = q.ToArray();

            return new Page<TModel>()
            {
                Index = index,
                Length = pageLength,
                Count = count,
                Itens = itens
            };
        }

        public static Page<TModel> Page<TModel, TKey>(this IQueryable<TModel> query, Expression<Func<TModel, TKey>> orderBy)
        {
            return Page(query, orderBy, Defaults.Index, Defaults.PageLength);
        }

        public static Page<TModel> Page<TModel, TKey>(this IQueryable<TModel> query, Expression<Func<TModel, TKey>> orderBy, PageRequest pageRequest)
        {
            return Page(query, orderBy, pageRequest.Index, pageRequest.Length);
        }

        public static Page<TModel> Page<TModel, TKey>(this IQueryable<TModel> query, Expression<Func<TModel, TKey>> orderBy, int index)
        {
            return Page(query, orderBy, index, Defaults.PageLength);
        }

        public static Page<TModel> Page<TModel, TKey>(this IQueryable<TModel> query, Expression<Func<TModel, TKey>> orderBy, int index, int pageLength)
        {
            int count = 0;
            TModel[] itens;

            count = query.Count();
            query = query.OrderBy(orderBy)
                .Skip((index - 1) * pageLength)
                .Take(pageLength);
            itens = query.ToArray();

            return new Page<TModel>()
            {
                Index = index,
                Length = pageLength,
                Count = count,
                Itens = itens
            };
        }
    }
}
