﻿using AutoMapper;
using Blog_App.Dto.Request;
using Blog_App.Dto.Response;
using Blog_App.Repositories.Interface;
using Blog_App.Services.Interface;
using BlogApp.Models;

namespace Blog_App.Services
{
    public class PostService : IPostServices
    {
        //DI
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<PostResponseDto> CreatePost(PostRequestDto postRequestDto)
        {
            Post post = _mapper.Map<Post>(postRequestDto);
            PostResponseDto postResponseDto = await _postRepository.CreatePost(post);
            return postResponseDto;
        }

        public async Task<List<PostResponseDto>> GetAllPosts()
        {
            List<Post> posts = await _postRepository.GetAllPosts();
            List<PostResponseDto> postResponseDtos = _mapper.Map<List<PostResponseDto>>(posts);
            return postResponseDtos;
        }

        public async Task<PostResponseDto> GetPostById(int id)
        {
            Post post = await _postRepository.GetPostById(id);
            PostResponseDto postResponseDto = _mapper.Map<PostResponseDto>(post);
            return postResponseDto;
        }

        public async Task<PostResponseDto> UpdatePost(int id, PostRequestDto postRequestDto)
        {
            Post post = await _postRepository.GetPostById(id);
            post.Title = postRequestDto.Title;
            post.Content = postRequestDto.Content;

            Post savedPost = await _postRepository.Update(post);
            PostResponseDto postResponseDto = _mapper.Map<PostResponseDto>(savedPost);
            return postResponseDto;
        }

        public async Task<bool> DeletePost(int id)
        {
            Post post = await _postRepository.GetPostById(id);
            if (post == null)
                return false;
            else
            {
                Post deletedPost = await _postRepository.GetPostById(id);
                await _postRepository.DeletePost(deletedPost);
                return true;
            }
        }

    }
}
