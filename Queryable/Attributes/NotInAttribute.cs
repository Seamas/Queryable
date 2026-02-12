using System.Collections;

namespace Wang.Seamas.Queryable.Attributes;

public class NotInAttribute(string name = "") : QueryAttribute(name, SqlOperator.NotIn)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)} not in @{i}";
    }

    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => false,
            IEnumerable enumerable => enumerable.GetEnumerator().MoveNext(),
            _ => false
        };
    }
}