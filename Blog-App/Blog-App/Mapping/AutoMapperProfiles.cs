using AutoMapper;
using Blog_App.Dto.Request;
using Blog_App.Dto.Response;
using BlogApp.Models;

namespace Blog_App.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PostRequestDto, Post>();
            CreateMap<Post, PostRequestDto>();

            CreateMap<CommentRequestDto, Comment>();
            CreateMap<Comment, CommentResponseDto>();
        }
    }
}
