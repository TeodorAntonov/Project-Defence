using DataModels.Constants;
using DataModels.Entities;
using DataModels.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectDefence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPostAsync(PostViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Text = model.Text,
                DatePublishedOn = DateTime.UtcNow,
            };
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetAllPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return posts.Select(p => new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Text = p.Text != null ? $"{p.Text.Substring(0, 9)}..." : null,
                DatePublishedOn = p.DatePublishedOn.ToString("dd/MM/yyyy")
            }).OrderByDescending(p => p.DatePublishedOn);
        }

        public async Task<PostViewModel> GetFullPostAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post == null)
            {
                return null;
            }

            return new PostViewModel()
            {
                Id = post.Id,
                Text = post.Text,
                Title = post.Title,
                DatePublishedOn = post.DatePublishedOn.ToString("dd/MM/yyyy")
            };
        }

        public async Task<IEnumerable<PostViewModel>> GetLastFourPosts()
        {
            var posts = await _context.Posts.OrderByDescending(p => p.DatePublishedOn).ToListAsync();

            return posts.Select(p => new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Text = p.Text != null ? $"{p.Text.Substring(0, 9)}..." : null,
                DatePublishedOn = p.DatePublishedOn.ToString("dd/MM/yyyy")
            })
            .Take(4)
            .ToList();
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post == null)
            {
                throw new ArgumentException("No such post Id.");
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
