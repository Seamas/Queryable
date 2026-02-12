using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wang.Seamas.Queryable.Helpers;

namespace Wang.Seamas.Queryable.Test;


public class Tests
{
    private DbContextOptions<MovieDbContext> _options;
    
    [SetUp]
    public void Setup()
    {
        // TODO: Replace with your actual connection string
        var connectionString = "";
        _options = new DbContextOptionsBuilder<MovieDbContext>()
            .UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .Options;
    }

    [Test]
    public void Test1()
    {
        using var context = new MovieDbContext(_options);
        var searchOption = new SearchOption
        {
            Title = "你好",
            Name = "张三",
            Likes = 20,
            Alias = "比较像",
            TestLike = new []{ 50, 60 }
        };
        
        

        // var expression = QueryHelper.Visit<Movie>(searchOption);

        var (cond, param) = QueryHelper.Visit(searchOption);
        var movies = context.Set<Movie>()
            .Where(cond, param)   // .Where(expression)
            .Where(item => item.Likes > 10)
            .ToList();
        
        Console.WriteLine();
    }
}