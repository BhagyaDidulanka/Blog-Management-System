using Blog_App.Dto.Response;
using BlogApp.Models;

namespace Blog_App.Repositories.Interface
{
    public interface IPostRepository
    {
        Task<PostResponseDto> CreatePost(Post post);
        Task<List<Post>> GetAllpost();
        Task<Post> GetPostById(int id);
        Task<Post> Update(Post post);
        Task DeletePost(Post deletedPost);
        Task<List<Post>> GetAllPosts();
    }
}
