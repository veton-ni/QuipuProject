using System.Linq.Expressions;

namespace Infrastructure.Extension
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source,
                IEnumerable<string> fieldsToSort)
        {
            Expression expression = source.Expression;
            bool firstTime = true;

            foreach (var f in fieldsToSort)
            {
                // { x }
                var parameter = Expression.Parameter(typeof(T), "x");
                var orderDiraction = "";
                var item = f;
                if (f.EndsWith("Desc"))
                {
                    orderDiraction = "Descending";
                    item = f.Remove(f.Length - 4);
                }


                // { x.FIELD }, e.g, { x.ID }, { x.Name }, etc
                var selector = Expression.PropertyOrField(parameter, item);

                // { x => x.FIELD }
                var lambda = Expression.Lambda(selector, parameter);


                //OrderByDescending
                // You can include sorting directions for advanced cases
                var method = firstTime
                    ? $"OrderBy{orderDiraction}"
                    : $"ThenBy{orderDiraction}";

                // { OrderBy(x => x.FIELD) }
                expression = Expression.Call(
                    typeof(Queryable),
                    method,
                    new Type[] { source.ElementType, selector.Type },
                    expression,
                    Expression.Quote(lambda)
                );

                firstTime = false;
            }

            return firstTime
                ? source
                : source.Provider.CreateQuery<T>(expression);
        }
    }
}
