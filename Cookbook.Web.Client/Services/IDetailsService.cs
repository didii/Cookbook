using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;

namespace Cookbook.Web.Client.Services {
    public interface IDetailsService {
        event Action<bool> IsEditModeChanged;
        event Action<BlazorComponent> ComponentInEditModeChanged;
        event Action Discarding;

        long RecipeId { get; set; }
        bool IsEditMode { get; set; }
        BlazorComponent ComponentInEditMode { get; set; }
        void Discard();
    }
}
