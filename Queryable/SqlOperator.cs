namespace Wang.Seamas.Queryable;

public enum SqlOperator
{
    Equal,   // ==
    NotEqual,   // !=
    GreaterThan,  // >
    GreaterThanOrEqual,  // >=   
    LessThan,   // <
    LessThanOrEqual,  // <=
    Like,  // %x%
    StartsWith,  // x%
    EndsWith,   // %x
    In,       // IN (x, y, z)
    NotIn,    // NOT IN (x, y, z)
    IsNull,   // is null
    IsNotNull,  // is not null
}