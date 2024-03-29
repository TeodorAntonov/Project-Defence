﻿using DataModels.Models;

namespace Interfaces
{
    public interface IUserProfile
    {
        Task<ProfileViewModel> GetMyProfile(string id);
        Task AddRolesToUsers(string email);
    }
}
