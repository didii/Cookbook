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
            CreateMap<Recipe, RecipeDto>().ForMember(x => x.Tags, m => m.MapFrom(y => y.AppliedTags));

            // Tags
            CreateMap<AppliedTag, TagDto>().ConvertUsing<AppliedTag_TagDto>();
            CreateMap<TagEdit, Tag>(MemberList.Source);
        }
    }
}
