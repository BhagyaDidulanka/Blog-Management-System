using Blog_App.Dto.Request;
using BlogApp.Models;

namespace Blog_App.Repositories.Interface
{
    public interface ICommentRepository
    {
        Task<Comment> CreateComment(Comment comment);
        Task<Comment> GetCommentById(int id);
        Task<List<Comment>> GetAllComments();
        Task<bool> DeleteComment(int id);
        Task<Comment> UpdateComment(int id, CommentRequestDto commentRequestDto, int postId);
    }
}
