namespace Wang.Seamas.Queryable.Attributes;

public class GreaterThanOrEqualAttribute(string name = "") : QueryAttribute(name, SqlOperator.GreaterThanOrEqual)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)} >= @{i}";
    }

    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => false,
            string strValue => !string.IsNullOrWhiteSpace(strValue),
            _ => true
        };
    }
}