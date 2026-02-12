using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using Wang.Seamas.Queryable.Attributes;

namespace Wang.Seamas.Queryable.Helpers;

public static class QueryHelper
{
    public static (string, object?[] param) Visit(object obj)
    {
        var propertyInfos = obj.GetType().GetProperties()
            .Where(p => p.GetCustomAttribute<QueryAttribute>() != null)
            .ToArray();

        var sql = " true ";
        var param = new object?[propertyInfos.Length];
        
        for (var i = 0; i < propertyInfos.Length; i++)
        {
            var propertyInfo = propertyInfos[i];
            var queryAttribute = propertyInfo.GetCustomAttribute<QueryAttribute>();

            var value = propertyInfo.GetValue(obj);
            param[i] = value;
            
            // If the value is not valid, we skip adding it to the SQL query.
            // This allows for dynamic filtering based on the attributes.
            if (queryAttribute.IsValid(value))
            {
                sql += $" and {queryAttribute.ToExpression(i, propertyInfo.Name)} ";
            }

        }

        return (sql, param);
    }
    
    
    /// <summary>
    /// 转换成
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="config"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Expression<Func<T, bool>>? Visit<T>(object obj, ParsingConfig? config = null)
    {
        var (cond, param) = Visit(obj);
        return DynamicExpressionParser.ParseLambda<T, bool>(config ?? ParsingConfig.Default, true, cond, param);
    }
}