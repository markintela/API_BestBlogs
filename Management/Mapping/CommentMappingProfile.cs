﻿using AutoMapper;
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
            CreateMap<Post, PostReference>().ReverseMap();
            CreateMap<NewCommment, Comment>();
            CreateMap<NewCommment, Comment>().ReverseMap();
        }       
    }
}