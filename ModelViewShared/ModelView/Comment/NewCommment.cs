﻿using ModelViewShared.ModelView.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelViewShared.ModelView.Comment
{
    public class NewCommment
    {

        
        public PostReference Post { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
       
    }
}
