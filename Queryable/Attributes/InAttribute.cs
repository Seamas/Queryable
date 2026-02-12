using System.Collections;
using Wang.Seamas.Queryable.Extensions;

namespace Wang.Seamas.Queryable.Attributes;

public class InAttribute(string name = "") : QueryAttribute(name, SqlOperator.In)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)} in @{i}";    
    }

    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => false,
            IEnumerable enumerable => enumerable.AnyElements(),
            _ => false
        };

    }
}