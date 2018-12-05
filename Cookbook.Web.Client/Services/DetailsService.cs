using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Components;

namespace Cookbook.Web.Client.Services {
    public class DetailsService : IDetailsService {
        private bool _isEditMode;
        private BlazorComponent _componentInEditMode;

        /// <inheritdoc />
        public event Func<bool, Task> IsEditModeChanged;

        /// <inheritdoc />
        public event Func<BlazorComponent, Task> ComponentInEditModeChanged;

        /// <inheritdoc />
        public event Func<Task> Discarding;


        /// <inheritdoc />
        public long RecipeId { get; set; }

        /// <inheritdoc />
        public bool IsEditMode {
            get => _isEditMode;
            set {
                if (_isEditMode != value) {
                    _isEditMode = value;
                    IsEditModeChanged?.Invoke(_isEditMode);
                }
            }
        }

        /// <inheritdoc />
        public BlazorComponent ComponentInEditMode {
            get => _componentInEditMode;
            set {
                if (_componentInEditMode != value) {
                    _componentInEditMode = value;
                    ComponentInEditModeChanged?.Invoke(_componentInEditMode);
                }
            }
        }

        /// <inheritdoc />
        public void Discard() {
            Discarding?.Invoke();
        }
    }
}
