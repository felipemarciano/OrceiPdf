using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace OrceiPdf.Repository.Utils
{
    public static class SQLBuilderQueries
    {
        public static SqlBuilder FiltrarIgnorandoCaracteresEspeciais(this SqlBuilder builder, string coluna, string texto)
        {
            if (!string.IsNullOrEmpty(texto))
                builder
                    .Where(
                        $"{coluna} Like @{coluna.Replace(".", "#")} Collate SQL_Latin1_General_CP1253_CI_AI",
                        new Dictionary<string, object> { { $"{coluna.Replace(".", "#")}", $"%{texto.Trim()}%" } }
                    );

            return builder;
        }

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> q, string SortField, bool Ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");

            if (SortField.Contains('.'))
            {
                var parts = SortField.Split('.');

                Expression parent = param;

                foreach (var part in parts)
                {
                    parent = Expression.Property(parent, part);
                }

                var exp = Expression.Lambda(parent, param);

                string method = Ascending ? "OrderBy" : "OrderByDescending";
                Type[] types = new Type[] { q.ElementType, exp.Body.Type };
                var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
                return q.Provider.CreateQuery<T>(mce);
            }
            else
            {
                var prop = Expression.Property(param, SortField);
                var exp = Expression.Lambda(prop, param);
                string method = Ascending ? "OrderBy" : "OrderByDescending";
                Type[] types = new Type[] { q.ElementType, exp.Body.Type };
                var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
                return q.Provider.CreateQuery<T>(mce);
            }
        }
    }
}
