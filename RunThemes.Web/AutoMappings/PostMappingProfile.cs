using AutoMapper;
using RunThemes.Data.Models;
using RunThemes.Web.AutoMappings.Resolvers;
using RunThemes.Web.ViewModels;

namespace RunThemes.Web.AutoMappings
{
    public class PostMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(d => d.PostedByName, opts => opts.Ignore())
                .ForMember(d => d.PostedByAvatar, opts => opts.UseValue("/Images/user.png"))
                .ForMember(d => d.NewCommentMessage, opts => opts.Ignore())
                .ForMember(d => d.PostComments, opts => opts.ResolveUsing<PostCommentsResolver>());

            CreateMap<PostComment, PostCommentViewModel>()
                .ForMember(d => d.CommentedByName, opts => opts.MapFrom(s => s.UserProfile.UserName))
                .ForMember(d => d.CommentedByAvatar, opts => opts.UseValue("/Images/user.png"));

        }
    }
}