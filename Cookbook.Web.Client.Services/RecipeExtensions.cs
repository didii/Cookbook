using System;
using System.Collections.Generic;
using System.Text;
using Cookbook.Dtos;
using Microsoft.JSInterop;

namespace Cookbook.Web.Client.Services {
    public static class RecipeExtensions {
        /// <summary>
        /// Converts the recipe to its update variant
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public static RecipeUpdate ToUpdate(this RecipeDto recipe) {
            //TODO: no, just no
            var json = Json.Serialize(recipe);
            return Json.Deserialize<RecipeUpdate>(json);
        }
    }
}
