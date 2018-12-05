using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;

namespace Cookbook.Web.Client.Services {
    public interface IDetailsService {
        event Func<bool, Task> IsEditModeChanged;
        event Func<BlazorComponent, Task> ComponentInEditModeChanged;
        event Func<Task> Discarding;

        long RecipeId { get; set; }
        bool IsEditMode { get; set; }
        BlazorComponent ComponentInEditMode { get; set; }
        void Discard();
    }
}
