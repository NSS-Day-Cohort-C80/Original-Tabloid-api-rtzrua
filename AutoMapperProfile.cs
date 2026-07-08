using AutoMapper;
using Tabloid.Models;
using Tabloid.Models.DTOs;

namespace Tabloid.Models;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
       CreateMap<Category, CategoryDTO>();
       CreateMap<CategoryDTO, Category>();
       CreateMap<Post, PostDTO>();
       CreateMap<PostDTO, Post>();
       CreateMap<PostTag, PostTagDTO>();
       CreateMap<PostTagDTO, PostTag>();
       CreateMap<Reaction, ReactionDTO>();
       CreateMap<ReactionDTO, Reaction>();
       CreateMap<Tag, TagDTO>();
       CreateMap<TagDTO, Tag>();
       CreateMap<UserProfile, UserProfileDTO>();
       CreateMap<UserProfileDTO, UserProfile>();
    }
}