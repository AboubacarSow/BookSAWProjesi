using Entities.Models;
using System.Reflection;
using System.Text;

namespace Repositories.EFCore.Extensions
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQueryString<T>(string orderByString)
        {
            var orderParams = orderByString.Trim().Split(",");
            var propertyInfo = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach(var param in orderParams)
            {
                if (param is null)
                    continue;
                var propertyFromQueryString = param.Trim().Split(' ')[0];
                var objectproperty = propertyInfo
                    .FirstOrDefault(p => p.Name.Equals(propertyFromQueryString,
                    StringComparison.InvariantCultureIgnoreCase));
                if (objectproperty is null) continue;
                var direction = param.EndsWith("des") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectproperty.Name.ToString()} {direction},");
            }
            return orderQueryBuilder.ToString().TrimEnd(',',' ');
        }
    }
}
