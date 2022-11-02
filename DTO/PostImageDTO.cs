﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PostImageDTO
    {
        public bool isDeleted;

        public int ID { get; set; }
        public int PostID { get; set; }
        public string ImagePath { get; set; }
        public int LastUpdateUserID { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
