﻿using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IApplicationFormService
    {
        Task CreateApplicationAsync(ApplicationFormForTrainersViewModel model, string userId);
    }
}
