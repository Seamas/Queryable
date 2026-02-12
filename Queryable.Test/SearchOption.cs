using Wang.Seamas.Queryable.Attributes;

namespace Wang.Seamas.Queryable.Test;

public class SearchOption
{
    [EndsWith]
    public string Title { get; set; }
    
    [IsNull("Title")]
    public string Name { get; set; }
    
    [LessThan("Title")]
    public string Alias { get; set; }
    
    [LessThanOrEqual]
    public int Likes { get; set; }
    
    [In("Likes")]
    public int[] TestLike { get; set; }
    
}