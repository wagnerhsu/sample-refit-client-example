using Refit;

public interface IBlogApi
{
        [Get("/posts/{id}")]
    Task<Post> GetPostAsync(int id);

    [Get("/posts")]
    Task<List<Post>> GetPostsAsync();

    [Post("/posts")]
    Task<Post> CreatePostAsync([Body] Post post);

    [Put("/posts/{id}")]
    Task<Post> UpdatePostAsync(int id, [Body] Post post);

    [Delete("/posts/{id}")]
    Task DeletePostAsync(int id);

    // uses an object to represent query parameters. This approach is excellent 
    // for endpoints with many optional parameters. Refit will automatically 
    // convert this object into a query string
    [Get("/posts")]
    Task<List<Post>> GetPostsAsync([Query] PostQueryParameters parameters);
}

public class PostQueryParameters
{
    public int? UserId { get; set; }
    public string? Title { get; set; }
}
