using AutoMapper;
using Blog_App.Data;
using Blog_App.Dto.Response;
using Blog_App.Repositories.Interface;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_App.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PostResponseDto> CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            PostResponseDto postResponseDto = _mapper.Map<PostResponseDto>(post);
            return postResponseDto;

        }

        public async Task<List<Post>> GetAllpost()
        {
            List<Post> posts = await _context.Posts.Include(p => p.Comments).ToListAsync();
            return posts;
        }
        public async Task<Post> GetPostById(int id)
        {
            Post post = await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
            return post;
        }
        public async Task<Post> Update(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }
        public async Task DeletePost(Post deletedPost)
        {
            _context.Posts.Remove(deletedPost);
            await _context.SaveChangesAsync();
        }

        public Task<List<Post>> GetAllPosts()
        {
            throw new NotImplementedException();
        }
    }
}
