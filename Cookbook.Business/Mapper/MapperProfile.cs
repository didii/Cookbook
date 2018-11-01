using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Cookbook.Domain;
using Cookbook.Dtos;

namespace Cookbook.Business.Mapper {
    class MapperProfile : Profile {
        public MapperProfile() {
            // Food
            CreateMap<Food, FoodDto>();
            CreateMap<FoodCreate, Food>();
            CreateMap<FoodUpdate, Food>();

            // Recipe
            CreateMap<Recipe, RecipeDto>();

            // Tags
            CreateMap<AppliedTag, TagDto>().Substitute(x => x.Tag);
        }
    }
}
