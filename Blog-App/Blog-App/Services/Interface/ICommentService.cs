using Blog_App.Dto.Request;
using Blog_App.Dto.Response;

namespace Blog_App.Services.Interface
{
    public interface ICommentService
    {
        Task<PostResponseDto> CreatePost(PostRequestDto postRequestDto);

        Task<List<PostResponseDto>> GetAllPosts();
        Task<PostResponseDto> GetPostById(int id);
        Task<PostResponseDto> UpdatePost(int id, PostRequestDto postRequestDto);
        Task<bool> DeletePost(int id);
        Task<CommentResponseDto> CreateComment(CommentRequestDto commentRequestDto);
        Task<List<CommentResponseDto>> GetAllComments();
        Task<CommentResponseDto> GetCommentById(int id);
        Task<CommentResponseDto> UpdateComment(int id, CommentRequestDto commentRequestDto, int postId);
        Task<bool> DeleteComment(int id);
    }
}
