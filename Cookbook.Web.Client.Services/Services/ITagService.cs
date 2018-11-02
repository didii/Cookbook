﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Web.Client.Services {
    public interface ITagService {
        Task SetTagForRecipe(long recipeId, TagEdit tag);
        Task RemoveTagFromRecipe(long recipeId, long tagId);
    }
}
