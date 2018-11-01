using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Cookbook.Domain;
using Cookbook.Dtos;

namespace Cookbook.Business.Mapper {
    class AppliedTag_TagDto : ITypeConverter<AppliedTag, TagDto> {
        /// <inheritdoc />
        public TagDto Convert(AppliedTag source, TagDto destination, ResolutionContext context) {
            if (source == null)
                return null;
            if (destination == null)
                destination = new TagDto();

            destination.Id = source.TagId;
            destination.Name = source.Tag.Name;
            destination.CreatedOn = source.CreatedOn;
            destination.UpdatedOn = source.UpdatedOn;
            destination.CreatedBy = context.Mapper.Map<UserDto>(source.CreatedBy);
            destination.UpdatedBy = context.Mapper.Map<UserDto>(source.UpdatedBy);

            return destination;
        }
    }
}
