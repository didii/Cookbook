using System;
using System.Collections.Generic;
using System.Text;
using Cookbook.Dtos;
using Microsoft.JSInterop;

namespace Cookbook.Web.Client.Services {
    public static class RecipeExtensions {
        public static RecipeUpdate ToUpdate(this RecipeDto recipe) {
            var json = Json.Serialize(recipe);
            return Json.Deserialize<RecipeUpdate>(json);
        }
    }
}
