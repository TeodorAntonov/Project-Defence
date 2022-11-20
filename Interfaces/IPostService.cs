using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetAllPosts();
        Task<IEnumerable<PostViewModel>> GetLastFourPosts();
        Task AddPostAsync(PostViewModel model);
        Task<PostViewModel> GetFullPostAsync(int postId);
    }
}
