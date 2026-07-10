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
       CreateMap<Post, PostDTO>()
    .ForMember(dto => dto.AuthorName, opt => opt.MapFrom(p => p.UserProfile.FullName));
       CreateMap<PostDTO, Post>();
       CreateMap<PostTag, PostTagDTO>();
       CreateMap<PostTagDTO, PostTag>();
       CreateMap<Reaction, ReactionDTO>();
       CreateMap<ReactionDTO, Reaction>();
       CreateMap<Tag, TagDTO>();
       CreateMap<TagDTO, Tag>();
       CreateMap<UserProfile, UserProfileDTO>();
       CreateMap<UserProfileDTO, UserProfile>();
       CreateMap<Post, PostDetailDTO>()
    .ForMember(dto => dto.AuthorUserName, opt => opt.MapFrom(p => p.UserProfile.IdentityUser.UserName));
      CreateMap<Comment, CommentDTO>()
    .ForMember(dto => dto.AuthorDisplayName, opt => opt.MapFrom(c => c.UserProfile.FullName));   
    }
}