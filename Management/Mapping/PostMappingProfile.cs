using Model.Domain;
using ModelViewShared.ModelView.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Management.Mapping
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, PostReference>().ReverseMap();     
            CreateMap<NewPost, Post>();           
        }
    }
}
