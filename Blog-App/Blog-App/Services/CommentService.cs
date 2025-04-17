using AutoMapper;
using Blog_App.Dto.Request;
using Blog_App.Dto.Response;
using Blog_App.Repositories.Interface;
using Blog_App.Services.Interface;
using BlogApp.Models;

namespace BlogApp.Services
{ 

public class CommentService : ICommentService
{
    
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<CommentResponseDto> CreateComment(CommentRequestDto commentRequestDto)
    {
        Comment comment = _mapper.Map<Comment>(commentRequestDto);
        Comment savedComment = await _commentRepository.CreateComment(comment);

        CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(savedComment);

        return commentResponseDto;
    }

    public async Task<List<CommentResponseDto>> GetAllComments()
    {
        List<Comment> comments = await _commentRepository.GetAllComments();
        List<CommentResponseDto> commentResponseDtos = _mapper.Map<List<CommentResponseDto>>(comments);
        return commentResponseDtos;
    }


    public async Task<CommentResponseDto> GetCommentById(int id)
    {
        Comment comment = await _commentRepository.GetCommentById(id);
        CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(comment);
        return commentResponseDto;
    }

    public async Task<bool> DeleteComment(int id)
    {
        bool check = await _commentRepository.DeleteComment(id);
        return check;
    }

    public async Task<CommentResponseDto> UpdateComment(int id, CommentRequestDto commentRequestDto, int postId)
    {
        Comment comment = await _commentRepository.UpdateComment(id, commentRequestDto, postId);
        CommentResponseDto commentResponseDto = _mapper.Map<CommentResponseDto>(comment);
        return commentResponseDto;
    }

    public Task<PostResponseDto> CreatePost(PostRequestDto postRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<PostResponseDto>> GetAllPosts()
    {
        throw new NotImplementedException();
    }

    public Task<PostResponseDto> GetPostById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PostResponseDto> UpdatePost(int id, PostRequestDto postRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletePost(int id)
    {
        throw new NotImplementedException();
    }
}
}