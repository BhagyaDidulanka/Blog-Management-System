using Blog_App.Dto.Request;
using Blog_App.Dto.Response;

namespace Blog_App.Services.Interface
{
    public interface IPostServices
    {
        Task<PostResponseDto> CreatePost(PostRequestDto postRequestDto);

        Task<List<PostResponseDto>> GetAllPosts();
        Task<PostResponseDto> GetPostById(int id);
        Task<PostResponseDto> UpdatePost(int id, PostRequestDto postRequestDto);
        Task<bool> DeletePost(int id);
    }
}
