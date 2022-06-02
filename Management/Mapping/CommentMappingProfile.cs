using AutoMapper;
using Model.Domain;
using ModelViewShared.ModelView.Comment;
using ModelViewShared.ModelView.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Mapping
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile() {     
            CreateMap<Comment, CommentView>();
            CreateMap<Comment, CommentView>().ReverseMap();
            CreateMap<NewCommment, Comment>();
            CreateMap<UpdateComment, Comment>();
          
        }       
    }
}
